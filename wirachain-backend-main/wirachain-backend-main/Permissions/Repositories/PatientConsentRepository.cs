using Microsoft.EntityFrameworkCore;
using wirachain_backend.Permissions.Domain.Models;
using wirachain_backend.Permissions.Domain.Repositories;
using wirachain_backend.Shared.Persistence.Context;
using wirachain_backend.Shared.Persistence.Repositories;

namespace wirachain_backend.Permissions.Repositories;

public class PatientConsentRepository(AppDbContext context)
    : BaseRepository<PatientConsent, Guid>(context), IPatientConsentRepository
{
    public async Task<IReadOnlyList<PatientConsent>> ListByPatientIdAsync(Guid patientId)
    {
        return await DbSet
            .Where(consent => consent.PatientId == patientId)
            .OrderByDescending(consent => consent.GrantedAtUtc)
            .ToListAsync();
    }

    public async Task<PatientConsent?> FindByIdAndPatientIdAsync(Guid consentId, Guid patientId)
    {
        return await DbSet.FirstOrDefaultAsync(consent =>
            consent.Id == consentId && consent.PatientId == patientId);
    }

    public async Task<IReadOnlyList<PatientConsent>> ListByPatientAndDoctorAsync(
        Guid patientId,
        Guid doctorId,
        DateTime nowUtc)
    {
        return await DbSet
            .Where(consent => consent.PatientId == patientId
                && consent.DoctorId == doctorId
                && consent.RevokedAtUtc == null
                && consent.GrantedAtUtc <= nowUtc
                && consent.ExpiresAtUtc > nowUtc)
            .ToListAsync();
    }
}
