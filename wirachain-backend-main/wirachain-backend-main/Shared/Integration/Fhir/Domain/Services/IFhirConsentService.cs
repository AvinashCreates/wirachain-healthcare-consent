namespace wirachain_backend.Shared.Integration.Fhir.Domain.Services;

public interface IFhirConsentService
{
    Task<string> CreateAsync(
        Guid consentId,
        Guid patientId,
        Guid doctorId,
        string purpose,
        IReadOnlyList<string> resourceTypes,
        DateTime grantedAtUtc,
        DateTime expiresAtUtc);

    Task RevokeAsync(string fhirConsentId);
}
