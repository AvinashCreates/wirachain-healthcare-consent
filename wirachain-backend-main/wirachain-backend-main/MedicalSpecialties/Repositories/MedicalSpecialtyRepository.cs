using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.MedicalSpecialties.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.MedicalSpecialties.Repositories;

public class MedicalSpecialtyRepository(AppDbContext context) : BaseRepository<MedicalSpecialty, long>(context), IMedicalSpecialtyRepository
{
    public async Task<IEnumerable<MedicalSpecialty>> ListMedicalSpecialtiesByIdListAsync(IList<long> specialtyIds)
    {
        return await DbSet.Where(specialty => specialtyIds.Contains(specialty.Id)).ToListAsync();
    }

    public async Task<PageResult<MedicalSpecialty>> PageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        var query = DbSet.Where(specialty => specialty.Name.ToLower().StartsWith(searchTerm.ToLower()));
        var totalCount = await query.CountAsync();

        return new PageResult<MedicalSpecialty>
        {
            Count = totalCount,
            Results = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(),
        };
    }
}