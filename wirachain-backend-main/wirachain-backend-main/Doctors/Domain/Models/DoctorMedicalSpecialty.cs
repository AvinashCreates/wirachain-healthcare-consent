using wirachain_backend.MedicalSpecialties.Domain.Model;

namespace wirachain_backend.Doctors.Domain.Models;

public class DoctorMedicalSpecialty
{
    public Guid Id { get; set; }
    // Foreign Key
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
    public MedicalSpecialty MedicalSpecialty { get; set; }
    public long MedicalSpecialtyId { get; set; }
}