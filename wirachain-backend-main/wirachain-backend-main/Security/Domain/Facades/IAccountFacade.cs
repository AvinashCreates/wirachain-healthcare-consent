using wirachain_backend.Auth.Application.Commands;
using wirachain_backend.Auth.Application.Commands.Create;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Auth.Resources.Show;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Auth.Domain.Facades;

public interface IAccountFacade
{
    Task<User> RegisterUser(RegisterUserCommand command);
}