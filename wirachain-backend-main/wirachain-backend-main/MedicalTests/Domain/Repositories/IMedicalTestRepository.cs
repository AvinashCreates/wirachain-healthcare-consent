using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalTests.Domain.Repositories;

public interface IMedicalTestRepository : IBaseRepository<MedicalTest, long>
{
    Task<IEnumerable<MedicalTest>> ListAllAsync();
    Task<PageResult<MedicalTest>> PageAsync(int pageIndex, int pageSize, string searchTerm);
    Task<IEnumerable<MedicalTest>> ListByListMedicalTestId(IList<long> medicalTestIds);
}