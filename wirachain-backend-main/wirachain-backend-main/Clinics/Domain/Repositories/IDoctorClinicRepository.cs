using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;

namespace wirachain_backend.Clinics.Domain.Repositories;

//  Guid -> DoctorId
//  long -> ClinicId
public interface IDoctorClinicRepository : IBaseRepository<DoctorClinic, Guid>
{
    Task<IEnumerable<DoctorClinic>> GetDoctorClinicsByDoctorId(Guid doctorId);
    Task<IEnumerable<DoctorClinic>> GetDoctorClinicsByClinicId(long clinicId);
    Task AddRangeAsync(IEnumerable<DoctorClinic> doctorClinics);
}