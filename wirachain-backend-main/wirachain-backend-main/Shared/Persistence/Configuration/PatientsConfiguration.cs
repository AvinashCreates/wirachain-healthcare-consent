using Microsoft.EntityFrameworkCore;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Utils.Converters;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetPatientsTableAttributes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().ToTable("Patients");
        modelBuilder.Entity<Patient>().Property(c => c.FirstName);
        modelBuilder.Entity<Patient>().Property(c => c.LastName);
        modelBuilder.Entity<Patient>().Property(c => c.Gender)
            .HasConversion<EnumConverter<Gender>>();
        modelBuilder.Entity<Doctor>().Property(c => c.DateOfBirth);

        return modelBuilder;
    }

    public static ModelBuilder SetPatientsRelations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .HasMany(p => p.PatientClinicPermissions)
            .WithOne(p => p.Patient)
            .HasForeignKey(p => p.PatientId);
        return modelBuilder;
    }
}