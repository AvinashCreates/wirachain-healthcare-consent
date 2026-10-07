using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalTests.Domain.Repositories;

public interface IMedicalTestClinicRepository : IBaseRepository<MedicalTestClinic, Guid>
{
    Task<IEnumerable<MedicalTest>> ListAllByClinicAdministratorIdAsync(Guid clinicAdministratorId);    
    Task<PageResult<MedicalTest>> PageByAdministratorIdAndClinicIdAsync(long clinicId, Guid clinicAdministratorId, int pageIndex, int pageSize, string searchTerm);
    Task AddRangeAsync(IEnumerable<MedicalTestClinic> medicalTestClinics);
}