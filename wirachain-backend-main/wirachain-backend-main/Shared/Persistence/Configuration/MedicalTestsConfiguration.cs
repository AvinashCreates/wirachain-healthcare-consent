using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetMedicalTestsTableAttributes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalTest>().ToTable("MedicalTests");
        modelBuilder.Entity<MedicalTest>().HasKey(c => c.Id);
        modelBuilder.Entity<MedicalTest>().Property(c => c.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<MedicalTest>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        
        modelBuilder.Entity<MedicalTestClinic>().ToTable("MedicalTestsClinics");
        modelBuilder.Entity<MedicalTestClinic>().HasKey(mc => mc.Id);
        modelBuilder.Entity<MedicalTestClinic>().Property(mc => mc.Id).ValueGeneratedOnAdd();
        
        return modelBuilder;
    }

    public static ModelBuilder SetMedicalTestsRelations(this ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<MedicalTest>()
            .HasMany(mc => mc.MedicalTestClinics)
            .WithOne(mc => mc.MedicalTest)
            .HasForeignKey(mc => mc.MedicalTestId);
        
        modelBuilder.Entity<MedicalTest>()
            .HasMany(mc => mc.ConsultationMedicalTests)
            .WithOne(mc => mc.MedicalTest)
            .HasForeignKey(mc => mc.MedicalTestId);
        
        return modelBuilder;
    }
}