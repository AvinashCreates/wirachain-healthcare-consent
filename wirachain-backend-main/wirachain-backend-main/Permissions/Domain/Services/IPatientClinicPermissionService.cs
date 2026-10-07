using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Permissions.Domain.Services;

public interface IPatientClinicPermissionService
{
    Task<PageResult<PatientClinicPermissionResource>> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string searchTerm);

    Task<PageResult<PatientClinicPermissionResource>> PageByClinicIdAsync(int pageIndex, int pageSize,
        long clinicId, string searchTerm);

    Task PatchPatientClinicPermissionStatusByPatientIdAndClinicIdAsync(Guid patientId, long clinicId, PermissionStatus permissionStatus);
    Task PatchPatientClinicPermissionStatusByIdAsync(Guid permissionId, PermissionStatus permissionStatus);
}