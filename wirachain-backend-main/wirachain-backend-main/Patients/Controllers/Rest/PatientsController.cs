using System.Net.Mime;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Patients.Application.Commands.Create;
using wirachain_backend.Patients.Application.Commands.Update;
using wirachain_backend.Patients.Application.Requests.Create;
using wirachain_backend.Patients.Application.Requests.Update;
using wirachain_backend.Patients.Application.Resources.Basic;
using wirachain_backend.Patients.Application.Resources.Show;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Patients.Domain.Services;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Patients.Controllers.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Patients Controller 🚀")]
public class PatientsController(
    IPatientService patientService,
    IPatientConsentService consentService,
    IMapper mapper) : ControllerBase
{
    [HttpGet("page")]
    public async Task<IActionResult> PagePatientBySearchTermAsync([FromQuery] int pageIndex, [FromQuery] int pageSize,
        [FromQuery] string? searchTerm = "")
    {
        return Ok(mapper.Map<PageResult<PatientResource>>(
            await patientService.PageBySearchTermAsync(pageIndex, pageSize, searchTerm!)));
    }

    [HttpGet("{patientId}")]
    [Authorize]
    public async Task<IActionResult> GetPatientByIdAsync(Guid patientId)
    {
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var requesterId))
        {
            return Unauthorized();
        }

        var isPatientOwner = requesterId == patientId && IsUserType(UserType.Patient);
        var isConsentedDoctor = IsUserType(UserType.Doctor)
            && await consentService.IsAuthorizedAsync(patientId, requesterId, "Patient");
        if (!isPatientOwner && !isConsentedDoctor)
        {
            return Forbid();
        }

        var result = await patientService.FindAsync(patientId);
        return Ok(mapper.Map<PatientResource>(result.Data));
    }

    private bool IsUserType(UserType userType)
    {
        return int.TryParse(User.FindFirstValue("userType"), out var value)
            && value == (int)userType + 1;
    }

    [SwaggerOperation(Description = "Get pageable patients from a clinic.",
        Summary = "Retrieving patients from a clinic.")]
    [HttpGet("clinic/{clinicId:long}")]
    public async Task<PageResult<BasicPatientResource>> GetClinicByIdAsync(int pageIndex, int pageSize, long clinicId,
        string? searchTerm = "")
    {
        return mapper.Map<PageResult<Patient>, PageResult<BasicPatientResource>>(
            await patientService.PageByClinicIdAsync(pageIndex, pageSize, clinicId, searchTerm!));
    }

    [HttpGet("page/query")]
    public async Task<PageResult<BasicPatientResource>> GetPatientByQueryOptionalAsync([FromQuery] int pageIndex,
        [FromQuery] int pageSize, [FromQuery] string? searchTerm, [FromQuery] long? clinicId,
        [FromQuery] Guid? doctorId
    )
    {
        return await patientService.PageQueryAsync(pageIndex, pageSize, searchTerm, doctorId, clinicId);
    }

    [HttpGet("clinic/{clinicId:long}/doctor/{doctorId:guid}")]
    public async Task<PageResult<BasicPatientResource>> GetPatientByDoctorIdAndClinicIdAsync([FromQuery] int pageIndex,
        [FromQuery] int pageSize, [FromRoute] long clinicId,
        [FromRoute] Guid doctorId, [FromQuery] string? searchTerm = ""
    )
    {
        return await patientService.PageByDoctorIdAndClinicIdAsync(pageIndex, pageSize, clinicId, doctorId, searchTerm!);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatientAsync([FromBody] CreatePatientRequest patient)
    {
        var mappedPatient = mapper.Map<CreatePatientCommand>(patient);
        var result = await patientService.AddAsync(mappedPatient);
        return Ok(mapper.Map<PatientResource>(result.Data));
    }

    [HttpPut("{patientId}")]
    public async Task<IActionResult> UpdatePatientAsync(Guid patientId, [FromBody] UpdatePatientRequest patient)
    {
        var mappedPatient = mapper.Map<UpdatePatientCommand>(patient);
        var result = await patientService.UpdateAsync(patientId, mappedPatient);
        return Ok(mapper.Map<PatientResource>(result.Data));
    }

    [HttpDelete("{patientId}")]
    public async Task<IActionResult> DeletePatientAsync(Guid patientId)
    {
        var result = await patientService.RemoveAsync(patientId);
        return Ok(mapper.Map<PatientResource>(result.Data));
    }


    [HttpPost("{patientId:guid}/clinic/{clinicId:long}")]
    public async Task<IActionResult> CreatePatientToClinicPermission(Guid patientId, long clinicId)
    {
        await patientService.CreateAccessToClinicAsync(patientId, clinicId);
        return Ok(new { Message = "Clinic is allowed to see your profile." });
    }

    [HttpPatch("{patientId:guid}/clinic/{clinicId:long}")]
    public async Task<IActionResult> AssignPatientToClinic(Guid patientId, long clinicId)
    {
        await patientService.GrantAccessToClinicAsync(patientId, clinicId);
        return Ok(new { Message = "Clinic is allowed to see your profile." });
    }

    [HttpDelete("{patientId:guid}/clinic/{clinicId:long}")]
    public async Task<IActionResult> RevokePatientToClinic(Guid patientId, long clinicId)
    {
        await patientService.RevokeAccessToClinicAsync(patientId, clinicId);
        return Ok(new { message = "Clinic is revoked from access." });
    }
}