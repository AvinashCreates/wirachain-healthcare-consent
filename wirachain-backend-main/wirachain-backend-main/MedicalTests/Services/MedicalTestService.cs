using wirachain_backend.MedicalTests.Application.Commands.Create;
using wirachain_backend.MedicalTests.Application.Commands.Update;
using wirachain_backend.MedicalTests.Domain.Facade;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Repositories;
using wirachain_backend.MedicalTests.Domain.Services;
using wirachain_backend.MedicalTests.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalTests.Services;

public class MedicalTestService(
    IMedicalTestRepository medicalTestRepository,
    IMedicalTestClinicRepository medicalTestClinicRepository,
    IMedicalTestFacade medicalTestFacade,
    IUnitOfWork unitOfWork) : IMedicalTestService
{
    public async Task<PageResult<MedicalTest>> PageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        return await medicalTestRepository.PageAsync(pageIndex, pageSize, searchTerm);
    }

    public async Task<MedicalTestResponse> FindAsync(long id)
    {
        var existingMedicalTest = await medicalTestRepository.FindAsync(id);
        if (existingMedicalTest is null)
            throw new KeyNotFoundException("Medical test not found");
        return new MedicalTestResponse(existingMedicalTest);
    }

    public async Task<MedicalTestResponse> AddAsync(CreateMedicalTestCommand command)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            // Building MedicalTest
            var newMedicalTest = medicalTestFacade.BuildMedicalTestFromCommand(command);
            
            await medicalTestRepository.AddAsync(newMedicalTest);
            await unitOfWork.CommitTransactionAsync();
            return new MedicalTestResponse(newMedicalTest);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<MedicalTestResponse> UpdateAsync(long id, UpdateMedicalTestCommand command)
    {
        var existingMedicalTest = await medicalTestRepository.FindAsync(id);
        if (existingMedicalTest is null)
            throw new KeyNotFoundException("Medical test not found");
        
        try
        {
            await unitOfWork.BeginTransactionAsync();
            
            // Updating
            medicalTestFacade.UpdateMedicalTestFromCommand(existingMedicalTest, command);
            medicalTestRepository.Update(existingMedicalTest);
            
            await unitOfWork.CommitTransactionAsync(); 
            return new MedicalTestResponse(existingMedicalTest);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<MedicalTestResponse> RemoveAsync(long id)
    {
        var existingMedicalTest = await medicalTestRepository.FindAsync(id);
        if (existingMedicalTest is null)
            throw new KeyNotFoundException("Medical test not found");
        
        try
        {
            await unitOfWork.BeginTransactionAsync();
            
            // Removing
            medicalTestRepository.Remove(existingMedicalTest);
            
            await unitOfWork.CommitTransactionAsync(); 
            return new MedicalTestResponse(existingMedicalTest);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<IEnumerable<MedicalTest>> ListAllAsync()
    {
        return await medicalTestRepository.ListAllAsync();
    }

    public async Task<IEnumerable<MedicalTest>> ListMedicalTestsByAdministratorIdAsync(Guid administratorId)
    {
        return await medicalTestClinicRepository.ListAllByClinicAdministratorIdAsync(administratorId);
    }

    public async Task<PageResult<MedicalTest>> PageByAdministratorIdAndClinicIdAsync(long clinicId, Guid administratorId, int pageIndex, int pageSize, string searchTerm)
    {
        return await medicalTestClinicRepository.PageByAdministratorIdAndClinicIdAsync(clinicId, administratorId, pageIndex, pageSize, searchTerm);
    }
}