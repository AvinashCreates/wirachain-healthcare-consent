using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Auth.Application.Requests.Create;
using wirachain_backend.Auth.Domain.Services;
using wirachain_backend.Security.Application.Requests.Auth;
using wirachain_backend.Security.Domain.Services;

namespace wirachain_backend.Security.Controllers.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Register and login")]
public class AuthController(IUserService userService, IMapper mapper) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest registerUserRequest)
    {
        var result = await userService.RegisterAsync(registerUserRequest);
        if(result.Success)
            return Ok(result.Data);
        return BadRequest(result.Message);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        return Ok(await userService.LoginAsync(loginRequest));
    }

}