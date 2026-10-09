using wirachain_backend.Permissions.Application.Requests;
using wirachain_backend.Permissions.Application.Resources;

namespace wirachain_backend.Permissions.Domain.Services;

public interface IPatientConsentService
{
    Task<PatientConsentResource> GrantAsync(Guid patientId, GrantPatientConsentRequest request);
    Task<IReadOnlyList<PatientConsentResource>> ListByPatientIdAsync(Guid patientId);
    Task RevokeAsync(Guid patientId, Guid consentId);
    Task<bool> IsAuthorizedAsync(Guid patientId, Guid doctorId, string resourceType);
}
