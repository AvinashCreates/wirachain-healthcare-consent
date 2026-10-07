using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Security.Application.Services;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Settings;

namespace wirachain_backend.Security.Infrastructure.Security;

public class JwtService : IJwtService
{
    private readonly JwtSettings jwtSettings;

    public JwtService(IOptions<JwtSettings> options)
    {
        jwtSettings = options.Value;
    }

    public string GenerateToken(User user)
    {
        // Initializing claims

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new("userType", (int.Parse(user.UserType.ToString("D")) + 1).ToString())
        };

        // Get roles
        var roles = user.UserRoles.Select(ur => ur.Role);

        // Add roles to claims.
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, char.ToLower(role.Name[0]) + role.Name.Substring(1)));
        }

        // Prepare secret key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

        // Signing credentials
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Token object
        var token = new JwtSecurityToken(claims: claims, audience: jwtSettings.Audience,
            expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings.ExpirationMinutes)), signingCredentials: creds);

        // Write token
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}