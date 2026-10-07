using wirachain_backend.Doctors.Domain.Models;

namespace wirachain_backend.Doctors.Domain.Facade;

public interface IDoctorFacade
{
    Task AssignClinic(Doctor existingDoctor, long clinicId);
    Task UpdateFirstClinic(Doctor existingDoctor, long clinicId); // Temporary
    Task AddClinicsAsync(Doctor existingDoctor, IList<long> clinicIds);
    Task ReplaceClinicsAsync(Doctor existingDoctor, IList<long> clinicIds);
    Task AddSpecialtiesAsync(Doctor doctor, IList<long> specialtyIds);
    Task ReplaceSpecialtiesAsync(Doctor doctor, IList<long> specialtyIds);
    Task RequestPatientPermissionAsync(Doctor existingDoctor, long clinicId, Guid patientId);
}