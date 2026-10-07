using wirachain_backend.MedicalTests.Domain.Models;

namespace wirachain_backend.Clinics.Domain.Models;

public class MedicalTestClinic
{
    public Guid Id { get; set; }
    
    // Foreign Key
    public long MedicalTestId { get; set; }
    public MedicalTest MedicalTest { get; set; }
    
    public long ClinicId { get; set; }
    public Clinic Clinic { get; set; }
}