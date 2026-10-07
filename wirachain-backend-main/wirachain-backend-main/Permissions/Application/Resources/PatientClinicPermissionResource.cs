using wirachain_backend.Clinics.Application.Resources.Basic;
using wirachain_backend.Doctors.Application.Resources.Basic;
using wirachain_backend.Patients.Application.Resources.Basic;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Permissions.Application.Resources;

public class PatientClinicPermissionResource
{
    public Guid Id { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
    public PermissionStatus PermissionStatus { get; set; }
    public BasicDoctorResource? RequiredByDoctor { get; set; }
    public BasicClinicResource? Clinic { get; set; }
    public BasicPatientResource? Patient { get; set; }
}