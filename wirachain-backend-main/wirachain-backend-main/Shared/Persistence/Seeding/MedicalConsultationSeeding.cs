using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.MedicalConsultations.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class MedicalConsultationSeeding : IEntityTypeConfiguration<MedicalConsultation>
{
    public void Configure(EntityTypeBuilder<MedicalConsultation> builder)
    {
        builder.HasData(new MedicalConsultation
        {
            Id = new Guid("06b4c3bc-6724-49b6-bc32-94bc1a47a481"),
            ClinicId = 1,
            PatientId = new Guid("dcf5afba-0960-449f-b967-9972af646ce2"),
            VisitReason = "",
            Notes = "",
            CheckInDateTime = DateTime.Today,
            CheckOutDateTime = DateTime.Today.AddHours(1),
            NextAppointmentDate = DateTime.Today.AddMonths(1),
            CreatedAt = DateTime.Today,
            UpdatedAt = DateTime.Today,
            DoctorInChargeId = new Guid("51ddfd30-d8e3-4df7-905e-07065f2bd440"),
        });
    }
}