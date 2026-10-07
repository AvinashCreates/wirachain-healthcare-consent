using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;

namespace wirachain_backend.Doctors.Domain.Repositories;

public interface IDoctorMedicalSpecialtyRepository : IBaseRepository<DoctorMedicalSpecialty, Guid>
{
    Task AddRangeAsync(IEnumerable<DoctorMedicalSpecialty> doctorMedicalSpecialties);
}