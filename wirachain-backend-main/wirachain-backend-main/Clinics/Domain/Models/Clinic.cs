using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;

namespace wirachain_backend.Clinics.Domain.Models;

public class Clinic
{
    public long Id { get; set; }
    public string Ruc { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    // Relations (Multiple)
    public IList<DoctorClinic> DoctorClinics { get; set; } = new List<DoctorClinic>();
    public IList<PatientClinicPermission> PatientClinicsPermissions { get; set; } = new List<PatientClinicPermission>();
    public IList<MedicalTestClinic> MedicalTestClinics { get; set; } = new List<MedicalTestClinic>();
    
    // Foreign
    public ClinicAdministrator Administrator { get; set; }
    public Guid AdministratorId { get; set; }
}