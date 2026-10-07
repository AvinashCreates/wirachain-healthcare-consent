using wirachain_backend.MedicalTests.Domain.Models;

namespace wirachain_backend.MedicalConsultations.Domain.Models;

public class ConsultationMedicalTest
{
    public Guid Id { get; set; }
    // Foreign Key
    public Guid MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; }
    
    public long MedicalTestId { get; set; }
    public MedicalTest MedicalTest { get; set; }
    
}