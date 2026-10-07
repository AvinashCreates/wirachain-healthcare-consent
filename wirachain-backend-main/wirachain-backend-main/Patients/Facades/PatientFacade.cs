using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Patients.Application.Commands.Create;
using wirachain_backend.Patients.Application.Commands.Update;
using wirachain_backend.Patients.Domain.Facade;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Integration.Ethereum.Application.Requests;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;
using wirachain_backend.Shared.Integration.Fhir.Adapters;
using wirachain_backend.Shared.Integration.Fhir.Domain.Services;

namespace wirachain_backend.Patients.Facades;

public class PatientFacade(
    IClinicRepository clinicRepository,
    IEventEmitterFactory eventEmitterFactory,
    IPatientClinicPermissionRepository patientClinicPermissionRepository, IFhirPatientService fhirPatientService) : IPatientFacade
{
    public void UpdatePatientFromCommand(Patient existingPatient, UpdatePatientCommand command)
    {
        existingPatient.FirstName = command.FirstName;
        existingPatient.LastName = command.LastName;
        existingPatient.DateOfBirth = command.DateOfBirth;
        existingPatient.Gender = command.Gender;
        existingPatient.Email = command.User.Email;
        existingPatient.UpdatedAt = DateTime.Now;
    }

    public Patient BuildPatientFromCommand(CreatePatientCommand command)
    {
        var newPatient = new Patient
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            DateOfBirth = command.DateOfBirth,
            Gender = command.Gender,
            UpdatedAt = DateTime.Now,
            Email = command.User.Email,
            Phone = command.User.Phone,
            HashedPassword = BCrypt.Net.BCrypt.HashPassword(command.User.Password),
            UserType = UserType.Patient,
        };
        return newPatient;
    }

    public async Task CreateAccessToClinicAsync(Patient patient, long clinicId)
    {
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if (existingClinic is null)
            throw new KeyNotFoundException($"Clinic with id {clinicId} does not exist");

        // var existingClinicPermission = await patientClinicPermissionRepository.

        var existingPatientClinicPermission =
            await patientClinicPermissionRepository.FindClinicPermissionByClinicIdAndPatientIdAsync(clinicId,
                patient.Id);
        // Existing approved permission.
        if (existingPatientClinicPermission is not null)
        {
            switch (existingPatientClinicPermission.PermissionStatus)
            {
                case PermissionStatus.Approved:
                    throw new ApplicationException(
                        $"Permission with clinic ID {clinicId} already exist with approved permission.");
                case PermissionStatus.Pending:
                    throw new ApplicationException(
                        $"Permission with clinic ID {clinicId} already exist with pending permission. Please wait for confirmation.");
            }
        }
        
        
        patient.PatientClinicPermissions.Add(new PatientClinicPermission
        {
            Clinic = existingClinic,
            IsRequired = false, // Just when doctors requires it.
            IsActive = true,
            PermissionStatus = PermissionStatus.Approved
        });
        
        // Emit event to blockchain server.
        IEventEmitter<PermissionRequest> emitter = eventEmitterFactory.Create<PermissionRequest>("GrantPermission");
        await emitter.EmitEventAsync(0, new PermissionRequest
        {
            PatientId = patient.Id,
            ClinicId = existingClinic.Id,
        });
    }

    public async Task GrantAccessToClinicAsync(Guid permissionId)
    {
        var existingPatientClinicPermission =
            await patientClinicPermissionRepository.FindAsync(permissionId);

        if (existingPatientClinicPermission is null)
            throw new KeyNotFoundException($"Permission with id {permissionId} does not exist");
        if (existingPatientClinicPermission.PermissionStatus == PermissionStatus.Pending)
        {
            existingPatientClinicPermission.IsActive = true;
            existingPatientClinicPermission.IsRequired = false;
            existingPatientClinicPermission.PermissionStatus = PermissionStatus.Approved;
        }
    }

    public async Task GrantAccessToClinicAsync(Patient patient, long clinicId)
    {
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if (existingClinic is null)
            throw new KeyNotFoundException($"Clinic with ID {clinicId} does not exist");
        var existingPatientClinicPermission =
            await patientClinicPermissionRepository.FindClinicPermissionByClinicIdAndPatientIdAsync(clinicId,
                patient.Id);
        if (existingPatientClinicPermission is null)
            throw new KeyNotFoundException(
                $"Permission associated with clinic with ID {clinicId} and patient with ID {patient.Id} does not exist");

        existingPatientClinicPermission.IsActive = true;
        existingPatientClinicPermission.IsRequired = false;
        existingPatientClinicPermission.PermissionStatus = PermissionStatus.Approved;
    }

    public async Task RevokeAccessToClinicAsync(Patient patient, long clinicId)
    {
        var existingClient = await clinicRepository.FindAsync(clinicId);
        if (existingClient is null)
            throw new KeyNotFoundException($"Clinic with ID {clinicId} does not exist");
        var existingPatientClinicPermission =
            await patientClinicPermissionRepository.FindClinicPermissionByClinicIdAndPatientIdAsync(clinicId,
                patient.Id);
        if (existingPatientClinicPermission is null)
            throw new KeyNotFoundException(
                $"Permission associated with clinic with ID {clinicId} and patient with ID {patient.Id} does not exist");

        patientClinicPermissionRepository.Remove(existingPatientClinicPermission);
    }

    public async Task CreatePatientFhirAsync(Patient patient)
    {
        await fhirPatientService.CreateAsync(patient.ToFhirPatient());
    }
}