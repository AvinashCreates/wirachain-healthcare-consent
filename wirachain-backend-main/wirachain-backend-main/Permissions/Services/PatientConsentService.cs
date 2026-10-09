using System.Text.Json;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Permissions.Application.Requests;
using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Integration.Ethereum.Application.Requests;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;
using wirachain_backend.Shared.Integration.Fhir.Domain.Services;

namespace wirachain_backend.Permissions.Services;

public class PatientConsentService(
    IPatientConsentRepository consentRepository,
    IDoctorRepository doctorRepository,
    IFhirConsentService fhirConsentService,
    IUnitOfWork unitOfWork,
    IEventEmitterFactory eventEmitterFactory) : IPatientConsentService
{
    private static readonly Dictionary<string, string> SupportedResourceTypes = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Patient"] = "Patient",
        ["Practitioner"] = "Practitioner",
        ["Encounter"] = "Encounter",
        ["ServiceRequest"] = "ServiceRequest",
        ["Specimen"] = "Specimen",
        ["Observation"] = "Observation",
        ["DiagnosticReport"] = "DiagnosticReport",
    };

    public async Task<PatientConsentResource> GrantAsync(Guid patientId, GrantPatientConsentRequest request)
    {
        var doctor = await doctorRepository.FindAsync(request.DoctorId);
        if (doctor is null)
        {
            throw new KeyNotFoundException("Doctor not found");
        }

        var normalizedScopes = request.ResourceTypes
            .Where(scope => !string.IsNullOrWhiteSpace(scope))
            .Select(scope => SupportedResourceTypes.TryGetValue(scope.Trim(), out var canonical)
                ? canonical
                : throw new ArgumentException($"Unsupported FHIR resource type: {scope}"))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (normalizedScopes.Count == 0)
        {
            throw new ArgumentException("At least one FHIR resource type is required");
        }

        if (request.DurationDays is < 1 or > 30)
        {
            throw new ArgumentOutOfRangeException(nameof(request.DurationDays), "Consent duration must be between 1 and 30 days");
        }

        var grantedAtUtc = DateTime.UtcNow;
        var consent = new PatientConsent
        {
            Id = Guid.NewGuid(),
            PatientId = patientId,
            DoctorId = request.DoctorId,
            Purpose = request.Purpose.Trim(),
            ResourceScopesJson = JsonSerializer.Serialize(normalizedScopes),
            GrantedAtUtc = grantedAtUtc,
            ExpiresAtUtc = grantedAtUtc.AddDays(request.DurationDays),
        };

        await unitOfWork.BeginTransactionAsync();
        try
        {
            await consentRepository.AddAsync(consent);
            consent.FhirConsentId = await fhirConsentService.CreateAsync(
                consent.Id,
                consent.PatientId,
                consent.DoctorId,
                consent.Purpose,
                normalizedScopes,
                consent.GrantedAtUtc,
                consent.ExpiresAtUtc);

            var clinicId = doctor.DoctorClinics.Select(dc => dc.ClinicId).FirstOrDefault();
            var permissionEmitter = eventEmitterFactory.Create<PermissionRequest>("GrantPermission");
            consent.BlockchainTransactionHash = await permissionEmitter.EmitEventAsync(0, new PermissionRequest
            {
                PatientId = patientId,
                ClinicId = clinicId,
            });

            consentRepository.Update(consent);
            await unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw;
        }

        return ToResource(consent);
    }

    public async Task<IReadOnlyList<PatientConsentResource>> ListByPatientIdAsync(Guid patientId)
    {
        var consents = await consentRepository.ListByPatientIdAsync(patientId);
        return consents.Select(ToResource).ToList();
    }

    public async Task RevokeAsync(Guid patientId, Guid consentId)
    {
        var consent = await consentRepository.FindByIdAndPatientIdAsync(consentId, patientId);
        if (consent is null)
        {
            throw new KeyNotFoundException("Consent not found");
        }

        if (consent.RevokedAtUtc.HasValue)
        {
            return;
        }

        await unitOfWork.BeginTransactionAsync();
        try
        {
            consent.RevokedAtUtc = DateTime.UtcNow;
            var doctor = await doctorRepository.FindAsync(consent.DoctorId);
            var clinicId = doctor?.DoctorClinics.Select(dc => dc.ClinicId).FirstOrDefault() ?? 0;

            if (!string.IsNullOrWhiteSpace(consent.FhirConsentId))
            {
                await fhirConsentService.RevokeAsync(consent.FhirConsentId);
            }

            var revokeEmitter = eventEmitterFactory.Create<PermissionRequest>("RevokePermission");
            consent.BlockchainTransactionHash = await revokeEmitter.EmitEventAsync(0, new PermissionRequest
            {
                PatientId = patientId,
                ClinicId = clinicId,
            });

            consentRepository.Update(consent);
            await unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw;
        }
    }

    public async Task<bool> IsAuthorizedAsync(Guid patientId, Guid doctorId, string resourceType)
    {
        if (!SupportedResourceTypes.TryGetValue(resourceType, out var canonicalResourceType))
        {
            return false;
        }

        var nowUtc = DateTime.UtcNow;
        var consents = await consentRepository.ListByPatientAndDoctorAsync(patientId, doctorId, nowUtc);
        return consents.Any(consent => consent.AllowsResource(canonicalResourceType, nowUtc));
    }

    private static PatientConsentResource ToResource(PatientConsent consent)
    {
        string[] scopes;
        try
        {
            scopes = JsonSerializer.Deserialize<string[]>(consent.ResourceScopesJson) ?? [];
        }
        catch (JsonException)
        {
            scopes = [];
        }

        return new PatientConsentResource
        {
            Id = consent.Id,
            DoctorId = consent.DoctorId,
            Purpose = consent.Purpose,
            ResourceTypes = scopes,
            GrantedAtUtc = consent.GrantedAtUtc,
            ExpiresAtUtc = consent.ExpiresAtUtc,
            RevokedAtUtc = consent.RevokedAtUtc,
            Status = consent.Status,
            FhirConsentId = consent.FhirConsentId,
            BlockchainTransactionHash = consent.BlockchainTransactionHash,
        };
    }
}
