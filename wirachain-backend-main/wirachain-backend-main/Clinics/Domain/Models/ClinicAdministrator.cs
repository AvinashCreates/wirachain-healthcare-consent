

using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Security.Domain.Models;

namespace wirachain_backend.Clinics.Domain.Models;

public class ClinicAdministrator : User
{
    public IList<Clinic> Clinics { get; set; } = new List<Clinic>();
    
    // Foreign
    public Guid UserId { get; set; }
    
}