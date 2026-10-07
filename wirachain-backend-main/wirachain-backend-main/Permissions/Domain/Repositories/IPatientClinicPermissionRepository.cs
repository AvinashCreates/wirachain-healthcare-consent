using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Permissions.Domain.Repositories;

public interface IPatientClinicPermissionRepository : IBaseRepository<PatientClinicPermission, Guid>
{
    Task<PageResult<Patient>>
        PagePatientsByClinicIdAsync(int pageIndex, int pageSize, long clinicId, string searchTerm);

    Task<PatientClinicPermission?> FindClinicPermissionByClinicIdAndPatientIdAsync(long clinicId, Guid patientId);
    Task<PatientClinicPermission?> FindClinicPermissionByClinicIdAsync(long clinicId);

    Task<PageResult<PatientClinicPermission>> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string searchTerm);

    Task<PageResult<PatientClinicPermission>> PageByClinicIdAsync(int pageIndex, int pageSize,
        long clinicId, string searchTerm);
}