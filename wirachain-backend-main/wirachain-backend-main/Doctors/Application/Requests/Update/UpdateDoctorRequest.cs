using wirachain_backend.Auth.Application.Requests.Update;

namespace wirachain_backend.Doctors.Application.Requests.Update;

public class UpdateDoctorRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public IList<long> ClinicIds { get; set; } = new List<long>();
    public IList<long> MedicalSpecialtyIds { get; set; } = new List<long>();
    public DateTime DateOfBirth { get; set; }
    public UpdateUserRequest User { get; set; }
}