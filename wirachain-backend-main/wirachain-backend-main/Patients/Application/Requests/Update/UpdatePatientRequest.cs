using wirachain_backend.Auth.Application.Requests.Update;

namespace wirachain_backend.Patients.Application.Requests.Update;

public class UpdatePatientRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public UpdateUserRequest User { get; set; } = null!;
}