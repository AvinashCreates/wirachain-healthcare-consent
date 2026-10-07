using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Security.Domain.Services.Communication;

public class LoginResponse : BaseResponse<LoginResponse.LoginResponseData>
{
    public class LoginResponseData
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }

    public LoginResponse(LoginResponseData? entity) : base(entity)
    {
    }

    public LoginResponse(string message) : base(message)
    {
    }
}