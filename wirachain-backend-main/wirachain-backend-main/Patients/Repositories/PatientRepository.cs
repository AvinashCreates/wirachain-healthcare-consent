using Microsoft.EntityFrameworkCore;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Patients.Domain.Repositories;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Patients.Repositories;

public class PatientRepository(AppDbContext context) : BaseRepository<Patient, Guid>(context), IPatientRepository
{
    public override async Task<Patient?> FindAsync(Guid id)
    {
        return await DbSet.Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<PageResult<Patient>> PageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        var query = DbSet.Where(patient =>
                patient.FirstName.Contains(searchTerm) || patient.LastName.Contains(searchTerm))
            .OrderBy(p => p.Id)
            .Distinct();

        var totalCount = query.Count();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PageResult<Patient>
        {
            Count = totalCount,
            Results = items
        };
    }
}