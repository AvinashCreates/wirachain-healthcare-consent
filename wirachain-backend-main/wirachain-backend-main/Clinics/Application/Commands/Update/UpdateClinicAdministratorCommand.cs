using wirachain_backend.Auth.Application.Commands;
using wirachain_backend.Auth.Application.Commands.Update;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Clinics.Application.Commands.Update;

public class UpdateClinicAdministratorCommand
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UpdateUserCommand User { get; set; }
}