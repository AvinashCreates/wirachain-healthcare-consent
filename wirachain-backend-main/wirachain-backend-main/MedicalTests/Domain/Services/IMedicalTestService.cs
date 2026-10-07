using wirachain_backend.MedicalTests.Application.Commands.Create;
using wirachain_backend.MedicalTests.Application.Commands.Update;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalTests.Domain.Services;

public interface IMedicalTestService
{
    Task<IEnumerable<MedicalTest>> ListAllAsync();
    Task<PageResult<MedicalTest>> PageAsync(int pageIndex, int pageSize, string searchTerm);
    Task<MedicalTestResponse> FindAsync(long id);
    Task<MedicalTestResponse> AddAsync(CreateMedicalTestCommand command);
    Task<MedicalTestResponse> UpdateAsync(long id, UpdateMedicalTestCommand command);
    Task<MedicalTestResponse> RemoveAsync(long id);
    Task<IEnumerable<MedicalTest>> ListMedicalTestsByAdministratorIdAsync(Guid administratorId);
    Task<PageResult<MedicalTest>> PageByAdministratorIdAndClinicIdAsync(long clinicId, Guid administratorId, int pageIndex, int pageSize, string searchTerm);
}