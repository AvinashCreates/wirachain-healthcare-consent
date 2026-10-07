using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Commands.Update;
using wirachain_backend.Clinics.Domain.Models;

namespace wirachain_backend.Clinics.Domain.Facade;

public interface IClinicFacade
{
    void UpdateClinicFromCommand(Clinic clinic, UpdateClinicCommand command);
    Clinic BuildClinicFromCommand(CreateClinicCommand clinic);
    Task AddMedicalTestsAsync(Clinic clinic, IList<long> medicalTestIds);
    Task ReplaceMedicalTestsAsync(Clinic clinic, IList<long> medicalTestIds);
    Task AssignAdministrator(Clinic clinic, Guid administratorId);
    Task AssignPatientToClinicAsync(Clinic clinic, Guid patientId);
}