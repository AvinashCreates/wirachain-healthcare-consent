using wirachain_backend.Auth.Resources.Show;

namespace wirachain_backend.Clinics.Application.Resources.Show;

public class ClinicAdministratorResource
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public UserResource User { get; set; }
    public DateTime DateOfBirth { get; set; }
}