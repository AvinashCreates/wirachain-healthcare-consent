using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.MedicalTests.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class MedicalTestSeeding : IEntityTypeConfiguration<MedicalTest>
{
    public void Configure(EntityTypeBuilder<MedicalTest> builder)
    {
        builder.HasData(new MedicalTest
            {
                Id = 1,
                Name = "Complete Blood Count",
            },
            new MedicalTest
            {
                Id = 2,
                Name = "Chest X-Ray",
            },
            new MedicalTest
            {
                Id = 3,
                Name = "Liver Function Test",
            },
            new MedicalTest
            {
                Id = 4,
                Name = "Thyroid Panel",
            },
            new MedicalTest
            {
                Id = 5,
                Name = "Urinalysis",
            },
            new MedicalTest
            {
                Id = 6,
                Name = "Blood Glucose"
            },
            new MedicalTest
            {
                Id = 7,
                Name = "Electrocardiogram (ECG)",
            },
            new MedicalTest
            {
                Id = 8,
                Name = "MRI Brain",
            },
            new MedicalTest
            {
                Id = 9,
                Name = "CT Abdomen",
            },
            new MedicalTest
            {
                Id = 10,
                Name = "COVID-19 PCR",
            },
            new MedicalTest
            {
                Id = 11,
                Name = "Allergy Test",
            },
            new MedicalTest
            {
                Id = 12,
                Name = "Vitamin D Test",
            },
            new MedicalTest
            {
                Id = 13,
                Name = "Cholesterol Test",
            },
            new MedicalTest
            {
                Id = 14,
                Name = "Pap Smear",
            },
            new MedicalTest
            {
                Id = 15,
                Name = "Prostate Exam",
            },
            new MedicalTest
            {
                Id = 16,
                Name = "Eye Examination",
            },
            new MedicalTest
            {
                Id = 17,
                Name = "Hearing Test"
            },
            new MedicalTest
            {
                Id = 18,
                Name = "Spirometry"
            },
            new MedicalTest
            {
                Id = 19,
                Name = "Dental X-Ray"
            },
            new MedicalTest
            {
                Id = 20,
                Name = "Skin Biopsy",
            });
    }
}