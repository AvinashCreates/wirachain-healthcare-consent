using wirachain_backend.Clinics.Application.Resources.Basic;
using wirachain_backend.MedicalSpecialties.Application.Resources.Show;
namespace wirachain_backend.Doctors.Application.Resources.Show;

public class DoctorResource
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public IList<MedicalSpecialtyResource> MedicalSpecialties { get; set; } = [];
    public IList<BasicClinicResource> Clinics { get; set; } = [];
}
