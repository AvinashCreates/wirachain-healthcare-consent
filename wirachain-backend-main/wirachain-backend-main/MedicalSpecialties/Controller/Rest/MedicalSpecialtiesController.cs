using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.MedicalSpecialties.Application.Commands.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Update;
using wirachain_backend.MedicalSpecialties.Application.Requests.Create;
using wirachain_backend.MedicalSpecialties.Application.Requests.Update;
using wirachain_backend.MedicalSpecialties.Application.Resources.Show;
using wirachain_backend.MedicalSpecialties.Domain.Services;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalSpecialties.Controller.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Medical Specialties Controller 🚀")]
public class MedicalSpecialtiesController(IMedicalSpecialtyService medicalSpecialtyService, IMapper mapper) : ControllerBase
{
    [HttpGet("{medicalSpecialtyId:long}")]
    public async Task<IActionResult> GetMedicalSpecialtyAsync(long medicalSpecialtyId)
    {
        var result = await medicalSpecialtyService.FindAsync(medicalSpecialtyId);
        return Ok(mapper.Map<MedicalSpecialtyResource>(result.Data));
    }

    [HttpGet("page")]
    public async Task<PageResult<MedicalSpecialtyResource>> PageMedicalSpecialtiesAsync(int pageIndex, int pageSize, string? searchTerm = "")
    {
        return mapper.Map<PageResult<MedicalSpecialtyResource>>(await medicalSpecialtyService.PageAsync(pageIndex, pageSize, searchTerm!));
    }

    [HttpPost]
    public async Task<IActionResult> CreateMedicalSpecialtyAsync([FromBody] CreateMedicalSpecialtyRequest request)
    {
        var mappedResult = mapper.Map<CreateMedicalSpecialtyCommand>(request);
        var result = await medicalSpecialtyService.AddAsync(mappedResult);
        return Ok(mapper.Map<MedicalSpecialtyResource>(result.Data)); 
    }

    [HttpPut("{medicalSpecialtyId:long}")]
    public async Task<IActionResult> UpdateMedicalSpecialistAsync(long medicalSpecialtyId, [FromBody] UpdateMedicalSpecialtyRequest request)
    {
        var mappedResult = mapper.Map<UpdateMedicalSpecialtyCommand>(request);
        var result = await medicalSpecialtyService.UpdateAsync(medicalSpecialtyId, mappedResult);
        return Ok(mapper.Map<MedicalSpecialtyResource>(result.Data));
    }
    
    [HttpDelete("{medicalSpecialtyId:long}")]
    public async Task<IActionResult> RemoveMedicalSpecialistAsync(long medicalSpecialtyId)
    {
        var result = await medicalSpecialtyService.RemoveAsync(medicalSpecialtyId);
        return Ok(mapper.Map<MedicalSpecialtyResource>(result.Data));
    }

}