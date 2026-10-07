using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Application.Resources.Basic;
using wirachain_backend.MedicalConsultations.Application.Resources.Show;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalConsultations.Domain.Services;

public interface IMedicalConsultationService
{
    Task<MedicalConsultationResource> FindAsync(Guid consultationId);

    Task<MedicalConsultationResponse> BookMedicalConsultationAsync(CreateMedicalConsultationCommand command,
        Guid doctorId, Guid patientId, long clinicId);

    Task<PageResult<BasicMedicalConsultationResource>> PageByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize,
        Guid doctorId, long clinicId, string searchTerm);

    Task<PageResult<BasicMedicalConsultationResource>>
        PageByPatientIdAsync(int pageIndex, int pageSize, Guid patientId, string searchTerm);

    Task<PageResult<BasicMedicalConsultationResource>> PageByClinicAdministratorIdAsync(int pageIndex, int pageSize,
        Guid clinicAdministratorId, string searchTerm);
}