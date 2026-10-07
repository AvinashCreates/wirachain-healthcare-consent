using wirachain_backend.Patients.Application.Commands.Create;
using wirachain_backend.Patients.Application.Commands.Update;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Patients.Domain.Facade;

public interface IPatientFacade
{
    void UpdatePatientFromCommand(Patient existingPatient, UpdatePatientCommand command);
    Patient BuildPatientFromCommand(CreatePatientCommand command);
    Task CreateAccessToClinicAsync(Patient patient, long clinicId);
    Task GrantAccessToClinicAsync(Guid permissionId);
    Task GrantAccessToClinicAsync(Patient patient, long clinicId);
    Task RevokeAccessToClinicAsync(Patient patient, long clinicId);
    Task CreatePatientFhirAsync(Patient patient);
    
}