using wirachain_backend.Security.Domain.Models;

namespace wirachain_backend.Auth.Domain.Models;

public class Role
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    
    // Relations
    public IList<UserRole> UserRoles { get; set; } = new List<UserRole>();
    
}