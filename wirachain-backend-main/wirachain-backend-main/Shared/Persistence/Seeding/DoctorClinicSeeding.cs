using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class DoctorClinicSeeding : IEntityTypeConfiguration<DoctorClinic>
{
    public void Configure(EntityTypeBuilder<DoctorClinic> builder)
    {
        builder.HasData(new DoctorClinic
        {
            Id = Guid.NewGuid(),
            DoctorId = new Guid("51ddfd30-d8e3-4df7-905e-07065f2bd440"),
            ClinicId = 1,
        });
    }
}