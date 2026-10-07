using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Clinics.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class ClinicSeeding : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.HasData(
            new Clinic
            {
                Id = 1,
                Address = "123 Main Street",
                Name = "Wirachain",
                Ruc = "20293929192",
                AdministratorId = new Guid("550e8400-e29b-41d4-a716-446655440000"),
            }, new Clinic
            {
                Id = 2,
                Address = "234 Main Street",
                Name = "Wirachain",
                Ruc = "20293929192",
                AdministratorId = new Guid("550e8400-e29b-41d4-a716-446655440000"),
            },
            new Clinic
            {
                Id = 3,
                Address = "Poleclenec OG",
                Name = "Poleclenec",
                Ruc = "20123929192",
                AdministratorId = new Guid("550e8400-e29b-41d4-a716-446655440000"),
            });
    }
}