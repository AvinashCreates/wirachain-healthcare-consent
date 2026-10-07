using wirachain_backend.Auth.Domain.Models;

namespace wirachain_backend.Security.Domain.Models;

public class UserRole
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public long RoleId { get; set; }
    public Role Role { get; set; } = null!;
}