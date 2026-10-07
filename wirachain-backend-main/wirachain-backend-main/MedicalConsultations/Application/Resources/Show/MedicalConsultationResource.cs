using wirachain_backend.Clinics.Application.Resources.Basic;
using wirachain_backend.Doctors.Application.Resources.Basic;
using wirachain_backend.Patients.Application.Resources.Basic;

namespace wirachain_backend.MedicalConsultations.Application.Resources.Show;

public class MedicalConsultationResource
{
    public Guid Id { get; set; }
    public string Notes { get; set; }
    public DateTime CheckInDateTime { get; set; }
    public DateTime CheckOutDateTime { get; set; }
    public TimeSpan DurationTimeSpan { get; set; }
    public BasicDoctorResource DoctorInCharge { get; set; } = null!;
    public BasicPatientResource Patient { get; set; } = null!;
    public BasicClinicResource Clinic { get; set; } = null!;
}