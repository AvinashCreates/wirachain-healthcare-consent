using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Permissions.Repositories;

public class PatientClinicPermissionRepository(AppDbContext context)
    : BaseRepository<PatientClinicPermission, Guid>(context), IPatientClinicPermissionRepository
{
    public async Task<PageResult<Patient>> PagePatientsByClinicIdAsync(int pageIndex, int pageSize, long clinicId,
        string searchTerm)
    {
        var query = DbSet.Where(patientClinic => patientClinic.ClinicId == clinicId)
            .Include(patientClinic => patientClinic.Patient).AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(p => p.Patient).ToListAsync();
        return new PageResult<Patient>
        {
            Count = totalCount,
            Results = items
        };
    }

    public async Task<PageResult<PatientClinicPermission>> PageByPatientIdAsync(int pageIndex, int pageSize,
        Guid patientId, string searchTerm)
    {
        var query = DbSet.Where(patientClinic => patientClinic.PatientId == patientId)
            .Select(pcp => new PatientClinicPermission
            {
                Clinic = new Clinic
                    { Id = pcp.ClinicId, Name = pcp.Clinic.Name, Ruc = pcp.Clinic.Ruc, Address = pcp.Clinic.Address },
                RequiredByDoctor = pcp.RequiredByDoctorId != null
                    ? new Doctor
                    {
                        Id = (Guid)pcp.RequiredByDoctorId!, FirstName = pcp.RequiredByDoctor!.FirstName,
                        LastName = pcp.RequiredByDoctor.LastName
                    }
                    : null,
                Patient = new Patient
                    { Id = pcp.PatientId, FirstName = pcp.Patient.FirstName, LastName = pcp.Patient.LastName },
                IsRequired = pcp.IsRequired,
                IsActive = pcp.IsActive,
                PermissionStatus = pcp.PermissionStatus,
                Id = pcp.Id
            })
            .AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PageResult<PatientClinicPermission>
        {
            Count = totalCount,
            Results = items
        };
    }

    public async Task<PageResult<PatientClinicPermission>> PageByClinicIdAsync(int pageIndex, int pageSize,
        long clinicId, string searchTerm)
    {
        var query = DbSet.Where(patientClinic => patientClinic.ClinicId == clinicId)
            .Select(pcp => new PatientClinicPermission
            {
                Clinic = new Clinic
                    { Id = pcp.ClinicId, Name = pcp.Clinic.Name, Ruc = pcp.Clinic.Ruc, Address = pcp.Clinic.Address },
                RequiredByDoctor = pcp.RequiredByDoctorId != null
                    ? new Doctor
                    {
                        Id = (Guid)pcp.RequiredByDoctorId!, FirstName = pcp.RequiredByDoctor!.FirstName,
                        LastName = pcp.RequiredByDoctor.LastName
                    }
                    : null,
                Patient = new Patient
                    { Id = pcp.PatientId, FirstName = pcp.Patient.FirstName, LastName = pcp.Patient.LastName },
                IsRequired = pcp.IsRequired,
                IsActive = pcp.IsActive,
                PermissionStatus = pcp.PermissionStatus,
                Id = pcp.Id
            }).AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PageResult<PatientClinicPermission>
        {
            Count = totalCount,
            Results = items
        };
    }


    public async Task<PatientClinicPermission?> FindClinicPermissionByClinicIdAndPatientIdAsync(long clinicId,
        Guid patientId)
    {
        return await DbSet.Where(pcp => pcp.PatientId == patientId && pcp.ClinicId == clinicId).FirstOrDefaultAsync();
    }

    public async Task<PatientClinicPermission?> FindClinicPermissionByClinicIdAsync(long clinicId)
    {
        return await DbSet.Where(pcp => pcp.ClinicId == clinicId).FirstOrDefaultAsync();
    }


    public async Task<PageResult<PatientClinicPermission>> PageByPermissionStatusAsync(
        PermissionStatus permissionStatus)
    {
        var query = DbSet.Where(pcp => pcp.PermissionStatus == permissionStatus).AsQueryable();
        var totalCount = await query.CountAsync();
        var items = await query.OrderByDescending(pc => pc.PermissionStatus).ToListAsync();
        return new PageResult<PatientClinicPermission>
        {
            Count = totalCount,
            Results = items
        };
    }
}