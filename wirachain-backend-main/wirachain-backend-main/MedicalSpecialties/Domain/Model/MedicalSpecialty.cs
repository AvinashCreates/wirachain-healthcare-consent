using wirachain_backend.Doctors.Domain.Models;

namespace wirachain_backend.MedicalSpecialties.Domain.Model;

public class MedicalSpecialty
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<DoctorMedicalSpecialty> DoctorMedicalSpecialties { get; set; } = new List<DoctorMedicalSpecialty>();
}