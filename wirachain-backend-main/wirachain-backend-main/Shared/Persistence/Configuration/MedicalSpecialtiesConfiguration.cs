using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.Shared.Domain.Enumerations;
using wirachain_backend.Shared.Utils.Converters;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetMedicalSpecialtyTableAttributes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalSpecialty>().ToTable("MedicalSpecialties");
        modelBuilder.Entity<MedicalSpecialty>().HasKey(ms => ms.Id);
        modelBuilder.Entity<MedicalSpecialty>().Property(ms => ms.Name).IsRequired();
        

        return modelBuilder;
    }

    public static ModelBuilder SetMedicalSpecialtyRelations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalSpecialty>()
            .HasMany(ms => ms.DoctorMedicalSpecialties)
            .WithOne(ms => ms.MedicalSpecialty)
            .HasForeignKey(ms => ms.MedicalSpecialtyId)
            .HasConstraintName("FKDoctorMedicalSpecialtiesMedicalSpecialtyId");
        
        return modelBuilder;
    }
}