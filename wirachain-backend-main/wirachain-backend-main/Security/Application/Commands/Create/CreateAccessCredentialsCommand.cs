namespace wirachain_backend.Security.Application.Commands.Create;

public class CreateAccessCredentialsCommand
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}