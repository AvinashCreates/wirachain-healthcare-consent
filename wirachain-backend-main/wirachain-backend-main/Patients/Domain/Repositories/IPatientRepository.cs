using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Patients.Domain.Repositories;

public interface IPatientRepository : IBaseRepository<Patient, Guid>
{
    Task<PageResult<Patient>> PageAsync(int pageIndex, int pageSize, string searchTerm);
}