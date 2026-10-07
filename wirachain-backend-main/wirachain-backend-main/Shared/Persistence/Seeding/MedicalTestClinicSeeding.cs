using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Clinics.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class MedicalTestClinicSeeding : IEntityTypeConfiguration<MedicalTestClinic>
{
    public void Configure(EntityTypeBuilder<MedicalTestClinic> builder)
    {
        builder.HasData(new MedicalTestClinic
            {
                Id = Guid.NewGuid(),
                ClinicId = 1,
                MedicalTestId = 1
            }, new MedicalTestClinic
            {
                Id = Guid.NewGuid(),
                ClinicId = 1,
                MedicalTestId = 17
            }
            , new MedicalTestClinic
            {
                Id = Guid.NewGuid(),
                ClinicId = 2,
                MedicalTestId = 15
            }, new MedicalTestClinic
            {
                Id = Guid.NewGuid(),
                ClinicId = 1,
                MedicalTestId = 10
            });
    }
}