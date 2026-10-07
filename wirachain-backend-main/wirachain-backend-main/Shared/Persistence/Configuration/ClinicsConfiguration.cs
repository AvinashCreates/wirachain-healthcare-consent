using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Extensions.Enumerations;
using wirachain_backend.Shared.Utils.Converters;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetClinicTableAttributes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>().ToTable("Clinics");
        modelBuilder.Entity<Clinic>().HasKey(c => c.Id);
        modelBuilder.Entity<Clinic>().Property(c => c.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Clinic>().Property(c => c.Name).IsRequired().HasMaxLength(50);

        modelBuilder.Entity<ClinicAdministrator>().ToTable("ClinicAdministrators");

        modelBuilder.Entity<PatientClinicPermission>().ToTable("PatientClinicPermissions");
        modelBuilder.Entity<PatientClinicPermission>().HasKey(pc => pc.Id);
        modelBuilder.Entity<PatientClinicPermission>().Property(pc => pc.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<PatientClinicPermission>()
            .HasIndex(pc => new { pc.ClinicId, pc.PatientId, pc.RequiredByDoctorId },
                name: "IClinicIdPatientIdRequiredByDoctorId").IsUnique();
        modelBuilder.Entity<PatientClinicPermission>().Property(pc => pc.PermissionStatus)
            .HasConversion(
                status => status.ToDbUpperCaseString(), s => Enum.Parse<PermissionStatus>(s));
        modelBuilder.Entity<PatientClinicPermission>()
            .Property(pc => pc.PermissionStatus)
            .HasConversion<EnumConverter<PermissionStatus>>();


        return modelBuilder;
    }

    public static ModelBuilder SetClinicsRelations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>()
            .HasMany(c => c.DoctorClinics)
            .WithOne(c => c.Clinic)
            .HasForeignKey(c => c.ClinicId);

        modelBuilder.Entity<Clinic>()
            .HasMany(c => c.PatientClinicsPermissions)
            .WithOne(c => c.Clinic)
            .HasForeignKey(c => c.ClinicId);

        modelBuilder.Entity<Clinic>()
            .HasMany(c => c.MedicalTestClinics)
            .WithOne(c => c.Clinic)
            .HasForeignKey(c => c.ClinicId);

        modelBuilder.Entity<ClinicAdministrator>()
            .HasMany(ca => ca.Clinics)
            .WithOne(c => c.Administrator)
            .HasForeignKey(c => c.AdministratorId);
        return modelBuilder;
    }
}