namespace wirachain_backend.Auth.Resources.Payloads;

public class RegisterPayload
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}