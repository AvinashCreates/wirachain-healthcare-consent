using System.ComponentModel.DataAnnotations;

namespace wirachain_backend.Permissions.Application.Requests;

public class GrantPatientConsentRequest
{
    [Required]
    public Guid DoctorId { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Purpose { get; set; } = string.Empty;

    [Required]
    [Range(1, 30)]
    public int DurationDays { get; set; }

    [Required]
    [MinLength(1)]
    public List<string> ResourceTypes { get; set; } = [];
}
