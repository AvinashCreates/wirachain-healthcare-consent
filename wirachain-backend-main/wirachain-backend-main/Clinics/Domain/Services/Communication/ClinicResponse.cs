using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Domain.Services.Communication;

public class ClinicResponse : BaseResponse<Clinic>
{
    public ClinicResponse(Clinic? entity) : base(entity)
    {
    }

    public ClinicResponse(string message) : base(message)
    {
    }
}