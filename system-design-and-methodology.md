# System Design and Methodology

## 1. Introduction

The proposed system is designed as a research prototype for secure, consent-aware healthcare data exchange among patients, physicians, and clinical laboratories. It integrates three major components: healthcare interoperability through HL7 FHIR, patient-controlled authorization through a consent model, and tamper-evident governance through a permissioned blockchain. The overall aim is to support controlled and auditable sharing of medical information while reducing privacy risks and improving interoperability across healthcare stakeholders.

This chapter presents the system design and methodology used to implement the proposed framework. The design emphasizes practical applicability, technical feasibility, and evaluation of security and performance under realistic healthcare workflows.

---

## 2. Research Methodology

The study follows a design-science and prototype-based methodology. The objective is to design, implement, and evaluate a secure healthcare information exchange framework that satisfies the requirements of interoperability, consent enforcement, and auditability.

The methodology consists of the following phases:

1. Requirement analysis of healthcare data exchange and patient consent needs.
2. Design of the system architecture and core modules.
3. Implementation of the prototype using a modern technology stack.
4. Validation through functional testing, security checks, and performance measurements.
5. Analysis of results to assess security, interoperability, and scalability.

This approach is appropriate because the research problem is not only theoretical but also practical: a functional prototype is required to demonstrate secure data exchange in healthcare workflows and to test the effectiveness of the proposed architecture.

---

## 3. System Requirements

The system is designed to satisfy both functional and non-functional requirements.

### 3.1 Functional Requirements

- Patient registration and profile management
- Physician and clinic authorization management
- Laboratory request and result workflows
- Patient-controlled consent grant and revocation
- Time-bound access permissions
- Resource-specific authorization
- Access validation before data retrieval or sharing
- Audit logging of permission and access events
- FHIR-based representation of exchanged healthcare resources

### 3.2 Non-Functional Requirements

- Privacy and confidentiality of patient data
- Integrity and auditability of access history
- Interoperability across healthcare systems
- Scalability under increasing workloads
- Reliability and maintainability
- Security against unauthorized access and consent bypass

---

## 4. System Architecture

The architecture of the proposed system is composed of five major layers: presentation, application, interoperability, data, and trust/provenance.

### 4.1 Presentation Layer

The presentation layer provides user interfaces for different stakeholders:

- Patient portal
- Physician dashboard
- Laboratory interface
- Admin or healthcare manager console

This layer is implemented using the React frontend, which provides a responsive and modular interface for interacting with the platform.

### 4.2 Application Layer

The application layer contains the core logic of the system, including:

- authentication
- authorization
- consent evaluation
- resource access filtering
- medical workflow processing
- API orchestration

This layer is implemented using the ASP.NET Core backend, which provides a secure and modular service-based architecture.

### 4.3 Interoperability Layer

The interoperability layer is built around HL7 FHIR resources. It standardises how patient, physician, laboratory, and observation data are represented and exchanged. This layer ensures that the system can exchange clinical data in a standardised and cross-platform way.

Relevant FHIR resources include:

- Patient
- Practitioner
- ServiceRequest
- Specimen
- Observation
- DiagnosticReport
- Consent

### 4.4 Data Layer

The primary application data is stored in a relational database, with MySQL used in the prototype. The data layer stores patient, clinician, consultation, lab, and permission metadata.

Sensitive clinical data is maintained off-chain to protect privacy while still enabling efficient retrieval and processing.

### 4.5 Trust and Provenance Layer

The trust layer uses a permissioned blockchain or blockchain-inspired event mechanism to store selected consent and access events. This layer is responsible for:

- granting permissions
- revoking permissions
- validating consent status
- recording audit events
- preserving integrity and provenance

The blockchain layer does not store all patient health records. Instead, it stores evidence of access actions and permission events, thereby improving trust without compromising privacy.

---

## 5. Design Principles

The proposed framework is guided by the following principles:

### 5.1 Patient-Centric Design
The patient remains the primary authority over access to healthcare data. Access is granted only when explicitly authorised and valid under policy constraints.

### 5.2 Least Privilege
Each participant receives only the permissions required for their role and workflow. The system is designed to avoid unrestricted access.

### 5.3 Time-Bound Access
Access permissions are limited to valid time windows. Expired permissions are automatically invalidated.

### 5.4 Selective Sharing
The system allows access to selected resources rather than complete record disclosure whenever possible.

### 5.5 Auditability
Healthcare operations and access decisions must be traceable and verifiable through event logging or blockchain-backed records.

### 5.6 Interoperability
Healthcare information is exchanged using standardised FHIR resources to support data compatibility between systems.

---

## 6. Consent Model

A central part of the proposed system is its consent model. The model is designed to support dynamic and patient-controlled access decisions.

### 6.1 Consent Attributes
A consent record may contain the following attributes:

- patient identifier
- authorised actor or role
- resource scope
- validity start time
- validity end time
- status (active, revoked, expired, denied)
- purpose of access
- associated clinical workflow or request

### 6.2 Consent Lifecycle
The consent lifecycle consists of the following stages:

1. Request for access by a physician, laboratory, or other actor
2. Validation of user identity and role
3. Evaluation of patient consent policy
4. Grant or denial of access
5. Periodic validation during access lifecycle
6. Expiry or revocation when consent ends

### 6.3 Revocation and Expiry
The system must support:

- early revocation by the patient
- automatic expiry after the allowed time period
- rejection of access when the consent record is invalid or expired

This is essential because healthcare access cannot remain active indefinitely without patient approval.

---

## 7. Access Control Mechanism

The access control model combines the following mechanisms:

### 7.1 Role-Based Access Control (RBAC)
The system identifies the user’s role and limits actions according to the role’s scope.

### 7.2 Consent-Based Access Validation
The system checks whether the patient has granted access for the requested actor, purpose, and resource.

### 7.3 Temporal Validation
Access is rejected if the permission period has expired or is no longer valid.

### 7.4 Resource Filtering
Only the relevant subset of data is returned to the authorised actor.

This layered access model reduces the risk of unauthorized disclosure and supports patient-centric governance in healthcare exchange.

---

## 8. FHIR Integration Strategy

FHIR is used as the standardised representation layer for healthcare resources exchanged between system components. The system will map internal domain entities to FHIR-compatible resources to support interoperability.

### 8.1 Mapping Strategy
Internal medical entities such as patient profiles, physician records, observations, test requests, and reports are mapped to FHIR resources. For example:

- patient profile -> Patient
- physician -> Practitioner
- test order -> ServiceRequest
- lab specimen -> Specimen
- lab observation -> Observation
- final result -> DiagnosticReport
- authorization -> Consent

### 8.2 API Design
FHIR-compatible endpoints are used to expose and retrieve healthcare data, allowing seamless exchange between healthcare participants and external systems.

This approach supports interoperability and future scalability because external systems can consume the standard resource model without needing custom proprietary mappings.

---

## 9. Blockchain Integration Strategy

The blockchain layer is designed as a trust and provenance mechanism rather than a primary storage system. The system records only selected events that are essential for auditability and permission verification.

### 9.1 Events Recorded
Examples of recorded blockchain events include:

- consent granted
- consent revoked
- access request validated
- access denied due to invalid consent
- access expired
- report reviewed or retrieved by authorised actor

### 9.2 Benefits
This approach provides:

- tamper-evident access histories
- verifiable permission provenance
- traceable audit logs
- stronger assurance of policy enforcement

### 9.3 Privacy Considerations
Sensitive patient records remain off-chain. The blockchain stores metadata and integrity-related information rather than the full health record itself.

This ensures the system maintains a balance between transparency and privacy.

---

## 10. Prototype Implementation Approach

The prototype is implemented using a modular architecture based on the current project structure.

### 10.1 Backend Implementation
The backend is implemented in ASP.NET Core and exposes endpoints for core healthcare operations. It contains modules for:

- clinics
- doctors
- patients
- permissions
- medical consultations
- medical tests
- specialists
- security services

### 10.2 Frontend Implementation
The frontend is implemented using React and provides access to healthcare workflows through a user friendly interface. It includes role-based navigation and components for healthcare tasks.

### 10.3 Smart Contract / Blockchain Support
The contract deployment project provides the blockchain side of the prototype. It contains scripts for contract compilation, deployment, ABI exposure, and event monitoring.

### 10.4 Deployment and Environment
The Docker configuration supports running the full stack together, including the database, backend, and frontend in a local or test deployment environment.

---

## 11. Evaluation Methodology

The proposed system will be evaluated using a combination of functional, security, and performance-based tests.

### 11.1 Functional Evaluation
The system will be tested for:

- user registration and role assignment
- consent grant and revoke flows
- physician access to authorised data
- laboratory workflow processing
- FHIR resource generation and retrieval

### 11.2 Security Evaluation
The system will be tested against:

- unauthorized access attempts
- expired consent handling
- compromised or mismatched roles
- attempts to access data outside authorisation scope

### 11.3 Performance Evaluation
The prototype will be evaluated under increasing workloads to estimate:

- response time
- throughput
- permission validation latency
- blockchain event overhead
- storage impact

### 11.4 Interoperability Evaluation
The system will be evaluated for its ability to exchange resources in a standardised structure and support consistent workflows across stakeholders.

---

## 12. Benefits of the Proposed Design

The proposed design offers several benefits:

- improved interoperability through FHIR-based resource exchange
- patient-centric consent and access control
- reduced risk of unauthorized data disclosure
- stronger auditability and integrity assurance
- support for patient, physician, and laboratory workflows
- privacy-preserving blockchain provenance
- practical prototype suitable for research validation

---

## 13. Challenges and Limitations

Although the proposed design is promising, several challenges remain:

- complexity of consent lifecycle management
- performance impact of on-chain logging
- need for strong identity and role validation
- limitations of blockchain for storing large medical datasets
- requirement for robust FHIR resource mapping and validation
- need for governance and compliance within healthcare environments

These constraints are manageable in a research prototype and can be addressed through careful design and evaluation.

---

## 14. Conclusion

This chapter describes the system design and methodology for a secure, consent-aware FHIR and blockchain-enabled healthcare data exchange framework. The design integrates interoperability, patient consent, and provenance into a single architecture to address the core issues of healthcare data exchange.

The proposed methodology follows a practical design-science approach, combining analysis, implementation, and evaluation. The design is aligned with real healthcare requirements and provides a foundation for prototype validation in patient, physician, and laboratory scenarios.

The resulting system is intended to demonstrate that secure and interoperable healthcare data exchange is feasible when patient consent, standardised resource exchange, and blockchain-based auditability are combined in a unified architecture.
