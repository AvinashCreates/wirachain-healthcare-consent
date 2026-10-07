using wirachain_backend.Auth.Application.Commands.Update;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Doctors.Application.Commands.Update;

public class UpdateDoctorCommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UpdateUserCommand User { get; set; } = null!;
    public IList<long> ClinicIds { get; set; } = new List<long>();
    public IList<long> MedicalSpecialtyIds { get; set; } = new List<long>();
    public long ClinicId { get; set; } // First Clinic
    public UserType Type { get; set; }
}