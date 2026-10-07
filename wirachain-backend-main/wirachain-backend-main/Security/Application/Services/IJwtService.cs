using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Security.Domain.Models;

namespace wirachain_backend.Security.Application.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}