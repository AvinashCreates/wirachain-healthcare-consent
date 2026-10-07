using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Clinics.Application.Commands.Update;
using wirachain_backend.Clinics.Application.ViewModels;
using wirachain_backend.Clinics.Domain.Facade;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Clinics.Domain.Services;
using wirachain_backend.Clinics.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;
using wirachain_backend.Shared.Extensions.Exceptions;

namespace wirachain_backend.Clinics.Services;

public class ClinicService(IClinicRepository clinicRepository, IUnitOfWork unitOfWork, IClinicFacade clinicFacade)
    : IClinicService
{
    public async Task<ClinicResponse> FindAsync(long id)
    {
        var existingClinic = await clinicRepository.FindAsync(id);
        if (existingClinic is null)
            return new ClinicResponse("Clinic not found");
        return new ClinicResponse(existingClinic);
    }

    public async Task<ClinicResponse> RemoveAsync(long id)
    {
        try
        {
            var existingClinic = await clinicRepository.FindAsync(id);
            if (existingClinic is null)
                throw new KeyNotFoundException("Clinic not found");

            await unitOfWork.BeginTransactionAsync();
            clinicRepository.Remove(existingClinic);
            await unitOfWork.CommitTransactionAsync();
            return new ClinicResponse(existingClinic);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<ClinicResponse> AddAsync(CreateClinicCommand command)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();
            var newClinic = clinicFacade.BuildClinicFromCommand(command);
            await clinicFacade.AssignAdministrator(newClinic, command.AdministratorId);
            await clinicFacade.AddMedicalTestsAsync(newClinic, command.MedicalTestIds);
            await clinicRepository.AddAsync(newClinic);
            await unitOfWork.CommitTransactionAsync();
            return new ClinicResponse(newClinic);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<ClinicResponse> UpdateAsync(long id, UpdateClinicCommand updateClinic)
    {
        try
        {
            var existingClinic = await clinicRepository.FindAsync(id);
            if (existingClinic is null)
                throw new KeyNotFoundException("Clinic not found");
            await unitOfWork.BeginTransactionAsync();

            // Updating
            existingClinic.Address = updateClinic.Address;
            existingClinic.Name = updateClinic.Name;
            existingClinic.Ruc = updateClinic.Ruc;

            await clinicFacade.ReplaceMedicalTestsAsync(existingClinic, updateClinic.MedicalTestIds);

            // clinicRepository.Update(existingClinic);
            await unitOfWork.CommitTransactionAsync();
            return new ClinicResponse(existingClinic);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PageResult<Clinic>> ListByPageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        return await clinicRepository.ListByPageAsync(pageIndex, pageSize, searchTerm);
    }

    public async Task<PageResult<Clinic>> PageByAdminIdAsync(int pageIndex, int pageSize, string searchTerm,
        Guid adminId)
    {
        return await clinicRepository.PageByAdminIdAsync(pageIndex, pageSize, searchTerm, adminId);
    }

    public async Task AssignPatientToClinicAsync(long clinicId, Guid patientId)
    {
        var existingClinic = await clinicRepository.FindAsync(clinicId);
        if (existingClinic is null)
            throw new KeyNotFoundException("Clinic not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            await clinicFacade.AssignPatientToClinicAsync(existingClinic, patientId);
            await unitOfWork.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PageResult<ClinicsWithStatusViewModel>> PageByPatientIdAsync(int page, int pageSize, Guid patientId, string searchTerm)
    {
        return await clinicRepository.PageByPatientIdAsync(page, pageSize, patientId, searchTerm);
    }
    
}