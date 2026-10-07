using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Doctors.Repositories;

public class DoctorMedicalSpecialtyRepository(AppDbContext context) : BaseRepository<DoctorMedicalSpecialty, Guid>(context), IDoctorMedicalSpecialtyRepository
{
    public async Task AddRangeAsync(IEnumerable<DoctorMedicalSpecialty> doctorMedicalSpecialties)
    {
        await DbSet.AddRangeAsync(doctorMedicalSpecialties);
    }
}