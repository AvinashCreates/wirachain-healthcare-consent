using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Clinics.Repositories;

public class ClinicAdministratorRepository(AppDbContext context)
    : BaseRepository<ClinicAdministrator, Guid>(context), IClinicAdministratorRepository
{
    public override async Task<ClinicAdministrator?> FindAsync(Guid id)
    {
        return await DbSet.Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<ClinicAdministrator?> FindByEmailAsync(string email)
    {
        return await DbSet.Where(administrator => administrator.Email == email).FirstOrDefaultAsync();
    }

    public async Task<PageResult<ClinicAdministrator>> ListByPageAsync(int pageIndex, int pageSize,
        string searchTerm)
    {
        var query = DbSet
            .Where(administrator => administrator.FirstName.Contains(searchTerm) ||
                                    administrator.LastName.Contains(searchTerm))
            .OrderBy(a => a.Id)
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        var pageResult = new PageResult<ClinicAdministrator>
        {
            Count = totalCount,
            Results = items,
        };

        return pageResult;
    }
}