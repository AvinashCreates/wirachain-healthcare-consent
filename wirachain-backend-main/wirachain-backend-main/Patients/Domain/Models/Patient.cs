

using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Security.Domain.Models;

namespace wirachain_backend.Patients.Domain.Models;

public class Patient : User
{
    // Foreign Key
    public Guid UserId { get; set; }
    public IList<PatientClinicPermission> PatientClinicPermissions { get; set; } = new List<PatientClinicPermission>();
}