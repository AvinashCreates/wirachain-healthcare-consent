using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Auth.Application.Requests.Patch;
using wirachain_backend.Clinics.Application.Commands;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Requests.Update;
using wirachain_backend.Clinics.Application.Resources.Basic;
using wirachain_backend.Clinics.Application.Resources.Show;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Services;
using wirachain_backend.Shared.Domain.Services.Communication;
using CreateClinicAdministratorRequest = wirachain_backend.Clinics.Application.Requests.Create.CreateClinicAdministratorRequest;

namespace wirachain_backend.Clinics.Controllers.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD Clinic Admins")]
public class ClinicAdministratorsController(IClinicAdministratorService clinicAdministratorService, IMapper mapper)
    : ControllerBase
{
    [HttpGet("page")]
    public async Task<PageResult<BasicClinicAdministratorResource>> ListByPageAsync([FromQuery] int pageIndex,
        [FromQuery] int pageSize, [FromQuery] string? searchTerm = "")
    {
        return mapper.Map<PageResult<BasicClinicAdministratorResource>>(
            await clinicAdministratorService.PageAsync(pageIndex, pageSize, searchTerm!));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetClinicAdministratorById([FromRoute] Guid id)
    {
        var result = await clinicAdministratorService.FindAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(mapper.Map<ClinicAdministrator, ClinicAdministratorResource>(result.Data!));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClinicAdministratorById(
        [FromBody] CreateClinicAdministratorRequest createClinicAdmin)
    {
        var mappedClinicAdmin = mapper.Map<CreateClinicAdministratorCommand>(createClinicAdmin);
        var result = await clinicAdministratorService.AddAsync(mappedClinicAdmin);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(mapper.Map<ClinicAdministrator, ClinicAdministratorResource>(result.Data!));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateClinicAdministratorById([FromRoute] Guid id,
        [FromBody] UpdateClinicAdministratorRequest updatedClinicAdmin)
    {
        var mappedClinic = mapper.Map<ClinicAdministrator>(updatedClinicAdmin);
        var result = await clinicAdministratorService.UpdateAsync(id, mappedClinic);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(mapper.Map<ClinicAdministrator, ClinicAdministratorResource>(result.Data!));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveClinicAdministratorById([FromRoute] Guid id)
    {
        var result = await clinicAdministratorService.RemoveAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(mapper.Map<ClinicAdministrator, ClinicAdministratorResource>(result.Data!));
    }

    [HttpPatch("{id:guid}/password")]
    public async Task<IActionResult> ChangePasswordAsync(Guid id, PatchPasswordRequest passwordRequest)
    {
        await clinicAdministratorService.ChangePasswordAsync(id, passwordRequest);
        return Ok(new { message = "Password changed successfully!" });
    }
}