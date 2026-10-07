using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Permissions.Application.Requests.Patch;

public class PatchPermissionStatusRequest
{
    public PermissionStatus PermissionStatus { get; set; }
}