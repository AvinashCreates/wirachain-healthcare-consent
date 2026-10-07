namespace wirachain_backend.MedicalConsultations.Application.Commands.Create;

public class CreateMedicalConsultationCommand
{
    public string VisitReason { get; set; } = String.Empty;
    public DateTime NextAppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime CheckInDateTime { get; set; }
    public DateTime CheckOutDateTime { get; set; }
    public IList<long> MedicalTestIds { get; set; } = new List<long>();

}