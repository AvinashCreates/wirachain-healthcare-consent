using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Commands.Update;
using wirachain_backend.Clinics.Application.ViewModels;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Domain.Services;

public interface IClinicService
{
    Task<ClinicResponse> FindAsync(long id);
    Task<ClinicResponse> RemoveAsync(long id);
    Task<ClinicResponse> AddAsync(CreateClinicCommand clinic);
    Task<ClinicResponse> UpdateAsync(long id, UpdateClinicCommand clinic);
    Task<PageResult<Clinic>> ListByPageAsync(int pageIndex, int pageSize, string searchTerm);
    Task<PageResult<Clinic>> PageByAdminIdAsync(int pageIndex, int pageSize, string searchTerm, Guid adminId);
    Task AssignPatientToClinicAsync(long clinicId, Guid patientId);
    Task<PageResult<ClinicsWithStatusViewModel>> PageByPatientIdAsync(int page, int pageSize,
        Guid patientId, string searchTerm);
}