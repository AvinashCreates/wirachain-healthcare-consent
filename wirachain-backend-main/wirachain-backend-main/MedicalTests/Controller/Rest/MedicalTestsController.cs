using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.MedicalTests.Application.Commands.Create;
using wirachain_backend.MedicalTests.Application.Commands.Update;
using wirachain_backend.MedicalTests.Application.Requests.Create;
using wirachain_backend.MedicalTests.Application.Requests.Update;
using wirachain_backend.MedicalTests.Application.Resources.Basic;
using wirachain_backend.MedicalTests.Application.Resources.Show;
using wirachain_backend.MedicalTests.Domain.Services;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalTests.Controller.Rest;

[ApiController]
[Route("api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Medical Tests Controller 🚀")]
public class MedicalTestsController(IMedicalTestService medicalTestService, IMapper mapper) : ControllerBase
{
    [HttpGet("{medicalTestId}")]
    public async Task<IActionResult> GetMedicalTestAsync(long medicalTestId)
    {
        var result = await medicalTestService.FindAsync(medicalTestId);
        return Ok(mapper.Map<MedicalTestResource>(result.Data));
    }

    [HttpGet("page")]
    public async Task<PageResult<BasicMedicalTestResource>> PageMedicalTestsAsync(int pageIndex, int pageSize,
        string? searchTerm = "")
    {
        return mapper.Map<PageResult<BasicMedicalTestResource>>(
            await medicalTestService.PageAsync(pageIndex, pageSize, searchTerm!));
    }

    [HttpPost]
    public async Task<IActionResult> CreateMedicalTestAsync(CreateMedicalTestRequest request)
    {
        var mappedResult = mapper.Map<CreateMedicalTestCommand>(request);
        var result = await medicalTestService.AddAsync(mappedResult);
        return Ok(mapper.Map<BasicMedicalTestResource>(result.Data));
    }

    [HttpPut("{medicalTestId:long}")]
    public async Task<IActionResult> UpdateMedicalTestAsync(long medicalTestId, UpdateMedicalTestRequest request)
    {
        var mappedResult = mapper.Map<UpdateMedicalTestCommand>(request);
        var result = await medicalTestService.UpdateAsync(medicalTestId, mappedResult);
        return Ok(mapper.Map<MedicalTestResource>(result.Data));
    }

    [HttpDelete("{medicalTestId:long}")]
    public async Task<IActionResult> RemoveMedicalTestAsync(long medicalTestId)
    {
        var result = await medicalTestService.RemoveAsync(medicalTestId);
        return Ok(mapper.Map<MedicalTestResource>(result.Data));
    }

    [HttpGet("administrator/{administratorId:guid}")]
    public async Task<IEnumerable<BasicMedicalTestResource>> GetMedicalTestAdministratorAsync(Guid administratorId)
    {
        return mapper.Map<IEnumerable<BasicMedicalTestResource>>(
            await medicalTestService.ListMedicalTestsByAdministratorIdAsync(administratorId));
    }

    [HttpGet]
    public async Task<IEnumerable<MedicalTestResource>> GetMedicalTestListAsync()
    {
        return mapper.Map<IEnumerable<MedicalTestResource>>(await medicalTestService.ListAllAsync());
    }

    [HttpGet("page/clinic/{clinicId:long}/administrator/{administratorId:guid}")]
    public async Task<PageResult<BasicMedicalTestResource>> PageMedicalTestClinicAsync([FromRoute] long clinicId,
        [FromRoute] Guid administratorId, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string? searchTerm = "")
    {
        return mapper.Map<PageResult<BasicMedicalTestResource>>(await medicalTestService.PageByAdministratorIdAndClinicIdAsync(clinicId, administratorId, pageIndex, pageSize, searchTerm));
    }
}