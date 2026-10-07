using wirachain_backend.Auth.Application.Requests.Patch;
using wirachain_backend.Auth.Domain.Services.Communication;
using wirachain_backend.Clinics.Application.Commands;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Requests.Create;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Domain.Services;

public interface IClinicAdministratorService
{
    Task<PageResult<ClinicAdministrator>> PageAsync(int pageIndex, int pageSize, string searchTerm);
    Task<ClinicAdministratorResponse> FindAsync(Guid id);
    Task<ClinicAdministratorResponse> RemoveAsync(Guid id);
    Task<ClinicAdministratorResponse> AddAsync(CreateClinicAdministratorCommand admin);
    Task<ClinicAdministratorResponse> UpdateAsync(Guid id, ClinicAdministrator admin);
    Task ChangePasswordAsync(Guid id, PatchPasswordRequest patchPasswordRequest);
}