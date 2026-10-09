using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;

namespace wirachain_backend.Permissions.Domain.Repositories;

public interface IPatientConsentRepository : IBaseRepository<PatientConsent, Guid>
{
    Task<IReadOnlyList<PatientConsent>> ListByPatientIdAsync(Guid patientId);
    Task<PatientConsent?> FindByIdAndPatientIdAsync(Guid consentId, Guid patientId);
    Task<IReadOnlyList<PatientConsent>> ListByPatientAndDoctorAsync(Guid patientId, Guid doctorId, DateTime nowUtc);
}
