using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalSpecialties.Domain.Repositories;

public interface IMedicalSpecialtyRepository : IBaseRepository<MedicalSpecialty, long>
{
    Task<IEnumerable<MedicalSpecialty>> ListMedicalSpecialtiesByIdListAsync(IList<long> ids);
    Task<PageResult<MedicalSpecialty>> PageAsync(int pageIndex, int pageSize, string searchTerm);
}