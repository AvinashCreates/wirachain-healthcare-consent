using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalConsultations.Domain.Repositories;

public interface IMedicalConsultationRepository : IBaseRepository<MedicalConsultation, Guid>
{
    Task<PageResult<MedicalConsultation>> PageByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize, Guid doctorId, long clinicId, string searchTerm);
    Task<PageResult<MedicalConsultation>> PageByPatientIdAsync(int pageIndex, int pageSize, Guid patientId, string searchTerm);
    Task<PageResult<Patient>> PagePatientsByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize, Guid doctorId, long clinicId, string searchTerm);
    Task<PageResult<Patient>> PageQueryAsync(int pageIndex, int pageSize, string searchTerm,
        Guid? doctorId, long? clinicId);
    Task<PageResult<MedicalConsultation>> PageByClinicAdministratorIdAsync(int pageIndex, int pageSize, Guid clinicAdministratorId, string searchTerm);
}