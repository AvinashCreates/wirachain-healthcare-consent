using wirachain_backend.MedicalSpecialties.Application.Commands.Create;
using wirachain_backend.MedicalSpecialties.Application.Commands.Update;
using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.MedicalSpecialties.Domain.Services.Communication;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalSpecialties.Domain.Services;

public interface IMedicalSpecialtyService
{
    Task<MedicalSpecialtyResponse> FindAsync(long id);
    Task<MedicalSpecialtyResponse> AddAsync(CreateMedicalSpecialtyCommand command);
    Task<MedicalSpecialtyResponse> UpdateAsync(long medicalSpecialtyId, UpdateMedicalSpecialtyCommand command);
    Task<MedicalSpecialtyResponse> RemoveAsync(long id);
    Task<PageResult<MedicalSpecialty>> PageAsync(int pageIndex, int pageSize, string searchTerm);
}