using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.MedicalConsultations.Domain.Services.Communication;

public class MedicalConsultationResponse : BaseResponse<MedicalConsultation>
{
    public MedicalConsultationResponse(MedicalConsultation? entity) : base(entity)
    {
    }

    public MedicalConsultationResponse(string message) : base(message)
    {
    }
}