namespace wirachain_backend.Auth.Domain.Services.Communication;

public class ChangePasswordResponse(string message, bool success = false)
{
    public string Message { get; set; } = message;
    public bool Success { get; set; } = success; // False by default.
}