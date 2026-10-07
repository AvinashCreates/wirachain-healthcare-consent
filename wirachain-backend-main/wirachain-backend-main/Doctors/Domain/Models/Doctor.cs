using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Security.Domain.Models;

namespace wirachain_backend.Doctors.Domain.Models;

public class Doctor : User
{
    // Foreign Key
    public Guid UserId { get; set; }
    public IList<DoctorClinic> DoctorClinics { get; set; } = new List<DoctorClinic>();
    public IList<DoctorMedicalSpecialty> DoctorMedicalSpecialties { get; set; } = new List<DoctorMedicalSpecialty>();
    public IList<PatientClinicPermission> PatientClinicsPermissions { get; set; } = new List<PatientClinicPermission>();
}