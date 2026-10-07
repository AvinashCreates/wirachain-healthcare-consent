using Microsoft.EntityFrameworkCore;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalSpecialties.Domain.Model;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Shared.Extensions.Builder;
using wirachain_backend.Shared.Persistence.Configuration;
using wirachain_backend.Shared.Persistence.Seeding;

namespace wirachain_backend.Shared.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<DoctorClinic> DoctorClinics { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientClinicPermission> PatientClinicPermissions { get; set; }
    public DbSet<MedicalTest> MedicalTests { get; set; }
    public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
    public DbSet<DoctorMedicalSpecialty> DoctorMedicalSpecialties { get; set; }
    public DbSet<MedicalConsultation> MedicalConsultations { get; set; } 
    public DbSet<SystemAdministrator> SystemAdministrators { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // ModelBuilder
        modelBuilder
            .SetUserTableAttributes()
            .SetUserRelations()
            .SetPatientsTableAttributes()
            .SetPatientsRelations()
            .SetDoctorsTableAttributes()
            .SetDoctorsRelations()
            .SetClinicTableAttributes()
            .SetClinicsRelations()
            .SetMedicalTestsRelations()
            .SetMedicalTestsTableAttributes()
            .SetMedicalSpecialtyTableAttributes()
            .SetMedicalSpecialtyRelations()
            .SetMedicalConsultationTableAttributes()
            .SetMedicalConsultationRelations();
        
        // Seeding
        modelBuilder
            .ApplyConfiguration(new RoleSeeding())
            .ApplyConfiguration(new SystemAdministratorSeeding())
            .ApplyConfiguration(new DoctorSeeding())
            .ApplyConfiguration(new ClinicAdministratorsSeeding())
            .ApplyConfiguration(new ClinicSeeding())
            .ApplyConfiguration(new PatientSeeding())
            .ApplyConfiguration(new MedicalTestSeeding())
            .ApplyConfiguration(new MedicalSpecialtySeeding())
            .ApplyConfiguration(new MedicalTestClinicSeeding())
            .ApplyConfiguration(new DoctorMedicalSpecialtySeeding())
            .ApplyConfiguration(new DoctorClinicSeeding())
            .ApplyConfiguration(new MedicalConsultationSeeding())
            .ApplyConfiguration(new UserRoleSeeding());
        
        // Convert to snake case.
        modelBuilder.ConvertAllToSnakeCase();
    }
    
}