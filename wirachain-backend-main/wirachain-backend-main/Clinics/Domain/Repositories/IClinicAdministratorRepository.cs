using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Domain.Repositories;

public interface IClinicAdministratorRepository : IBaseRepository<ClinicAdministrator, Guid>
{
    Task<ClinicAdministrator?> FindByEmailAsync(string email);
    Task<PageResult<ClinicAdministrator>> ListByPageAsync(int pageIndex, int pageSize, string searchTerm = "");
}