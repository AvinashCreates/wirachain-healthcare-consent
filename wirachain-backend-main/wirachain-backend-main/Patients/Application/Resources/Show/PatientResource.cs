using wirachain_backend.Auth.Resources.Show;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Patients.Application.Resources.Show;

public class PatientResource
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}