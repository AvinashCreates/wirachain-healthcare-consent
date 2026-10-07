using wirachain_backend.Auth.Application.Requests.Patch;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Clinics.Domain.Services;
using wirachain_backend.Clinics.Domain.Services.Communication;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Clinics.Application.Commands;
using wirachain_backend.Clinics.Application.Commands.Create;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Services;

public class ClinicAdministratorService(
    IUnitOfWork unitOfWork,
    IClinicAdministratorRepository clinicAdministratorRepository)
    : IClinicAdministratorService
{
    public async Task<PageResult<ClinicAdministrator>> PageAsync(int pageIndex, int pageSize,
        string? searchTerm = "")
    {
        return await clinicAdministratorRepository.ListByPageAsync(pageIndex, pageSize, searchTerm!);
    }

    public async Task<ClinicAdministratorResponse> FindAsync(Guid id)
    {
        var existingAdmin = await clinicAdministratorRepository.FindAsync(id);
        if (existingAdmin == null)
            return new ClinicAdministratorResponse("Admin not found");
        return new ClinicAdministratorResponse(existingAdmin);
    }

    public async Task<ClinicAdministratorResponse> RemoveAsync(Guid id)
    {
        try
        {
            var existingAdmin = await clinicAdministratorRepository.FindAsync(id);
            if (existingAdmin == null)
                throw new ApplicationException("Admin not found");

            await unitOfWork.BeginTransactionAsync();

            clinicAdministratorRepository.Remove(existingAdmin);

            await unitOfWork.CommitTransactionAsync();
            return new ClinicAdministratorResponse(existingAdmin);
        }
        catch (Exception e)
        {
            return new ClinicAdministratorResponse(e.Message);
        }
    }

    public async Task<ClinicAdministratorResponse> AddAsync(CreateClinicAdministratorCommand admin)
    {
        try
        {
            var existingAdmin = await clinicAdministratorRepository.FindByEmailAsync(admin.User.Email);
            if (existingAdmin != null)
                throw new ApplicationException("Admin with this email already exists");

            await unitOfWork.BeginTransactionAsync();

            // Generating New Admin
            var newAdmin = new ClinicAdministrator
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Gender = admin.Gender,
                DateOfBirth = admin.DateOfBirth,
                Email = admin.User.Email,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(admin.User.Password),
                Phone = admin.User.Phone,
                UserType = UserType.ClinicAdministrator,
            };

            await clinicAdministratorRepository.AddAsync(newAdmin);

            await unitOfWork.CommitTransactionAsync();
            return new ClinicAdministratorResponse(newAdmin);
        }
        catch (Exception e)
        {
            return new ClinicAdministratorResponse(e.Message);
        }
    }

    public async Task<ClinicAdministratorResponse> UpdateAsync(Guid id, ClinicAdministrator admin)
    {
        try
        {
            var existingAdmin = await clinicAdministratorRepository.FindAsync(id);
            if (existingAdmin == null)
                throw new KeyNotFoundException("Doctor not found");

            existingAdmin.Email = admin.Email;
            existingAdmin.FirstName = admin.FirstName;
            existingAdmin.LastName = admin.LastName;
            existingAdmin.UpdatedAt = DateTime.Now;
            existingAdmin.Gender = admin.Gender;

            await unitOfWork.BeginTransactionAsync();

            clinicAdministratorRepository.Update(existingAdmin);

            await unitOfWork.CommitTransactionAsync();
            return new ClinicAdministratorResponse(existingAdmin);
        }
        catch (Exception e)
        {
            return new ClinicAdministratorResponse(e.Message);
        }
    }

    public async Task ChangePasswordAsync(Guid id, PatchPasswordRequest patchPasswordRequest)
    {
        var existingAdmin = await clinicAdministratorRepository.FindAsync(id);
        if (existingAdmin == null)
            throw new KeyNotFoundException("Admin not found");
        try
        {
            await unitOfWork.BeginTransactionAsync();
            existingAdmin.HashedPassword = BCrypt.Net.BCrypt.HashPassword(patchPasswordRequest.Password);
            await unitOfWork.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await unitOfWork.RollbackTrasactionAsync();
            throw new ApplicationException($"Changes have not been saved. An error has occurred: {e.Message}");
        }
    }
}