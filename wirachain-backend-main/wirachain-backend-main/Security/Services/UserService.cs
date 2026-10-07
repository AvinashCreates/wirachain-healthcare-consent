using AutoMapper;
using wirachain_backend.Auth.Application.Commands.Create;
using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Auth.Domain.Facades;
using wirachain_backend.Auth.Domain.Services.Communication;
using wirachain_backend.Auth.Resources.Payloads;
using wirachain_backend.Security.Application.Requests.Auth;
using wirachain_backend.Security.Application.Services;
using wirachain_backend.Security.Domain.Repositories;
using wirachain_backend.Security.Domain.Services;
using wirachain_backend.Security.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Repositories;

namespace wirachain_backend.Security.Services;

public class UserService(
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IJwtService jwtService,
    IMapper mapper,
    IAccountFacade accountFacade) : IUserService
{
    public async Task<RegisterResponse> RegisterAsync(RegisterUserRequest request)
    {
        try
        {
            var existingUser = await userRepository.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new ApplicationException("Email already exists. You want to register an other type of account?.");

            await unitOfWork.BeginTransactionAsync();

            var command = mapper.Map<RegisterUserCommand>(request);
            var user = await accountFacade.RegisterUser(command);
            await unitOfWork.CommitTransactionAsync();

            // Payload 
            var registerPayload = new RegisterPayload
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.Phone,
                FullName = user.FullName,
            };

            return new RegisterResponse(registerPayload);
        }
        catch (Exception e)
        {
            return new RegisterResponse(e.Message);
        }
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var existingUser = await userRepository.FindByEmailAsync(loginRequest.Email);
        if(existingUser == null)
            throw new ApplicationException("Email does not exist. Please try again.");
        if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, existingUser.HashedPassword))
            throw new UnauthorizedAccessException("Incorrect password or email.");

        var loginData = new LoginResponse.LoginResponseData
        {
            Email = existingUser.Email,
            FirstName = existingUser.FirstName,
            LastName = existingUser.LastName,
            UserId = existingUser.Id,
            AccessToken = jwtService.GenerateToken(existingUser),
            RefreshToken = "not_available", // TO-DO
        };
        
        return new LoginResponse(loginData);
    }
}