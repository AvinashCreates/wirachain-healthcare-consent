using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalSpecialties.Domain.Services.Communication;

public class MedicalSpecialtyResponse : BaseResponse<MedicalSpecialty>
{
    public MedicalSpecialtyResponse(MedicalSpecialty? entity) : base(entity)
    {
    }

    public MedicalSpecialtyResponse(string message) : base(message)
    {
    }
}