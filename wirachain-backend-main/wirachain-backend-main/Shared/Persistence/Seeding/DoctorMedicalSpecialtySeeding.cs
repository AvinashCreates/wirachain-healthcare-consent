using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Doctors.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class DoctorMedicalSpecialtySeeding : IEntityTypeConfiguration<DoctorMedicalSpecialty>
{
    public void Configure(EntityTypeBuilder<DoctorMedicalSpecialty> builder)
    {
        builder.HasData(new DoctorMedicalSpecialty
        {
            Id = Guid.NewGuid(),
            DoctorId = new Guid("51ddfd30-d8e3-4df7-905e-07065f2bd440"),
            MedicalSpecialtyId = 1,
        }, new DoctorMedicalSpecialty
        {
            Id = Guid.NewGuid(),
            DoctorId = new Guid("51ddfd30-d8e3-4df7-905e-07065f2bd440"),
            MedicalSpecialtyId = 2,
        }, new DoctorMedicalSpecialty
        {
            Id = Guid.NewGuid(),
            DoctorId = new Guid("51ddfd30-d8e3-4df7-905e-07065f2bd440"),
            MedicalSpecialtyId = 18,
        });
    }
}