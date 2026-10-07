using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Models;

namespace wirachain_backend.MedicalConsultations.Domain.Models;

public class MedicalConsultation : AuditModel
{
    public Guid Id { get; set; }
    public string VisitReason { get; set; } = string.Empty;
    public DateTime NextAppointmentDate { get; set; }
    public string Notes { get; set; } = string.Empty;
    public DateTime CheckInDateTime { get; set; }
    public DateTime CheckOutDateTime { get; set; }
    public TimeSpan DurationTimeSpan => CheckOutDateTime - CheckInDateTime;
    public Doctor DoctorInCharge { get; set; } = null!;
    public Guid DoctorInChargeId { get; set; }
    
    public Patient Patient { get; set; } = null!;
    public Guid PatientId { get; set; }
    
    public Clinic Clinic { get; set; } = null!;
    public long ClinicId { get; set; }
    
    // Relations
    public IList<ConsultationMedicalTest> ConsultationMedicalTests { get; set; } = new List<ConsultationMedicalTest>();
   
}