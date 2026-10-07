using wirachain_backend.Doctors.Domain.Models;

namespace wirachain_backend.Clinics.Domain.Models;

public class DoctorClinic
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
    public long ClinicId { get; set; }
    public Clinic Clinic { get; set; }
}