# Project Roadmap: From Base Healthcare App to Consent-Aware FHIR Blockchain Prototype

## 1. Goal

Turn the existing healthcare management codebase into a clear research prototype for:

- secure healthcare data exchange
- patient-controlled consent
- FHIR-based interoperability
- blockchain-backed provenance and auditability
- patient-doctor-laboratory workflow support

---

## 2. High-Level Research Direction

The final product should be framed as:

"A secure, consent-aware FHIR and blockchain-enabled healthcare data exchange framework for patients, physicians, and clinical laboratories."

This is the core narrative behind the implementation and documentation.

---

## 3. Current Observations from the Codebase

The repository already contains important building blocks:

- backend healthcare domain modules
- authentication and authorization flow
- FHIR integration modules
- Ethereum/blockchain-related infrastructure
- React frontend for healthcare workflows
- Docker orchestration for deployment

The remaining work is to align these components with the research objective and strengthen missing concepts such as consent lifecycle, FHIR mapping, and blockchain provenance.

---

## 4. Workstream 1: Scope and Research Alignment

### Objective
Align the project scope with the actual research problem rather than generic medical management.

### Tasks
- Define the final project theme and story
- Narrow the use case to patient-doctor-lab workflow
- Explicitly position the project as consent-aware and FHIR-driven
- Remove or de-emphasize generic clinic CRUD features unless needed for the workflow

### Deliverable
A project statement that clearly explains:
- why the system exists
- who the users are
- what data is exchanged
- how consent works
- why blockchain is included

---

## 5. Workstream 2: Consent Model Definition

### Objective
Create a formal, explicit consent system as a first-class domain concept.

### Required consent fields
- consentId
- patientId
- actorId (doctor/lab/admin)
- actorRole
- resourceType
- resourceId
- purposeOfUse
- grantedAt
- validFrom
- validUntil
- status
- revokedAt
- createdBy
- metadata

### Consent states
- Active
- Revoked
- Expired
- Rejected
- Pending

### Access rules
- access only valid if consent status is Active
- access rejected if expired
- access denied immediately after revocation
- access is scope-limited to approved resource types

### Deliverable
A consent domain model and service layer with enforceable policy checks.

---

## 6. Workstream 3: FHIR Data Model Mapping

### Objective
Ensure core healthcare resources map to FHIR-standard concepts.

### Primary resources to model
- Patient
- Practitioner
- ServiceRequest
- Specimen
- Observation
- DiagnosticReport
- Consent

### Mapping strategy
- patient profile -> Patient
- doctor record -> Practitioner
- test order -> ServiceRequest
- lab sample -> Specimen
- lab result -> Observation / DiagnosticReport
- access authorization -> Consent

### Deliverable
A consistent interoperability layer where internal domain objects map cleanly to FHIR resource representations.

---

## 7. Workstream 4: Backend Authorization Enforcement

### Objective
Update the current authorization flow to enforce real consent-aware access control.

### Required backend changes
- validate user identity and role
- check whether request is allowed under consent rules
- evaluate time validity and expiry
- check whether the requested resource is included in the consent scope
- reject unauthorized access requests cleanly
- log the decision in security or audit records

### Design principle
Access control should combine:
- role
- policy
- patient consent
- resource scope
- time validity

### Deliverable
Secure backend services that enforce consent-aware authorization before exposing patient or laboratory data.

---

## 8. Workstream 5: Frontend Use Case Design

### Objective
Refocus the frontend on patient-doctor-lab workflows rather than generic management screens.

### Required workflows
- patient logs in and reviews granted access
- patient grants or revokes access to doctor/lab
- doctor requests patient information or reports
- lab uploads diagnostic data
- doctor views lab result under valid consent
- expired consent is shown and blocked

### UI features
- patient consent dashboard
- doctor access request panel
- lab result submission interface
- consent expiry indicators
- audit history view

### Deliverable
A frontend aligned with the actual research scenario and not generic CRUD operations.

---

## 9. Workstream 6: Blockchain Provenance and Event Logging

### Objective
Make blockchain support meaningful and connected to actual business events.

### Events to log
- consent granted
- consent revoked
- access requested
- access approved
- access denied
- consent expired
- patient data retrieved under consent

### Design principle
Sensitive health data stays off-chain.
Only consent/access provenance metadata should be stored or referenced on-chain.

### Deliverable
An event model that records the lifecycle of access decisions and audit actions in a verifiable way.

---

## 10. Workstream 7: Security and Privacy Hardening

### Objective
Make the system stronger for a healthcare research prototype.

### Needed improvements
- explicit separation between patient data and consent metadata
- stronger audit logs for all access decisions
- validation of consent expiry and revocation at runtime
- authorization checks before every sensitive read
- clear response structure for denied requests

### Deliverable
A secure access-control model suitable for the research narrative and evaluation.

---

## 11. Workstream 8: Documentation and Thesis Alignment

### Objective
Ensure all documents correspond to the final project story.

### Documents to align
- abstract
- problem statement
- research questions
- objectives
- system design
- literature review
- methodology
- implementation report
- final conclusion

### Deliverable
A consistent project story with matching documentation and implementation.

---

## 12. Suggested Milestones

### Milestone 1: Scope and framing
- final project objective defined
- consent and FHIR story agreed

### Milestone 2: Data model and backend logic
- consent model implemented
- access decisions enforceable

### Milestone 3: Frontend workflow update
- relevant screens built for patient/doctor/lab workflow

### Milestone 4: Blockchain provenance integration
- access and consent events logged and linked to the system

### Milestone 5: Evaluation and documentation
- test the workflow
- write results
- finalize paper and technical report

---

## 13. Implementation Priority Order

1. Consent model and policy logic
2. FHIR resource mapping
3. Backend authorization enforcement
4. Frontend workflows and screens
5. Blockchain event linkage
6. Security and performance validation
7. Project documentation and final paper rewrite

---

## 14. Final Recommendation

The project does not need a full rewrite. It needs a targeted transformation from a general healthcare app into a focused consent-aware healthcare exchange platform.

The best strategy is to keep the existing architecture and strengthen the missing research-critical components:

- consent lifecycle
- FHIR mapping
- access enforcement
- blockchain provenance
- patient-doctor-lab workflow focus

Once these are in place, the project will be much more aligned with the original abstract and far more defensible as a major project and research prototype.
