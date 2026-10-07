using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Application.Requests.Create;
using wirachain_backend.MedicalConsultations.Application.Resources.Basic;
using wirachain_backend.MedicalConsultations.Domain.Services;
using wirachain_backend.MedicalConsultations.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalConsultations.Api.Rest.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Medical consultations 🚀")]
public class MedicalConsultationsController(IMedicalConsultationService medicalConsultationService, IMapper mapper)
    : ControllerBase
{
    [HttpGet("{consultationId:guid}")]
    public async Task<IActionResult> FindMedicalConsultationAsync(Guid consultationId)
    {
        var result = await medicalConsultationService.FindAsync(consultationId);
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
    public async Task<PageResult<BasicMedicalConsultationResource>> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string? searchTerm = "")
    {
        return await medicalConsultationService.PageByPatientIdAsync(pageIndex, pageSize, patientId, searchTerm!);
    }
}