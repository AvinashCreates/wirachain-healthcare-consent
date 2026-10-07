

namespace wirachain_backend.MedicalConsultations.Application.Resources.Basic;

public class BasicMedicalConsultationResource
{
    public Guid Id { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime ConsultationDate { get; set; }
}