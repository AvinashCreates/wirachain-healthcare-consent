using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Clinics.Application.Resources.Basic;

public class BasicClinicAdministratorResource
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserType Type { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}