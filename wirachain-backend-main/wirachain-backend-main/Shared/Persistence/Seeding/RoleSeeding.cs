using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Auth.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class RoleSeeding : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = 1, Name = "AppointmentRegister",
                Description = "Manages appointment creation, scheduling, and rebooking."
            },
            new Role
            {
                Id = 2, Name = "PatientManager",
                Description = "Manages patient demographic/admin data (contact, insurance, etc)."
            },
            new Role
            {
                Id = 3, Name = "PrescriptionApprover",
                Description = "Validates and approves medical prescriptions before delivery."
            },
            new Role
            {
                Id = 4, Name = "MedicalNoteWriter",
                Description = "Writes and edits medical notes, diagnoses, and evolution entries."
            },
            new Role
            {
                Id = 5, Name = "ClinicalViewer",
                Description = "Read-only access to medical records (auditors, assistants)."
            },
            new Role
            {
                Id = 6, Name = "PharmacyManager", Description = "Manages pharmacy inventory, dispenses medications."
            },
            new Role
            {
                Id = 7, Name = "BillingManager",
                Description = "Handles invoices, payments, refunds, and insurance claims."
            },
            new Role
            {
                Id = 8, Name = "UserAdmin", Description = "Creates and manages internal users (staff, doctors)."
            },
            new Role
            {
                Id = 9, Name = "InteroperabilityManager",
                Description = "Handles FHIR communication, blockchain syncing."
            },
            new Role
            {
                Id = 10, Name = "TraceabilityAuditor",
                Description = "Views access logs, digital signatures, IPFS hashes, blockchain records."
            },
            new Role
            {
                Id = 11, Name = "SelfCareAccess", Description = "View own medical history, labs, prescriptions."
            },
            new Role { Id = 12, Name = "AppointmentRequester", Description = "Request and manage appointments." },
            new Role { Id = 13, Name = "ConsentManager", Description = "Sign or revoke digital consent forms." },
            new Role
            {
                Id = 14, Name = "TraceabilityViewer", Description = "View when and who accessed their records."
            },
            new Role { Id = 15, Name = "ProfileEditor", Description = "Edit own contact info, address, insurance." },
            new Role
            {
                Id = 16, Name = "DocumentDownloader",
                Description = "Download PDFs (lab results, prescriptions, invoices)."
            },
            new Role
            {
                Id = 17, Name = "ProxyAuthorizer",
                Description = "Assign access to trusted third parties (e.g. caregivers)."
            },
            new Role
            {
                Id = 18, Name = "BlockchainProofViewer", Description = "View blockchain proof of their medical events."
            },
            new Role
            {
                Id = 100, Name = "SystemAdminGod",
                Description =
                    "Unrestricted access to all system operations, including platform-level management, user control, security, and audit logs."
            }
        );
    }
}