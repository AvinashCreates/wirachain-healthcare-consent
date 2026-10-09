using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using wirachain_backend.Shared.Persistence.Context;

namespace wirachain_backend.Shared.Persistence.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("20261008143000_AddPatientConsents")]
public class AddPatientConsents : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("""
            CREATE TABLE IF NOT EXISTS `patient_consents` (
                `id` char(36) NOT NULL,
                `patient_id` char(36) NOT NULL,
                `doctor_id` char(36) NOT NULL,
                `purpose` varchar(255) NOT NULL,
                `resource_scopes_json` longtext NOT NULL,
                `granted_at_utc` datetime(6) NOT NULL,
                `expires_at_utc` datetime(6) NOT NULL,
                `revoked_at_utc` datetime(6) NULL,
                `fhir_consent_id` varchar(64) NULL,
                `blockchain_transaction_hash` varchar(128) NULL,
                PRIMARY KEY (`id`),
                KEY `i_x_patient_consents_patient_id` (`patient_id`),
                KEY `i_x_patient_consents_doctor_id` (`doctor_id`),
                KEY `i_x_patient_consents_expires_at_utc` (`expires_at_utc`),
                CONSTRAINT `f_k_patient_consents_patients_patient_id`
                    FOREIGN KEY (`patient_id`) REFERENCES `patients` (`id`) ON DELETE RESTRICT,
                CONSTRAINT `f_k_patient_consents_doctors_doctor_id`
                    FOREIGN KEY (`doctor_id`) REFERENCES `doctors` (`id`) ON DELETE RESTRICT
            ) ENGINE=InnoDB;
            """);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP TABLE IF EXISTS `patient_consents`;");
    }
}
