using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalTests.Domain.Services.Communication;

public class MedicalTestResponse : BaseResponse<MedicalTest>
{
    public MedicalTestResponse(MedicalTest? entity) : base(entity)
    {
    }

    public MedicalTestResponse(string message) : base(message)
    {
    }
}