using wirachain_backend.Auth.Application.Requests.Patch;
using wirachain_backend.Auth.Domain.Services.Communication;
using wirachain_backend.Doctors.Application.Commands.Create;
using wirachain_backend.Doctors.Application.Commands.Update;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Doctors.Domain.Services;

public interface IDoctorService
{
    Task<DoctorResponse> FindAsync(Guid id);
    Task<DoctorResponse> AddAsync(CreateDoctorCommand doctor);
    Task<DoctorResponse> UpdateAsync(Guid doctorId, UpdateDoctorCommand doctor);
    Task<DoctorResponse> RemoveAsync(Guid doctorId);
    Task<PageResult<Doctor>> FindByPageAsync(int pageIndex, int pageSize, string searchTerm);
    Task<PageResult<Doctor>> PageByAdminIdAsync(int pageIndex, int pageSize, string searchTerm, Guid adminId);
    Task<DoctorResponse> AssignDoctorToClinicAsync(Guid doctorId, long clinicId);
    Task ChangePasswordAsync(Guid doctorId, PatchPasswordRequest patchPasswordRequest);
    Task RequestPatientPermissionAsync(Guid doctorId, long clinicId, Guid patientId);
}