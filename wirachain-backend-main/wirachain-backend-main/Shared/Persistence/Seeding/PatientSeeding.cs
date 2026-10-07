using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class PatientSeeding : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasData(new Patient
        {
            UserId = new Guid("362b79cc-fc06-4300-87ef-623e94ce7865"),
            Id = new Guid("dcf5afba-0960-449f-b967-9972af646ce2"),
            FirstName = "Nathan",
            LastName = "Jack",
            Gender = Gender.Male,
            Email = "nathan@gmail.com",
            Phone = "987654321",
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("1234"),
            DateOfBirth = new DateTime(1980, 1, 1),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            UserType = UserType.Patient
        });
    }
}