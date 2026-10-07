using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Utils.Converters;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetDoctorsTableAttributes(this ModelBuilder modelBuilder)
    {
        // Doctors
        modelBuilder.Entity<Doctor>().ToTable("Doctors");
        modelBuilder.Entity<Doctor>().Property(c => c.FirstName);
        modelBuilder.Entity<Doctor>().Property(c => c.LastName);
        modelBuilder.Entity<Doctor>().Property(c => c.Gender)
            .HasConversion<EnumConverter<Gender>>();
        modelBuilder.Entity<Doctor>().Property(c => c.DateOfBirth);

        // DoctorClinics (I did on this context, could be in the other, but whatever)
        modelBuilder.Entity<DoctorClinic>().ToTable("DoctorClinics");
        modelBuilder.Entity<DoctorClinic>().HasKey(c => c.Id);
            
        
        return modelBuilder;
    }

    public static ModelBuilder SetDoctorsRelations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasMany(c => c.DoctorClinics)
            .WithOne(dc => dc.Doctor)
            .HasForeignKey(dc => dc.DoctorId);
        
        modelBuilder.Entity<Doctor>()
            .HasMany(c => c.DoctorMedicalSpecialties)
            .WithOne(ms => ms.Doctor)
            .HasForeignKey(ms => ms.DoctorId);
        
        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.PatientClinicsPermissions)
            .WithOne(pc => pc.RequiredByDoctor)
            .HasForeignKey(pc => pc.RequiredByDoctorId);
            
            
        return modelBuilder;
    }
}