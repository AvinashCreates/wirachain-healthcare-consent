using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Patients.Domain.Models;

namespace wirachain_backend.Permissions.Domain.Models;

public class PatientConsent
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public string Purpose { get; set; } = string.Empty;
    public string ResourceScopesJson { get; set; } = "[]";
    public DateTime GrantedAtUtc { get; set; }
    public DateTime ExpiresAtUtc { get; set; }
    public DateTime? RevokedAtUtc { get; set; }
    public string? FhirConsentId { get; set; }
    public string? BlockchainTransactionHash { get; set; }

    [NotMapped]
    public string Status => RevokedAtUtc.HasValue
        ? "revoked"
        : ExpiresAtUtc <= DateTime.UtcNow
            ? "expired"
            : "active";

    public bool AllowsResource(string resourceType, DateTime nowUtc)
    {
        if (RevokedAtUtc.HasValue || ExpiresAtUtc <= nowUtc || GrantedAtUtc > nowUtc)
        {
            return false;
        }

        try
        {
            var scopes = JsonSerializer.Deserialize<HashSet<string>>(ResourceScopesJson);
            return scopes?.Contains(resourceType, StringComparer.OrdinalIgnoreCase) == true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}
