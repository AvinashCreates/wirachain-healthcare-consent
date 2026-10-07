using Microsoft.EntityFrameworkCore;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalSpecialties.Domain.Model;

namespace wirachain_backend.Shared.Persistence.Configuration;

public static partial class AppDbContextConfiguration
{
    public static ModelBuilder SetMedicalConsultationTableAttributes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalConsultation>().ToTable("MedicalConsultations");
        modelBuilder.Entity<MedicalConsultation>().HasKey(ms => ms.Id);

        modelBuilder.Entity<ConsultationMedicalTest>().ToTable("ConsultationMedicalTests");
        modelBuilder.Entity<ConsultationMedicalTest>().HasKey(cmt => cmt.Id);
        
        
        return modelBuilder;
    }

    public static ModelBuilder SetMedicalConsultationRelations(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalConsultation>()
            .HasMany(mc => mc.ConsultationMedicalTests)
            .WithOne(cmt => cmt.MedicalConsultation)
            .HasForeignKey(cmt => cmt.MedicalConsultationId)
            .HasConstraintName("FKConsultationMedicalTestMedicalConsultationId");
        
        return modelBuilder;
    }
}