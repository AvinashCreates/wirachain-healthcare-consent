using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class ClinicAdministratorsSeeding : IEntityTypeConfiguration<ClinicAdministrator>
{
    public void Configure(EntityTypeBuilder<ClinicAdministrator> builder)
    {
        builder.HasData(new ClinicAdministrator
        {
            Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@gmail.com",
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("1234"),
            Phone = "987654321",
            UserId = new Guid("2d3e4f5a-6b7c-8d9e-0f1a-2b3c4d5e6f7a"),
            UserType = UserType.ClinicAdministrator
        }, new ClinicAdministrator
        {
            Id = new Guid("2920ff55-ca14-4df0-bdd3-622d84f44e29"),
            FirstName = "Leonardo",
            LastName = "Grau",
            Email = "leonardo.grau@gmail.com",
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("1234"),
            Phone = "987654321",
            UserId = new Guid("07b72623-c691-4ecb-b7cf-fbea997acb8e"),
            UserType = UserType.ClinicAdministrator
        });
    }
}