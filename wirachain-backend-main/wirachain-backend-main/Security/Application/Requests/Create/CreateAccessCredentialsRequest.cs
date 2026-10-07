namespace wirachain_backend.Security.Application.Requests.Create;

public class CreateAccessCredentialsRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}