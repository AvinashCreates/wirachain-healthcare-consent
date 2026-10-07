namespace wirachain_backend.Auth.Application.Requests.Create;

public class RegisterUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
}