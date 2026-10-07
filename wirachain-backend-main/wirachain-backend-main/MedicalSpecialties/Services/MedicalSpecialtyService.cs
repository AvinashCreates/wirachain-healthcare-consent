using wirachain_backend.MedicalSpecialties.Application.Commands.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Update;
using wirachain_backend.MedicalSpecialties.Domain.Facades;
using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.MedicalSpecialties.Domain.Repositories;
using wirachain_backend.MedicalSpecialties.Domain.Services;
using wirachain_backend.MedicalSpecialties.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalSpecialties.Services;

public class MedicalSpecialtyService(
    IMedicalSpecialtyRepository medicalSpecialtyRepository,
    IMedicalSpecialtyFacade medicalSpecialtyFacade,
    IUnitOfWork unitOfWork) : IMedicalSpecialtyService
{
    public async Task<MedicalSpecialtyResponse> FindAsync(long id)
    {
        var existingMedicalSpecialty = await medicalSpecialtyRepository.FindAsync(id);
        if(existingMedicalSpecialty is null)
            throw new KeyNotFoundException("MedicalSpecialty not found");
        return new MedicalSpecialtyResponse(existingMedicalSpecialty);
    }

    public async Task<MedicalSpecialtyResponse> AddAsync(CreateMedicalSpecialtyCommand command)
    {
        try
        {
            await unitOfWork.BeginTransactionAsync();

            var newMedicalSpecialty = medicalSpecialtyFacade.BuildMedicalSpecialtyFromCommand(command);
            await medicalSpecialtyRepository.AddAsync(newMedicalSpecialty);
            
            await unitOfWork.CommitTransactionAsync();
            return new MedicalSpecialtyResponse(newMedicalSpecialty);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<MedicalSpecialtyResponse> UpdateAsync(long medicalSpecialtyId, UpdateMedicalSpecialtyCommand medicalSpecialty)
    {
        var existingMedicalSpecialty = await medicalSpecialtyRepository.FindAsync(medicalSpecialtyId);
        if(existingMedicalSpecialty is null)
            throw new KeyNotFoundException("MedicalSpecialty not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            medicalSpecialtyFacade.UpdateMedicalSpecialtyFromCommand(existingMedicalSpecialty, medicalSpecialty);
            medicalSpecialtyRepository.Update(existingMedicalSpecialty);
            await unitOfWork.CommitTransactionAsync();
            return new MedicalSpecialtyResponse(existingMedicalSpecialty);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<MedicalSpecialtyResponse> RemoveAsync(long medicalSpecialtyId)
    {
        var existingMedicalSpecialty = await medicalSpecialtyRepository.FindAsync(medicalSpecialtyId);
        if(existingMedicalSpecialty is null)
            throw new KeyNotFoundException("MedicalSpecialty not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            medicalSpecialtyRepository.Remove(existingMedicalSpecialty); 
            await unitOfWork.CommitTransactionAsync();
            return new MedicalSpecialtyResponse(existingMedicalSpecialty);
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException(e.Message);
        }
    }

    public async Task<PageResult<MedicalSpecialty>> PageAsync(int pageIndex, int pageSize, string searchTerm)
    {
        return await medicalSpecialtyRepository.PageAsync(pageIndex, pageSize, searchTerm);
    }
}