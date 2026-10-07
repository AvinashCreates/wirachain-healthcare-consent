using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Clinics.Repositories;

public class DoctorClinicRepository(AppDbContext context)
    : BaseRepository<DoctorClinic, Guid>(context), IDoctorClinicRepository
{
    public async Task<IEnumerable<DoctorClinic>> GetDoctorClinicsByDoctorId(Guid doctorId)
    {
        return await DbSet.Where(c => c.DoctorId == doctorId).ToListAsync();
    }

    public async Task<IEnumerable<DoctorClinic>> GetDoctorClinicsByClinicId(long clinicId)
    {
        return await DbSet.Where(c => c.ClinicId == clinicId).ToListAsync();
    }

    public async Task AddRangeAsync(IEnumerable<DoctorClinic> doctorClinics)
    {
        await DbSet.AddRangeAsync(doctorClinics);
    }
}