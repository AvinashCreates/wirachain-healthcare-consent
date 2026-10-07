using Microsoft.EntityFrameworkCore;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Security.Domain.Repositories;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Security.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User, Guid>(context), IUserRepository
{
    public Task<User?> FindByEmailAsync(string email)
    {
        return DbSet.Where(u => u.Email == email)
            .Include(user => user.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync();
    }
}