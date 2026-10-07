using wirachain_backend.Auth.Resources.Payloads;
using wirachain_backend.Shared.Domain.Services.Communication;

namespace wirachain_backend.Auth.Domain.Services.Communication;

public class RegisterResponse : BaseResponse<RegisterPayload>
{
    public RegisterResponse(RegisterPayload? entity) : base(entity)
    {
    }

    public RegisterResponse(string message) : base(message)
    {
    }
}