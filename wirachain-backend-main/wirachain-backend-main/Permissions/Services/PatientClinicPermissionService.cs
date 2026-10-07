using AutoMapper;
using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Integration.Ethereum.Application.Requests;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;
using wirachain_backend.Shared.Integration.Ethereum.Factory;

namespace wirachain_backend.Permissions.Services;

public class PatientClinicPermissionService(
    IPatientClinicPermissionRepository patientClinicPermissionRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IEventEmitterFactory eventEmitterFactory
)
    : IPatientClinicPermissionService
{
    public async Task<PageResult<PatientClinicPermissionResource>> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string searchTerm)
    {
        return mapper.Map<PageResult<PatientClinicPermissionResource>>(
            await patientClinicPermissionRepository.PageByPatientIdAsync(pageIndex, pageSize, patientId, searchTerm));
    }

    public async Task<PageResult<PatientClinicPermissionResource>> PageByClinicIdAsync(int pageIndex, int pageSize,
        long clinicId, string searchTerm)
    {
        return mapper.Map<PageResult<PatientClinicPermissionResource>>(
            await patientClinicPermissionRepository.PageByClinicIdAsync(pageIndex, pageSize, clinicId, searchTerm));
    }

    public async Task PatchPatientClinicPermissionStatusByPatientIdAndClinicIdAsync(Guid patientId, long clinicId,
        PermissionStatus permissionStatus)
    {
        var existingPatientClinicPermission =
            await patientClinicPermissionRepository.FindClinicPermissionByClinicIdAndPatientIdAsync(clinicId,
                patientId);
        if (existingPatientClinicPermission is null)
            throw new KeyNotFoundException("Permission not found");


        await unitOfWork.BeginTransactionAsync();
        existingPatientClinicPermission.PermissionStatus = permissionStatus;
        await unitOfWork.CommitTransactionAsync();
    }

    public async Task PatchPatientClinicPermissionStatusByIdAsync(Guid permissionId, PermissionStatus permissionStatus)
    {
        var existingPatientClinicPermission =
            await patientClinicPermissionRepository.FindAsync(permissionId);

        if (existingPatientClinicPermission is null)
            throw new KeyNotFoundException($"Permission with id {permissionId} does not exist");

        await unitOfWork.BeginTransactionAsync();

        if (existingPatientClinicPermission.PermissionStatus == PermissionStatus.Pending)
        {
            existingPatientClinicPermission.IsActive = true;
            existingPatientClinicPermission.IsRequired = false;
            existingPatientClinicPermission.PermissionStatus = PermissionStatus.Approved;
        }

        IEventEmitter<PermissionRequest> emitter = eventEmitterFactory.Create<PermissionRequest>("GrantPermission");

        await emitter.EmitEventAsync(0, new PermissionRequest
        {
            PatientId = existingPatientClinicPermission.PatientId,
            ClinicId = existingPatientClinicPermission.ClinicId,
        });
        
        await unitOfWork.CommitTransactionAsync();
    }
}