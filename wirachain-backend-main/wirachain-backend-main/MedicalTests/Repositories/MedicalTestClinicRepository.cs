using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.MedicalTests.Repositories;

public class MedicalTestClinicRepository(AppDbContext context) : BaseRepository<MedicalTestClinic, Guid>(context), IMedicalTestClinicRepository 
{
    public async Task<IEnumerable<MedicalTest>> ListAllByClinicAdministratorIdAsync(Guid clinicAdministratorId)
    {
        return await DbSet
            .Include(mc => mc.Clinic)
            .ThenInclude(c => c.Administrator)
            .Where(mc => mc.Clinic.Administrator.Id == clinicAdministratorId)
            .Include(mc => mc.MedicalTest)
            .Select(mc => mc.MedicalTest)
            .Distinct()
            .ToListAsync();
    }

    public async Task<PageResult<MedicalTest>> PageByAdministratorIdAndClinicIdAsync(long clinicId, Guid clinicAdministratorId, int pageIndex, int pageSize, string searchTerm)
    {
        var query = DbSet
            .Where(mc => mc.Clinic.Administrator.Id == clinicAdministratorId && mc.ClinicId == clinicId)
            .Select(mc => mc.MedicalTest)
            .Distinct();
        
        var totalCount = await query.CountAsync();
        var results = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return new PageResult<MedicalTest>
        {
            Count = totalCount,
            Results = results,
        };
    }

    public async Task AddRangeAsync(IEnumerable<MedicalTestClinic> medicalTestClinics)
    {
        await DbSet.AddRangeAsync(medicalTestClinics);
    }
}