using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Auth.Domain.Services.Communication;
using wirachain_backend.Security.Application.Requests.Auth;
using wirachain_backend.Security.Domain.Services.Communication;

namespace wirachain_backend.Security.Domain.Services;

public interface IUserService
{
    Task<RegisterResponse> RegisterAsync(RegisterUserRequest request);
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
}