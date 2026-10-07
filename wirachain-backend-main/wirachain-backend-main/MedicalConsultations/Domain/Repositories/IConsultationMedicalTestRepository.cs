using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.Shared.Domain.Repositories;

namespace wirachain_backend.MedicalConsultations.Domain.Repositories;

public interface IConsultationMedicalTestRepository : IBaseRepository<ConsultationMedicalTest, Guid>
{
    Task AddRangeAsync(IEnumerable<ConsultationMedicalTest> medicalTests);
}