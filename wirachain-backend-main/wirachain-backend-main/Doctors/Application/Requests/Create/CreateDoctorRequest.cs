using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Security.Application.Requests.Create;

namespace wirachain_backend.Doctors.Application.Requests.Create;

public class CreateDoctorRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    // public long ClinicId { get; set; }
    public IList<long> ClinicIds { get; set; } = new List<long>();
    public IList<long> MedicalSpecialtyIds { get; set; } = new List<long>();
    public DateTime DateOfBirth { get; set; }
    public CreateAccessCredentialsRequest AccessCredentials { get; set; } = null!;
}