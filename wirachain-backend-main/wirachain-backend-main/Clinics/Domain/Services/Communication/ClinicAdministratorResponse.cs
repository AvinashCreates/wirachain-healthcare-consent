using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Clinics.Domain.Services.Communication;

public class ClinicAdministratorResponse : BaseResponse<ClinicAdministrator>
{
    public ClinicAdministratorResponse(ClinicAdministrator? entity) : base(entity)
    {
    }

    public ClinicAdministratorResponse(string message) : base(message)
    {
    }
}