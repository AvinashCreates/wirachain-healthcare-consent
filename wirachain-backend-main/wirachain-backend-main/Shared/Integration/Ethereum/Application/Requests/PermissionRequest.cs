namespace wirachain_backend.Shared.Integration.Ethereum.Application.Requests;

public class PermissionRequest
{
    public long ClinicId { get; set; }
    public Guid PatientId { get; set; }
}