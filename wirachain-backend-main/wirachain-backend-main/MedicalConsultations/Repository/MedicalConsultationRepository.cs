using Microsoft.EntityFrameworkCore;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Repositories;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.MedicalConsultations.Repository;

public class MedicalConsultationRepository(AppDbContext context)
    : BaseRepository<MedicalConsultation, Guid>(context), IMedicalConsultationRepository
{
    public override async Task<MedicalConsultation?> FindAsync(Guid id)
    {
        return await DbSet.Where(consultation => consultation.Id == id)
            .Include(consultation => consultation.Patient)
            .Include(c => c.Clinic)
            .Include(c => c.DoctorInCharge)
            .FirstOrDefaultAsync();
    }

    public async Task<PageResult<MedicalConsultation>> PageByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize,
        Guid doctorId, long clinicId, string searchTerm)
    {
        var query = DbSet
            .Where(consultation => consultation.DoctorInChargeId == doctorId && consultation.ClinicId == clinicId &&
                                   (consultation.Patient.FirstName.ToLower().StartsWith(searchTerm) ||
                                    consultation.Patient.LastName.ToLower().StartsWith(searchTerm) ||
                                    consultation.DoctorInCharge.FirstName.ToLower().StartsWith(searchTerm) ||
                                    consultation.DoctorInCharge.LastName.ToLower().StartsWith(searchTerm) ||
                                    consultation.Clinic.Name.ToLower().StartsWith(searchTerm))
            )
            .OrderByDescending(consultation => consultation.CheckInDateTime)
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PageResult<MedicalConsultation>
        {
            Count = totalCount,
            Results = items
        };
    }

    public async Task<PageResult<MedicalConsultation>> PageByPatientIdAsync(int pageIndex, int pageSize, Guid patientId,
        string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();
        var query = DbSet
            .Where(consultation => consultation.PatientId == patientId &&
                                   (consultation.Patient.FirstName.ToLower().StartsWith(lowerSearchTerm) ||
                                    consultation.Patient.LastName.ToLower().StartsWith(lowerSearchTerm) ||
                                    consultation.DoctorInCharge.FirstName.ToLower().StartsWith(lowerSearchTerm) ||
                                    consultation.DoctorInCharge.LastName.ToLower().StartsWith(lowerSearchTerm) ||
                                    consultation.Clinic.Name.ToLower().StartsWith(lowerSearchTerm))
            )
            .OrderByDescending(consultation => consultation.CheckInDateTime)
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PageResult<MedicalConsultation>
        {
            Count = totalCount,
            Results = items
        };
    }

    public async Task<PageResult<Patient>> PagePatientsByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize,
        Guid doctorId, long clinicId,
        string searchTerm)
    {
        var query = DbSet.Where(consultation =>
                consultation.DoctorInChargeId == doctorId && consultation.ClinicId == clinicId)
            .Include(c => c.Patient)
            .Where(c => c.Patient.FirstName.ToLower().StartsWith(searchTerm.ToLower()) ||
                        c.Patient.LastName.ToLower().StartsWith(searchTerm.ToLower()))
            .Select(consultation => consultation.Patient)
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PageResult<Patient>
        {
            Results = items,
            Count = totalCount
        };
    }

    public async Task<PageResult<Patient>> PageQueryAsync(int pageIndex, int pageSize, string searchTerm,
        Guid? doctorId, long? clinicId)
    {
        var query = DbSet
            .Where(consultation => (doctorId == null || consultation.DoctorInChargeId == doctorId) &&
                                   (clinicId == null || consultation.ClinicId == clinicId))
            .Include(c => c.Patient)
            .Where(c => c.Patient.FirstName.ToLower().StartsWith(searchTerm.ToLower()) ||
                        c.Patient.LastName.ToLower().StartsWith(searchTerm.ToLower()))
            .Select(consultation => consultation.Patient)
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PageResult<Patient>
        {
            Results = items,
            Count = totalCount
        };
    }

    public async Task<PageResult<MedicalConsultation>> PageByClinicAdministratorIdAsync(int pageIndex, int pageSize,
        Guid clinicAdministratorId, string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();
        var query = DbSet.Include(consultation => consultation.Clinic).Where(consultation =>
                consultation.Clinic.AdministratorId == clinicAdministratorId &&
                (consultation.Patient.FirstName.ToLower().StartsWith(lowerSearchTerm) ||
                 consultation.Patient.LastName.ToLower().StartsWith(lowerSearchTerm) ||
                 consultation.DoctorInCharge.FirstName.ToLower().StartsWith(lowerSearchTerm) ||
                 consultation.DoctorInCharge.LastName.ToLower().StartsWith(lowerSearchTerm) ||
                 consultation.Clinic.Name.ToLower().StartsWith(lowerSearchTerm)))
            .AsQueryable();

        var totalCount = await query.CountAsync();
        var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PageResult<MedicalConsultation>
        {
            Count = totalCount,
            Results = items
        };
    }
}