using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Doctors.Domain.Repositories;

public interface IDoctorRepository : IBaseRepository<Doctor, Guid>
{
    Task<Doctor?> FindByEmailAsync(string email);
    Task<PageResult<Doctor>> PageAsync(int pageIndex, int pageSize, string searchTerm);
    Task<PageResult<Doctor>> PageByAdminIdAsync(int pageIndex, int pageSize, string searchTerm, Guid adminId);
}