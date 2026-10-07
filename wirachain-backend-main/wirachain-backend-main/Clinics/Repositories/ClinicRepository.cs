using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Application.ViewModels;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Clinics.Repositories;

public class ClinicRepository(AppDbContext context) : BaseRepository<Clinic, long>(context), IClinicRepository
{
    public override async Task<Clinic?> FindAsync(long id)
    {
        return await DbSet.Where(clinic => clinic.Id == id)
            .Include(c => c.Administrator)
            .Include(c => c.MedicalTestClinics)
            .ThenInclude(c => c.MedicalTest)
            .FirstOrDefaultAsync();
    }

    public async Task<PageResult<Clinic>> ListByPageAsync(int page, int pageSize, string searchTerm)
    {
        var query = DbSet.OrderBy(c => c.Id).Where(c => c.Ruc.Contains(searchTerm)).AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        var pageResult = new PageResult<Clinic>
        {
            Count = totalCount,
            Results = items
        };
        return pageResult;
    }

    public async Task<PageResult<Clinic>> PageByAdminIdAsync(int page, int pageSize, string searchTerm, Guid adminId)
    {
        var query = DbSet.OrderBy(c => c.Id)
            .Where(c => c.AdministratorId == adminId && c.Name.ToLower().StartsWith(searchTerm.ToLower()))
            .AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        var pageResult = new PageResult<Clinic>
        {
            Count = totalCount,
            Results = items
        };
        return pageResult;
    }

    public async Task<IEnumerable<Clinic>> ListClinicsByListIdAsync(IList<long> clinicIds)
    {
        return await DbSet.Where(clinic => clinicIds.Contains(clinic.Id)).ToListAsync();
    }

    public async Task<PageResult<ClinicsWithStatusViewModel>> PageByPatientIdAsync(int page, int pageSize,
        Guid patientId, string searchTerm)
    {
        var query = DbSet.Select(clinic => new ClinicsWithStatusViewModel
        {
            Id = clinic.Id,
            Name = clinic.Name,
            Address = clinic.Address,
            Ruc = clinic.Ruc,
            IsRequired = clinic.PatientClinicsPermissions.Any(c => c.PatientId == patientId && c.IsRequired),
            IsActive = clinic.PatientClinicsPermissions.Any(c => c.PatientId == patientId && c.IsActive),
        }).AsQueryable();
        
        var totalCount = await query.CountAsync();
        
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        
        return new PageResult<ClinicsWithStatusViewModel>
        {
            Results = items,
            Count = totalCount,
        };
    }
}