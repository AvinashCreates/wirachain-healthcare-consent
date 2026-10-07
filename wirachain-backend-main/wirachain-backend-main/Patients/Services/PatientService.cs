using AutoMapper;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.MedicalConsultations.Domain.Repositories;
using wirachain_backend.Patients.Application.Commands.Create;
using wirachain_backend.Patients.Application.Commands.Update;
using wirachain_backend.Patients.Application.Resources.Basic;
using wirachain_backend.Patients.Domain.Facade;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Patients.Domain.Repositories;
using wirachain_backend.Patients.Domain.Services;
using wirachain_backend.Patients.Domain.Services.Communication;
using wirachain_backend.Patients.Repositories;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Patients.Services;

public class PatientService(
    IMedicalConsultationRepository medicalConsultationRepository,
    IPatientRepository patientRepository,
    IPatientClinicPermissionRepository patientClinicPermissionRepository,
    IPatientFacade patientFacade,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IPatientService
{
    public async Task<PageResult<Patient>> PageBySearchTermAsync(int pageIndex, int pageSize, string searchTerm)
    {
        return await patientRepository.PageAsync(pageIndex, pageSize, searchTerm);
    }

    public async Task<PatientResponse> FindAsync(Guid id)
    {
        var existingPatient = await patientRepository.FindAsync(id);
        if (existingPatient == null)
            throw new KeyNotFoundException("Patient not found");
        return new PatientResponse(existingPatient);
    }

    public async Task<PatientResponse> AddAsync(CreatePatientCommand command)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            // Building Patient
            var newPatient = patientFacade.BuildPatientFromCommand(command);

            await patientRepository.AddAsync(newPatient);
            await patientFacade.CreatePatientFhirAsync(newPatient);
            
            await unitOfWork.CommitTransactionAsync();
            return new PatientResponse(newPatient);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PatientResponse> UpdateAsync(Guid id, UpdatePatientCommand command)
    {
        var existingPatient = await patientRepository.FindAsync(id);
        if (existingPatient == null)
            throw new KeyNotFoundException("Patient not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();

            // Updating Patient
            patientFacade.UpdatePatientFromCommand(existingPatient, command);
            // existingPatient.FirstName = command.FirstName;

            patientRepository.Update(existingPatient);
            await unitOfWork.CommitTransactionAsync();
            return new PatientResponse(existingPatient);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PatientResponse> RemoveAsync(Guid id)
    {
        var existingPatient = await patientRepository.FindAsync(id);
        if (existingPatient == null)
            throw new KeyNotFoundException("Patient not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            patientRepository.Remove(existingPatient);
            await unitOfWork.CommitTransactionAsync();
            return new PatientResponse(existingPatient);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PageResult<Patient>> PageByClinicIdAsync(int pageIndex, int pageSize, long clinicId,
        string searchTerm)
    {
        return await patientClinicPermissionRepository.PagePatientsByClinicIdAsync(pageIndex, pageSize, clinicId, searchTerm);
    }

    public async Task<PageResult<BasicPatientResource>> PageByDoctorIdAndClinicIdAsync(int pageIndex, int pageSize, long clinicId, Guid doctorId, string searchTerm)
    {
        return mapper.Map<PageResult<BasicPatientResource>>(await medicalConsultationRepository.PageQueryAsync(pageIndex, pageSize, searchTerm, doctorId, clinicId));
    }

    public async Task<PatientResponse> CreateAccessToClinicAsync(Guid patientId, long clinicId)
    {
        var exitingPatient = await patientRepository.FindAsync(patientId);
        if (exitingPatient is null)
            throw new KeyNotFoundException("Patient not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            await patientFacade.CreateAccessToClinicAsync(exitingPatient, clinicId);
            await unitOfWork.CommitTransactionAsync();
            return new PatientResponse(exitingPatient);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PatientResponse> GrantAccessToClinicAsync(Guid patientId, long clinicId)
    {
        var exitingPatient = await patientRepository.FindAsync(patientId);
        if (exitingPatient is null)
            throw new KeyNotFoundException("Patient not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            await patientFacade.GrantAccessToClinicAsync(exitingPatient, clinicId);
            await unitOfWork.CommitTransactionAsync();
            return new PatientResponse(exitingPatient);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PatientResponse> RevokeAccessToClinicAsync(Guid patientId, long clinicId)
    {
        var exitingPatient = await patientRepository.FindAsync(patientId);
        if (exitingPatient is null)
            throw new KeyNotFoundException("Patient not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            await patientFacade.RevokeAccessToClinicAsync(exitingPatient, clinicId);
            await unitOfWork.CommitTransactionAsync();
            return new PatientResponse(exitingPatient);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PageResult<BasicPatientResource>> PageQueryAsync(int pageIndex, int pageSize, string? searchTerm, Guid? doctorId, long? clinicId)
    {
        return mapper.Map<PageResult<BasicPatientResource>>(await medicalConsultationRepository.PageQueryAsync(pageIndex, pageSize, searchTerm, doctorId, clinicId));
    }
}