using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class SystemAdministratorSeeding : IEntityTypeConfiguration<SystemAdministrator>
{
    public void Configure(EntityTypeBuilder<SystemAdministrator> builder)
    {
        builder.HasData(new SystemAdministrator
        {
            Id = new Guid("569dd9fa-798d-4876-8d61-4573fea4b01d"),
            FirstName = "Joao",
            LastName = "Urrunaga",
            HashedPassword = BCrypt.Net.BCrypt.HashPassword("5678"),
            Email = "joao.urrunaga@gmail.com",
            Phone = "+51 987654321",
            Gender = Gender.Male,
            UserType = UserType.SystemAdmin,
            DateOfBirth = new DateTime(2002, 1, 1),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        });
    }
}