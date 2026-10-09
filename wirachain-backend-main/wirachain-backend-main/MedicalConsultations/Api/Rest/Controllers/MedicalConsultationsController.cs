using System.Net.Mime;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Application.Requests.Create;
using wirachain_backend.MedicalConsultations.Application.Resources.Basic;
using wirachain_backend.MedicalConsultations.Domain.Services;
using wirachain_backend.MedicalConsultations.Domain.Services.Communication;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalConsultations.Api.Rest.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Medical consultations 🚀")]
public class MedicalConsultationsController(
    IMedicalConsultationService medicalConsultationService,
    IPatientConsentService consentService,
    IMapper mapper)
    : ControllerBase
{
    [HttpGet("{consultationId:guid}")]
    [Authorize]
    public async Task<IActionResult> FindMedicalConsultationAsync(Guid consultationId)
    {
        var result = await medicalConsultationService.FindAsync(consultationId);

        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var requesterId))
        {
            return Unauthorized();
        }

        var isPatientOwner = requesterId == result.Patient.Id && IsUserType(UserType.Patient);
        var isConsentedDoctor = IsUserType(UserType.Doctor)
            && await consentService.IsAuthorizedAsync(result.Patient.Id, requesterId, "Encounter");
        if (!isPatientOwner && !isConsentedDoctor)
        {
            return Forbid();
        }

        return Ok(result);
    }

    [HttpPost("patient/{patientId:guid}/doctor/{doctorId:guid}/clinic/{clinicId:long}")]
    public async Task<IActionResult> BookMedicalConsultationAsync(CreateMedicalConsultationRequest request,
        Guid patientId, Guid doctorId, long clinicId)
    {
        var command = mapper.Map<CreateMedicalConsultationRequest, CreateMedicalConsultationCommand>(request);
        await medicalConsultationService.BookMedicalConsultationAsync(command, doctorId, patientId, clinicId);
        return Ok(new { message = "Medical consultation booked" });
    }

    [HttpGet("doctor/{doctorId:guid}/clinic/{clinicId:long}")]
    public async Task<PageResult<BasicMedicalConsultationResource>> PageByDoctorIdAndClinicIdAsync(
        [FromQuery] int pageIndex,
        [FromQuery] int pageSize, Guid doctorId,
        long clinicId, [FromQuery] string? searchTerm = "")
    {
        return await medicalConsultationService.PageByDoctorIdAndClinicIdAsync(pageIndex, pageSize, doctorId, clinicId,
            searchTerm!);
    }

    [HttpGet("clinic_administrator/{clinicAdminId:guid}")]
    public async Task<PageResult<BasicMedicalConsultationResource>> PageByClinicAdministratorIdAsync(
        [FromQuery] int pageIndex,
        [FromQuery] int pageSize, [FromRoute] Guid clinicAdminId, [FromQuery] string? searchTerm = "")
    {
        return await medicalConsultationService.PageByClinicAdministratorIdAsync(pageIndex, pageSize, clinicAdminId,
            searchTerm!);
    }

    [HttpGet("patient/{patientId:guid}")]
    [Authorize]
    public async Task<IActionResult> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string? searchTerm = "")
    {
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var requesterId))
        {
            return Unauthorized();
        }

        var isPatientOwner = requesterId == patientId && IsUserType(UserType.Patient);
        var isConsentedDoctor = IsUserType(UserType.Doctor)
            && await consentService.IsAuthorizedAsync(patientId, requesterId, "Encounter");
        if (!isPatientOwner && !isConsentedDoctor)
        {
            return Forbid();
        }

        return Ok(await medicalConsultationService.PageByPatientIdAsync(pageIndex, pageSize, patientId, searchTerm!));
    }

    private bool IsUserType(UserType userType)
    {
        return int.TryParse(User.FindFirstValue("userType"), out var value)
            && value == (int)userType + 1;
    }
}