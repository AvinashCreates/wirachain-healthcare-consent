using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Doctors.Domain.Services.Communication;

public class DoctorResponse : BaseResponse<Doctor>
{
    public DoctorResponse(Doctor? entity) : base(entity)
    {
    }

    public DoctorResponse(string message) : base(message)
    {
    }
}