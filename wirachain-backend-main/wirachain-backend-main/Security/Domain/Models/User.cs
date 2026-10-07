using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Models;

namespace wirachain_backend.Security.Domain.Models;

public class User : AuditModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = String.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string HashedPassword { get; set; } = string.Empty;
    public UserType UserType { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    // Relations
    public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
}