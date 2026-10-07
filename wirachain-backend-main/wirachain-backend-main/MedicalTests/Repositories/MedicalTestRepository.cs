using Microsoft.EntityFrameworkCore;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.MedicalTests.Repositories;

public class MedicalTestRepository(AppDbContext context) : BaseRepository<MedicalTest, long>(context), IMedicalTestRepository
{
    public async Task<IEnumerable<MedicalTest>> ListAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<PageResult<MedicalTest>> PageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        var query = DbSet.Where(test => test.Name.Contains(searchTerm));
        var totalCount = await query.CountAsync();
        return new PageResult<MedicalTest>
        {
            Count = totalCount,
            Results = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync()
        };
    }

    public async Task<IEnumerable<MedicalTest>> ListByListMedicalTestId(IList<long> medicalTestIds)
    {
        return await DbSet.Where(mt => medicalTestIds.Contains(mt.Id)).ToListAsync();
    }
}