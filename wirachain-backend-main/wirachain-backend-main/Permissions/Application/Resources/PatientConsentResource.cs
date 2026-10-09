namespace wirachain_backend.Permissions.Application.Resources;

public class PatientConsentResource
{
    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public IReadOnlyList<string> ResourceTypes { get; set; } = [];
    public DateTime GrantedAtUtc { get; set; }
    public DateTime ExpiresAtUtc { get; set; }
    public DateTime? RevokedAtUtc { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? FhirConsentId { get; set; }
    public string? BlockchainTransactionHash { get; set; }
}
