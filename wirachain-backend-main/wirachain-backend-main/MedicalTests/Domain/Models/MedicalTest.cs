using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Models;

namespace wirachain_backend.MedicalTests.Domain.Models;

public class MedicalTest
{
    public long Id { get; set; }
    public string Name = string.Empty;
    
    // Relations (Multiple)
    public IList<MedicalTestClinic> MedicalTestClinics { get; set; } = new List<MedicalTestClinic>();
    public IList<ConsultationMedicalTest> ConsultationMedicalTests { get; set; } = new List<ConsultationMedicalTest>();
}