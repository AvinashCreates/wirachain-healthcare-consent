using wirachain_backend.Auth.Application.Commands;
using wirachain_backend.Auth.Application.Commands.Create;
using wirachain_backend.Security.Application.Commands.Create;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Patients.Application.Commands.Create;

public class CreatePatientCommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public CreateAccessCredentialsCommand User { get; set; } = null!;
}