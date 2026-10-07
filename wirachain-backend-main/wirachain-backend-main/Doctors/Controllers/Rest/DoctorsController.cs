using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Auth.Application.Requests.Patch;
using wirachain_backend.Doctors.Application.Commands.Create;
using wirachain_backend.Doctors.Application.Commands.Update;
using wirachain_backend.Doctors.Application.Requests.Create;
using wirachain_backend.Doctors.Application.Requests.Update;
using wirachain_backend.Doctors.Application.Resources.Show;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Services;
using wirachain_backend.Doctors.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Extensions.Exceptions;

namespace wirachain_backend.Doctors.Controllers.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Doctors CRUD 🚀")]
public class DoctorsController(IDoctorService doctorService, IMapper mapper) : ControllerBase
{
    [HttpGet("page")]
    public async Task<PageResult<DoctorResource>> FindByPageAsync([FromQuery] int pageIndex, [FromQuery] int pageSize,
        [FromQuery] string? searchTerm = "")
    {
        return mapper.Map<PageResult<Doctor>, PageResult<DoctorResource>>(
            await doctorService.FindByPageAsync(pageIndex, pageSize, searchTerm!));
    }

    [HttpPost("{doctorId:guid}/clinic/{clinicId:long}/patient/{patientId:guid}")]
    public async Task<IActionResult> RequestPatientPermissionAsync(Guid doctorId, long clinicId, Guid patientId)
    {
        await doctorService.RequestPatientPermissionAsync(doctorId, clinicId, patientId);
        return Ok(new { message = $"Doctor {doctorId} permission requested to patient with ID {patientId}" });
    }

    [HttpGet("page/admin/{adminId:guid}")]
    public async Task<PageResult<DoctorResource>> FindByPageAsync([FromQuery] int pageIndex, [FromQuery] int pageSize,
        Guid adminId, [FromQuery] string? searchTerm = "")
    {
        return mapper.Map<PageResult<Doctor>, PageResult<DoctorResource>>(
            await doctorService.PageByAdminIdAsync(pageIndex, pageSize, searchTerm!, adminId));
    }

    [HttpGet("{doctorId:guid}")]
    public async Task<IActionResult> FindDoctorAsync(Guid doctorId)
    {
        var response = await doctorService.FindAsync(doctorId);
        if (!response.Success)
            return BadRequest(response);
        return Ok(mapper.Map<DoctorResource>(response.Data));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctorAsync(CreateDoctorRequest createDoctor)
    {
        var mappedDoctor = mapper.Map<CreateDoctorCommand>(createDoctor);
        var response = await doctorService.AddAsync(mappedDoctor);
        if (!response.Success)
            return BadRequest(response);
        return Ok(mapper.Map<DoctorResource>(response.Data));
    }

    [HttpPut("{doctorId:guid}")]
    public async Task<IActionResult> UpdateDoctorAsync([FromRoute(Name = "doctorId")] Guid doctorId,
        [FromBody] UpdateDoctorRequest updateDoctor)
    {
        var mappedDoctor = mapper.Map<UpdateDoctorCommand>(updateDoctor);
        var response = await doctorService.UpdateAsync(doctorId, mappedDoctor);
        if (!response.Success)
            return BadRequest(response);
        return Ok(mapper.Map<DoctorResource>(response.Data));
    }

    [HttpDelete("{doctorId:guid}")]
    public async Task<IActionResult> RemoveDoctorAsync(Guid doctorId)
    {
        var response = await doctorService.RemoveAsync(doctorId);
        if (!response.Success)
            return BadRequest(response);
        return Ok(mapper.Map<DoctorResource>(response.Data));
    }

    [HttpPatch("{id:guid}/password")]
    public async Task<IActionResult> ChangePasswordAsync(Guid id, PatchPasswordRequest passwordRequest)
    {
        await doctorService.ChangePasswordAsync(id, passwordRequest);
        return Ok(new { message = "Password changed successfully" });
    }
}