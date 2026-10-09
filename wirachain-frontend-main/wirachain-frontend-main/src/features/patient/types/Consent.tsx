export type PatientConsent = {
  id: string
  doctorId: string
  purpose: string
  resourceTypes: string[]
  grantedAtUtc: string
  expiresAtUtc: string
  revokedAtUtc?: string | null
  status: string
  fhirConsentId?: string | null
  blockchainTransactionHash?: string | null
}

export type GrantConsentRequest = {
  doctorId: string
  purpose: string
  durationDays: number
  resourceTypes: string[]
}
