using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Repositories;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.MedicalConsultations.Repository;

public class ConsultationMedicalTestRepository(AppDbContext context) :  BaseRepository<ConsultationMedicalTest, Guid>(context), IConsultationMedicalTestRepository
{
    public async Task AddRangeAsync(IEnumerable<ConsultationMedicalTest> consultationMedicalTests)
    {
        await DbSet.AddRangeAsync(consultationMedicalTests);
    }
}