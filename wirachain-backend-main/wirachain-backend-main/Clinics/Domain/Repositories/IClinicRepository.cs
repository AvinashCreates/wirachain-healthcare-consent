using wirachain_backend.Clinics.Application.ViewModels;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Domain.Repositories;

public interface IClinicRepository : IBaseRepository<Clinic, long>
{
    Task<PageResult<Clinic>> ListByPageAsync(int page, int pageSize, string searchTerm);
    Task<PageResult<Clinic>> PageByAdminIdAsync(int page, int pageSize, string searchTerm, Guid adminId);
    Task<IEnumerable<Clinic>> ListClinicsByListIdAsync(IList<long> clinicIds);

    Task<PageResult<ClinicsWithStatusViewModel>> PageByPatientIdAsync(int page, int pageSize,
        Guid patientId, string searchTerm);
}