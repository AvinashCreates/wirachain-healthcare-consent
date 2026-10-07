using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using wirachain_backend.Permissions.Application.Requests.Patch;
using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Shared.Domain.Services;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Service;

namespace wirachain_backend.Permissions.Api.Rest.Controllers;

[ApiController]
[Route("api/v0/[controller]")]
[SwaggerTag("Patient Clinic Permissions")]
public class PatientClinicPermissionsController(
    IPatientClinicPermissionService patientClinicPermissionService,
    IEthereumService ethereumService)
    : ControllerBase
{
    [HttpGet("page/clinic/{clinicId:long}")]
    public async Task<PageResult<PatientClinicPermissionResource>> PageByClinicIdAsync([FromQuery] int pageIndex,
        [FromQuery] int pageSize,
        long clinicId, [FromQuery] string searchTerm = "")
    {
        return await patientClinicPermissionService.PageByClinicIdAsync(pageIndex, pageSize, clinicId, searchTerm);
    }

    [HttpGet("page/patient/{patientId:guid}")]
    public async Task<PageResult<PatientClinicPermissionResource>> PageByPatientIdAsync([FromQuery] int pageIndex,
        [FromQuery] int pageSize,
        Guid patientId, [FromQuery] string searchTerm = "")
    {
        return await patientClinicPermissionService.PageByPatientIdAsync(pageIndex, pageSize, patientId, searchTerm);
    }

    [HttpPatch("{patientId:guid}/clinic/{clinicId:long}/permission-status")]
    public async Task<IActionResult> PatchPermissionStatusByPatientIdAndClinicIdAsync([FromRoute] Guid patientId,
        [FromRoute] long clinicId,
        PatchPermissionStatusRequest request)
    {
        await patientClinicPermissionService.PatchPatientClinicPermissionStatusByPatientIdAndClinicIdAsync(patientId,
            clinicId, request.PermissionStatus);
        return Ok(new { message = "Updated permission status" });
    }

    [HttpPatch("{permissionId:guid}/permission-status")]
    public async Task<IActionResult> PatchPermissionStatusAsync([FromRoute] Guid permissionId,
        PatchPermissionStatusRequest request)
    {
        await patientClinicPermissionService.PatchPatientClinicPermissionStatusByIdAsync(permissionId,
            request.PermissionStatus);
        return Ok(new { message = "Updated permission status" });
    }

    [HttpGet("ethereum/{contractName}")]
    public async Task<IActionResult> GetEthereumAsync(string contractName)
    {
        return Ok(await ethereumService.GetContractByName(contractName));
    }
}