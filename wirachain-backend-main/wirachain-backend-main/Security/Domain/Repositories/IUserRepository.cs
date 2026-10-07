using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;

namespace wirachain_backend.Security.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User, Guid>
{
    Task<User?> FindByEmailAsync(string email);
}