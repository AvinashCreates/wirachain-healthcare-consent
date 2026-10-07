using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.MedicalSpecialties.Domain.Model;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class MedicalSpecialtySeeding : IEntityTypeConfiguration<MedicalSpecialty>
{
    public void Configure(EntityTypeBuilder<MedicalSpecialty> builder)
    {
        builder.HasData(
            new MedicalSpecialty { Id = 1, Name = "Cardiology" },
            new MedicalSpecialty { Id = 2, Name = "Dermatology" },
            new MedicalSpecialty { Id = 3, Name = "Endocrinology" },
            new MedicalSpecialty { Id = 4, Name = "Gastroenterology" },
            new MedicalSpecialty { Id = 5, Name = "Hematology" },
            new MedicalSpecialty { Id = 6, Name = "Infectious Diseases" },
            new MedicalSpecialty { Id = 7, Name = "Nephrology" },
            new MedicalSpecialty { Id = 8, Name = "Neurology" },
            new MedicalSpecialty { Id = 9, Name = "Oncology" },
            new MedicalSpecialty { Id = 10, Name = "Ophthalmology" },
            new MedicalSpecialty { Id = 11, Name = "Orthopedics" },
            new MedicalSpecialty { Id = 12, Name = "Otolaryngology" },
            new MedicalSpecialty { Id = 13, Name = "Pediatrics" },
            new MedicalSpecialty { Id = 14, Name = "Psychiatry" },
            new MedicalSpecialty { Id = 15, Name = "Pulmonology" },
            new MedicalSpecialty { Id = 16, Name = "Radiology" },
            new MedicalSpecialty { Id = 17, Name = "Rheumatology" },
            new MedicalSpecialty { Id = 18, Name = "General Surgery" },
            new MedicalSpecialty { Id = 19, Name = "Urology" },
            new MedicalSpecialty { Id = 20, Name = "Gynecology" }
        );
    }
}