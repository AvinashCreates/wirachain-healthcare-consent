using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hl7.Fhir.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using wirachain_backend.Auth.Domain.Facades;
using wirachain_backend.Auth.Domain.Models;
using wirachain_backend.Auth.Domain.Services;
using wirachain_backend.Auth.Facade;
using wirachain_backend.Clinics.Domain.Facade;
using wirachain_backend.Clinics.Domain.Models;
using wirachain_backend.Clinics.Domain.Repositories;
using wirachain_backend.Clinics.Domain.Services;
using wirachain_backend.Clinics.Facade;
using wirachain_backend.Clinics.Repositories;
using wirachain_backend.Clinics.Services;
using wirachain_backend.Doctors.Domain.Facade;
using wirachain_backend.Doctors.Domain.Models;
using wirachain_backend.Doctors.Domain.Repositories;
using wirachain_backend.Doctors.Domain.Services;
using wirachain_backend.Doctors.Facades;
using wirachain_backend.Doctors.Repositories;
using wirachain_backend.Doctors.Services;
using wirachain_backend.Mapping;
using wirachain_backend.MedicalConsultations.Domain.Facades;
using wirachain_backend.MedicalConsultations.Domain.Models;
using wirachain_backend.MedicalConsultations.Domain.Repositories;
using wirachain_backend.MedicalConsultations.Domain.Services;
using wirachain_backend.MedicalConsultations.Facades;
using wirachain_backend.MedicalConsultations.Repository;
using wirachain_backend.MedicalConsultations.Services;
using wirachain_backend.MedicalSpecialties.Domain.Facades;
using wirachain_backend.MedicalSpecialties.Domain.Repositories;
using wirachain_backend.MedicalSpecialties.Domain.Services;
using wirachain_backend.MedicalSpecialties.Facades;
using wirachain_backend.MedicalSpecialties.Repositories;
using wirachain_backend.MedicalSpecialties.Services;
using wirachain_backend.MedicalTests.Domain.Facade;
using wirachain_backend.MedicalTests.Domain.Models;
using wirachain_backend.MedicalTests.Domain.Repositories;
using wirachain_backend.MedicalTests.Domain.Services;
using wirachain_backend.MedicalTests.Facade;
using wirachain_backend.MedicalTests.Repositories;
using wirachain_backend.MedicalTests.Services;
using wirachain_backend.Patients.Domain.Facade;
using wirachain_backend.Patients.Domain.Models;
using wirachain_backend.Patients.Domain.Repositories;
using wirachain_backend.Patients.Domain.Services;
using wirachain_backend.Patients.Facades;
using wirachain_backend.Patients.Repositories;
using wirachain_backend.Patients.Services;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Permissions.Domain.Services;
using wirachain_backend.Permissions.Repositories;
using wirachain_backend.Permissions.Services;
using wirachain_backend.Security.Application.Services;
using wirachain_backend.Security.Domain.Models;
using wirachain_backend.Security.Domain.Repositories;
using wirachain_backend.Security.Domain.Services;
using wirachain_backend.Security.Infrastructure.Security;
using wirachain_backend.Security.Repositories;
using wirachain_backend.Security.Services;
using wirachain_backend.Shared.Domain.Repositories;
using wirachain_backend.Shared.Domain.Services;
using wirachain_backend.Shared.Extensions.Swagger;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Events;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Factory;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Managers;
using wirachain_backend.Shared.Integration.Ethereum.Domain.Service;
using wirachain_backend.Shared.Integration.Ethereum.Events;
using wirachain_backend.Shared.Integration.Ethereum.Factory;
using wirachain_backend.Shared.Integration.Ethereum.Managers;
using wirachain_backend.Shared.Integration.Fhir.Domain.Services;
using wirachain_backend.Shared.Integration.Fhir.Service;
using wirachain_backend.Shared.Integration.Fhir.Settings;
using wirachain_backend.Shared.Middleware;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;
using wirachain_backend.Shared.Services;
using wirachain_backend.Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Wirachain API",
            Version = "v0.1",
            Description = "Wirachain API"
        });
    options.EnableAnnotations();
    options.SchemaFilter<TimeSpanSchemaFilter>();
});

var connectionString = builder.Configuration.GetConnectionString("WiraChainDbConnection");

// Add DB Context
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    if (!string.IsNullOrEmpty(connectionString))
    {
        optionsBuilder
            .UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging(false)
            .EnableDetailedErrors();
    }
});


builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Parse enum to string in camelcase format.
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter(namingPolicy: JsonNamingPolicy.CamelCase));
    });

// CORS
builder.Services.AddCors();

// HttpClient. Important for connecting to other api's
builder.Services.AddHttpClient();


// Services and Dependency Injection
// -- Clinic --
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IBaseRepository<Clinic, long>, ClinicRepository>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IClinicFacade, ClinicFacade>();
// -- User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBaseRepository<User, Guid>, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountFacade, AccountFacade>();
// -- Doctor
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IBaseRepository<Doctor, Guid>, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorFacade, DoctorFacade>();
// -- Clinic Administrator
builder.Services.AddScoped<IClinicAdministratorRepository, ClinicAdministratorRepository>();
builder.Services.AddScoped<IBaseRepository<ClinicAdministrator, Guid>, ClinicAdministratorRepository>();
builder.Services.AddScoped<IClinicAdministratorService, ClinicAdministratorService>();
// -- Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// -- Doctor Clinic
builder.Services.AddScoped<IDoctorClinicRepository, DoctorClinicRepository>();
builder.Services.AddScoped<IBaseRepository<DoctorClinic, Guid>, DoctorClinicRepository>();
// -- Patient
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IBaseRepository<Patient, Guid>, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientFacade, PatientFacade>();
// -- PatientClinicPermission
builder.Services.AddScoped<IPatientClinicPermissionRepository, PatientClinicPermissionRepository>();
builder.Services.AddScoped<IBaseRepository<PatientClinicPermission, Guid>, PatientClinicPermissionRepository>();
builder.Services.AddScoped<IPatientClinicPermissionService, PatientClinicPermissionService>();
builder.Services.AddScoped<IPatientConsentRepository, PatientConsentRepository>();
builder.Services.AddScoped<IPatientConsentService, PatientConsentService>();
// -- MedicalTest
builder.Services.AddScoped<IMedicalTestRepository, MedicalTestRepository>();
builder.Services.AddScoped<IBaseRepository<MedicalTest, long>, MedicalTestRepository>();
builder.Services.AddScoped<IMedicalTestService, MedicalTestService>();
builder.Services.AddScoped<IMedicalTestFacade, MedicalTestFacade>();
// -- MedicalSpecialty
builder.Services.AddScoped<IMedicalSpecialtyRepository, MedicalSpecialtyRepository>();
builder.Services.AddScoped<IMedicalSpecialtyService, MedicalSpecialtyService>();
builder.Services.AddScoped<IMedicalSpecialtyFacade, MedicalSpecialtyFacade>();
// -- MedicalTestClinic
builder.Services.AddScoped<IMedicalTestClinicRepository, MedicalTestClinicRepository>();
builder.Services.AddScoped<IBaseRepository<MedicalTestClinic, Guid>, MedicalTestClinicRepository>();
// -- DoctorMedicalSpecialty
builder.Services.AddScoped<IDoctorMedicalSpecialtyRepository, DoctorMedicalSpecialtyRepository>();
// -- MedicalConsultation
builder.Services.AddScoped<IMedicalConsultationFacade, MedicalConsultationFacade>();
builder.Services.AddScoped<IMedicalConsultationService, MedicalConsultationService>();
builder.Services.AddScoped<IMedicalConsultationRepository, MedicalConsultationRepository>();
// -- ConsultationMedicalTest
builder.Services.AddScoped<IBaseRepository<ConsultationMedicalTest, Guid>, ConsultationMedicalTestRepository>();
builder.Services.AddScoped<IConsultationMedicalTestRepository, ConsultationMedicalTestRepository>();
// -- Ethereum Service
builder.Services.AddScoped<IEthereumService, EthereumService>();
// -- FHIR Patient Service
builder.Services.AddScoped<IFhirPatientService, FhirPatientService>();
builder.Services.AddScoped<IFhirConsentService, FhirConsentService>();


// JwtService
builder.Services.AddScoped<IJwtService, JwtService>();

//  Generate every time is need it.
// -- GrantPermissionEmitter
builder.Services.AddTransient<GrantPermissionEventEmitter>();
// -- RevokePermissionEmitter
builder.Services.AddTransient<RevokePermissionEventEmitter>();



// Just one
// -- EventEmitterFactory
builder.Services.AddSingleton<IEventEmitterFactory, EventEmitterFactory>();
// -- Wallet Manager
builder.Services.AddSingleton<IWalletManager, WalletManager>();

// FHIR Serializers
// -- FhirJsonSerializer
builder.Services.AddScoped<FhirJsonSerializer>();
// -- FhirJsonParser
builder.Services.AddScoped<FhirJsonParser>();

// Mapper
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToCommandProfile),
    typeof(ResourceToModelProfile)
);

// Add JwtSettings
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

// Add EthereumSettings
builder.Services.Configure<EthereumSettings>(
    builder.Configuration.GetSection("EthereumSettings"));

// Add FhirSettings
builder.Services.Configure<FhirSettings>(
    builder.Configuration.GetSection("FhirSettings"));

// Security
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        // Get JwtSettings from appsettings.json
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
        if (jwtSettings != null)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true, // Validates expiration
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
            };
        }
    });

var app = builder.Build();
app.UseStaticFiles(); // In order to use stylesheet.

// Validating database creation
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    Console.WriteLine("Development");
    context.Database.EnsureCreated();
    context.Database.Migrate();
}

app.UseAuthentication(); // Validating JWT
app.UseAuthorization();

// Using Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "swagger";
    options.InjectStylesheet("/swagger-ui/dark-swagger.css");
});

// Middleware
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();
app.MapControllers();
app.Run();