using Microsoft.EntityFrameworkCore;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Utils.Converters;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetUserTableAttributes(this ModelBuilder modelBuilder)
    {
        // Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(c => c.Id);
        modelBuilder.Entity<User>().Property(c => c.Phone);
        modelBuilder.Entity<User>().Property(c => c.Email);
        modelBuilder.Entity<User>().Property(c => c.HashedPassword);
        modelBuilder.Entity<User>().Property(c => c.Phone);
        modelBuilder.Entity<User>().Property(c => c.UserType)
            .HasConversion<EnumConverter<UserType>>();
        
        // SystemAdministrator
        modelBuilder.Entity<SystemAdministrator>().ToTable("SystemAdministrators");

        // Role
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<Role>().HasKey(c => c.Id);
        modelBuilder.Entity<Role>().Property(c => c.Name);

        // UserRoles
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

        return modelBuilder;
    }

    public static ModelBuilder SetUserRelations(this ModelBuilder modelBuilder)
    {
        return modelBuilder;
    }
}