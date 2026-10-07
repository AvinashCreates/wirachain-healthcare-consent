using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Doctors.Application.Commands.Create;

public class CreateDoctorCommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    // public long ClinicId { get; set; } 
    public IList<long> ClinicIds { get; set; } = new List<long>();
    public IList<long> MedicalSpecialtyIds { get; set; } = new List<long>();
    public UserType Type { get; set; }
}