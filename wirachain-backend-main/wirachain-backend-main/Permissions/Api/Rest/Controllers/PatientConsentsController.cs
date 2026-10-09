using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wirachain_backend.Permissions.Application.Requests;
using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Permissions.Api.Rest.Controllers;

[ApiController]
[Authorize]
[Route("api/v0/consents")]
public class PatientConsentsController(IPatientConsentService consentService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PatientConsentResource>> GrantAsync(GrantPatientConsentRequest request)
    {
        if (!TryGetUserId(out var patientId))
        {
            return Unauthorized();
        }

        if (!HasUserType(UserType.Patient))
        {
            return Forbid();
        }

        return Ok(await consentService.GrantAsync(patientId, request));
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PatientConsentResource>>> ListMineAsync()
    {
        if (!TryGetUserId(out var patientId))
        {
            return Unauthorized();
        }

        if (!HasUserType(UserType.Patient))
        {
            return Forbid();
        }

        return Ok(await consentService.ListByPatientIdAsync(patientId));
    }

    [HttpDelete("{consentId:guid}")]
    public async Task<IActionResult> RevokeAsync(Guid consentId)
    {
        if (!TryGetUserId(out var patientId))
        {
            return Unauthorized();
        }

        if (!HasUserType(UserType.Patient))
        {
            return Forbid();
        }

        await consentService.RevokeAsync(patientId, consentId);
        return NoContent();
    }

    [HttpGet("patients/{patientId:guid}/authorization")]
    public async Task<IActionResult> CheckAuthorizationAsync(Guid patientId, [FromQuery] string resourceType)
    {
        if (!TryGetUserId(out var doctorId))
        {
            return Unauthorized();
        }

        if (!HasUserType(UserType.Doctor))
        {
            return Forbid();
        }

        return Ok(new
        {
            authorized = await consentService.IsAuthorizedAsync(patientId, doctorId, resourceType),
        });
    }

    private bool TryGetUserId(out Guid userId)
    {
        return Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId);
    }

    private bool HasUserType(UserType userType)
    {
        var claimValue = User.FindFirstValue("userType");
        return int.TryParse(claimValue, out var value) && value == (int)userType + 1;
    }
}
