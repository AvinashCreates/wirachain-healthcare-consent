using Microsoft.EntityFrameworkCore;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Doctors.Repositories;

public class DoctorRepository(AppDbContext context) : BaseRepository<Doctor, Guid>(context), IDoctorRepository
{
    public override async Task<Doctor?> FindAsync(Guid id)
    {
        return await DbSet.Where(c => c.Id == id)
            .Include(c => c.DoctorClinics)
            .ThenInclude(dc => dc.Clinic)
            .Include(doctor => doctor.DoctorMedicalSpecialties)
            .ThenInclude(doctorMedicalSpecialty => doctorMedicalSpecialty.MedicalSpecialty)
            .FirstOrDefaultAsync();
    }

    public async Task<Doctor?> FindByEmailAsync(string email)
    {
        return await DbSet
            .Where(c => c.Email == email)
            .FirstOrDefaultAsync();
    }

    public async Task<PageResult<Doctor>> PageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        var query = DbSet
            .Where(doctor => doctor.FirstName.Contains(searchTerm!) || doctor.LastName.Contains(searchTerm!) ||
                             doctor.Email.Contains(searchTerm!))
            .OrderBy(doctor => doctor.Id)
            .AsQueryable();

        var totalCount = await query.CountAsync();

        var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

        var pageResult = new PageResult<Doctor>
        {
            Count = totalCount,
            Results = items,
        };
        return pageResult;
    }

    public async Task<PageResult<Doctor>> PageByAdminIdAsync(int pageIndex, int pageSize, string searchTerm,
        Guid adminId)
    {
        var query = context.DoctorClinics
            .Where(dc => dc.Clinic.AdministratorId == adminId)
            .Include(doctorClinic => doctorClinic.Clinic)
            .Include(doctorClinic => doctorClinic.Doctor)
            .Where(dc => dc.Doctor.FirstName.ToLower().StartsWith(searchTerm.ToLower()) || dc.Doctor.LastName.ToLower().StartsWith(searchTerm.ToLower()) ||
                         dc.Doctor.Email.ToLower().Contains(searchTerm.ToLower()))
            .Select(dc => dc.Doctor)
            .Distinct()
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        var pageResult = new PageResult<Doctor>
        {
            Count = totalCount,
            Results = items
        };
        return pageResult;
    }
}