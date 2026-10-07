using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Shared.Integration.Ethereum.Application.Requests;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;

namespace wirachain_backend.Shared;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Blockchain Test")]
public class BlockchainTestController(IEventEmitterFactory eventEmitterFactory) : ControllerBase
{
    [HttpPost("revoke-access")]
    public async Task<IActionResult> GrantPermission([FromBody] PermissionRequest request)
    {
        try
        {
            var emitter = eventEmitterFactory.Create<PermissionRequest>("RevokePermission");
            await emitter.EmitEventAsync(0, request);
            return Ok(new { message = "Revoked Permission" });
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}