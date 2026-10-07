using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class DoctorSeeding : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData(new Doctor
        {
            Id = new Guid("51ddfd30-d8e3-4df7-905e-07065f2bd440"),
            FirstName = "Paul",
            LastName = "Jones",
            Email = "paul.jones@gmail.com",
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("1234"),
            Phone = "987654321",
            Gender = Gender.Male,
            UserId = new Guid("2b0d06a3-0ad7-422f-b482-a0c2b58c0716"),
            UserType = UserType.Doctor
        });
    }
}