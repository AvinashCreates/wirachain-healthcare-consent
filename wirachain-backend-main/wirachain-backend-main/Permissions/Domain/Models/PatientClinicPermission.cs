using System.ComponentModel.DataAnnotations.Schema;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Permissions.Domain.Models;

public class PatientClinicPermission
{
    public Guid Id { get; set; }
    public bool IsRequired { get; set; }
    public bool IsActive { get; set; }
    [Column(TypeName = "varchar(60)")]
    public PermissionStatus PermissionStatus { get; set; }
    
    // Foreign Keys
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    
    public Clinic Clinic { get; set; }
    public long ClinicId { get; set; }
    public Guid? RequiredByDoctorId { get; set; }
    public Doctor? RequiredByDoctor { get; set; }
}