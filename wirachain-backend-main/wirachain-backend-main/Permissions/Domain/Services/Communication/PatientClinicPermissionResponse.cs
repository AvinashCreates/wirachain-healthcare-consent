using wirachain_backend.Permissions.Application.Resources;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Permissions.Domain.Services.Communication;

public class PatientClinicPermissionResponse : BaseResponse<PatientClinicPermissionResource>
{
    public PatientClinicPermissionResponse(PatientClinicPermissionResource? entity) : base(entity)
    {
    }

    public PatientClinicPermissionResponse(string message) : base(message)
    {
    }
}