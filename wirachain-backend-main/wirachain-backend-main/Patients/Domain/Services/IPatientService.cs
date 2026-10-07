using wirachain_backend.Patients.Application.Commands.Create;
using wirachain_backend.Patients.Application.Commands.Update;
using wirachain_backend.Patients.Application.Resources.Basic;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Patients.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Patients.Domain.Services;

public interface IPatientService
{
    Task<PageResult<Patient>> PageBySearchTermAsync(int pageIndex, int pageSize, string searchTerm);
    Task<PatientResponse> FindAsync(Guid id);
    Task<PatientResponse> AddAsync(CreatePatientCommand command);
    Task<PatientResponse> UpdateAsync(Guid id, UpdatePatientCommand command);
    Task<PatientResponse> RemoveAsync(Guid id);
    Task<PageResult<Patient>> PageByClinicIdAsync(int pageIndex, int pageSize, long clinicId ,string searchTerm);
    Task<PageResult<BasicPatientResource>> PageByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize, long clinicId, Guid doctorId ,string searchTerm);
    Task<PatientResponse> CreateAccessToClinicAsync(Guid patientId, long clinicId);
    Task<PatientResponse> GrantAccessToClinicAsync(Guid patientId, long clinicId);
    Task<PatientResponse> RevokeAccessToClinicAsync(Guid patientId, long clinicId);
    Task<PageResult<BasicPatientResource>> PageQueryAsync(int pageIndex, int pageSize, string? searchTerm, Guid? doctorId, long? clinicId);
}