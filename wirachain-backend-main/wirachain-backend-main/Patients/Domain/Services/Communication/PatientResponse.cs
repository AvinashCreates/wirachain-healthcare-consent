using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Patients.Domain.Services.Communication;

public class PatientResponse : BaseResponse<Patient>
{
    public PatientResponse(Patient? entity) : base(entity)
    {
    }

    public PatientResponse(string message) : base(message)
    {
    }
}