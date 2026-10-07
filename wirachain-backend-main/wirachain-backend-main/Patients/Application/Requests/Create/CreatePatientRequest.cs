using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Security.Application.Requests.Create;

namespace wirachain_backend.Patients.Application.Requests.Create;

public class CreatePatientRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public CreateAccessCredentialsRequest User { get; set; } = null!;
}