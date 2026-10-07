using wirachain_backend.MedicalConsultations.Application.Commands;
using wirachain_backend.MedicalConsultations.Application.Commands.Create;
using wirachain_backend.MedicalConsultations.Application.Requests.Create;
using wirachain_backend.MedicalConsultations.Domain.Models;

namespace wirachain_backend.MedicalConsultations.Domain.Facades;

public interface IMedicalConsultationFacade
{
    MedicalConsultation BuildMedicalConsultationFromCommand(CreateMedicalConsultationCommand command);
    Task BookMedicalConsultationAsync(MedicalConsultation medicalConsultation, Guid doctorId, Guid patientId,
        long clinicId);

    Task AddAdditionalMedicalTests(MedicalConsultation medicalConsultation, IList<long> medicalTestIds);
}