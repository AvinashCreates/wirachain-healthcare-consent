using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Commands.Update;
using wirachain_backend.Clinics.Application.Requests.Create;
using wirachain_backend.Clinics.Application.Requests.Update;
using wirachain_backend.Clinics.Application.Resources.Show;
using wirachain_backend.Clinics.Application.ViewModels;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Services;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Controllers.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD Clinics")]
public class ClinicsController : ControllerBase
{
    private readonly IClinicService _clinicService;
    private readonly IMapper _mapper;

    public ClinicsController(IClinicService clinicService, IMapper mapper)
    {
        _clinicService = clinicService;
        _mapper = mapper;
    }

    [HttpGet("page")]
    public async Task<PageResult<ClinicResource>> ListByPageAsync([FromQuery] int pageIndex, [FromQuery] int pageSize,
        [FromQuery] string? searchTerm = "")
    {
        return _mapper.Map<PageResult<ClinicResource>>(
            await _clinicService.ListByPageAsync(pageIndex, pageSize, searchTerm!));
    }

    [HttpGet("page/admin/{adminId:guid}")]
    public async Task<PageResult<ClinicResource>> PageByAdminIdAsync([FromQuery] int pageIndex,
        [FromQuery] int pageSize, Guid adminId, string? searchTerm = "")
    {
        return _mapper.Map<PageResult<ClinicResource>>(
            await _clinicService.PageByAdminIdAsync(pageIndex, pageSize, searchTerm!, adminId));
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetClinicById([FromRoute] long id)
    {
        var result = await _clinicService.FindAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(_mapper.Map<Clinic, ClinicResource>(result.Data!));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClinicById([FromBody] CreateClinicRequest createClinic)
    {
        var mappedClinic = _mapper.Map<CreateClinicCommand>(createClinic);
        var result = await _clinicService.AddAsync(mappedClinic);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(_mapper.Map<Clinic, ClinicResource>(result.Data!));
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateClinicById([FromRoute] long id,
        [FromBody] UpdateClinicRequest updatedClinic)
    {
        var mappedClinic = _mapper.Map<UpdateClinicCommand>(updatedClinic);
        var result = await _clinicService.UpdateAsync(id, mappedClinic);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(_mapper.Map<Clinic, ClinicResource>(result.Data!));
    }

    [HttpPost("{clinicId:long}/patient/{patientId:guid}")]
    public async Task<IActionResult> AssignPatientToClinic(long clinicId, Guid patientId)
    {
        await _clinicService.AssignPatientToClinicAsync(clinicId, patientId);
        return Ok(new { Message = "Patient assigned to clinic." });
    }

    [HttpGet("patient/{patientId:guid}")]
    public async Task<PageResult<ClinicsWithStatusViewModel>> GetClinicById([FromQuery] int pageIndex, int pageSize,
        [FromRoute] Guid patientId, string? searchTerm = "")
    {
        return await _clinicService.PageByPatientIdAsync(pageIndex, pageSize, patientId, searchTerm!);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> RemoveClinicById([FromRoute] long id)
    {
        var result = await _clinicService.RemoveAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(_mapper.Map<Clinic, ClinicResource>(result.Data!));
    }
}