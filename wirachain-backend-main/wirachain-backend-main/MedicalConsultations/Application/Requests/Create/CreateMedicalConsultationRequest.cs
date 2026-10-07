namespace wirachain_backend.MedicalConsultations.Application.Requests.Create;

public class CreateMedicalConsultationRequest
{
    public string VisitReason { get; set; } = string.Empty;
    public DateTime NextAppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime CheckInDateTime { get; set; }
    public DateTime CheckOutDateTime { get; set; }
    public IList<long> MedicalTestIds { get; set; } = new List<long>();
}