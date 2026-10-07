using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Auth.Resources.Show;

public class UserResource
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserType Type { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}