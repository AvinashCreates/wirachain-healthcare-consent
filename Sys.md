# WiraChain Project Summary

## 1. High-level observations

This workspace contains a multi-part healthcare and blockchain platform called WiraChain. It is not a single app, but a collection of related projects that work together:

- Backend service: ASP.NET Core API for application logic, persistence, access management, and integrations.
- Frontend app: React + Vite + Redux for user-facing dashboard and workflows.
- Smart contract deployment project: Node.js + TypeScript service for contract compilation, deployment, ABI exposure, and logs.
- Docker project: orchestrates the database, backend, and frontend.
- Datasets project: contains CSV datasets used for simulations, latency, TPS, and event analysis.

Overall, the project is designed around healthcare data management with blockchain-backed permission control for clinics, doctors, patients, and medical records.

---

## 2. Project structure and architecture

### Backend project
Path: [wirachain-backend-main/wirachain-backend-main](wirachain-backend-main/wirachain-backend-main)

The backend follows a layered architecture with domain-driven organization:

- `Program.cs`
  - application bootstrap
  - DI registration
  - Swagger setup
  - JWT authentication configuration
  - controller registration
  - database initialization

- `Clinics/`
  - clinic domain logic, repositories, services, facade, controllers

- `Doctors/`
  - doctor management and doctor-related access logic

- `Patients/`
  - patient management and patient access rules

- `MedicalConsultations/`
  - consultation records, linked tests and permissions

- `MedicalSpecialties/`
  - specialty catalog and doctor specialty mapping

- `MedicalTests/`
  - medical test definitions and test-to-clinic associations

- `Permissions/`
  - access permissions and authorization logic

- `Security/`
  - authentication, JWT, account logic, token validation

- `Shared/`
  - middleware, persistence, Ethereum integration, FHIR integration, settings, utilities

- `Mapping/`
  - AutoMapper profiles for model/resource conversion

- `Tests/`
  - project test area for integration/unit coverage

This backend clearly separates:
- domain models
- repositories
- services
- facades/controllers
- common infrastructure

This is a classic layered application pattern, suitable for enterprise/api-style backends.

### Frontend project
Path: [wirachain-frontend-main/wirachain-frontend-main](wirachain-frontend-main/wirachain-frontend-main)

The frontend is a Vite React app with Redux Toolkit and RTK Query-style API slices.

Main folders:

- `src/features/`
  - `admin/`
  - `auth/`
  - `clinic/`
  - `doctor/`
  - `patient/`

- `src/redux/`
  - API layer for backend calls
  - slices and auth state management

- `src/layouts/`
  - dashboard layout and shared menu structure

- `src/components/`
  - reusable UI form/select widgets and toast system

- `src/utils/`
  - API path constants and access helpers

- `src/routers/`
  - protected route definitions by role

This frontend is built around role-based access and dashboard flows for different user types.

### Smart contract deployment project
Path: [wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main](wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main)

This project is a TypeScript service for:

- smart contract compilation
- deployment scripts
- wallet generation
- contract addresses management
- event monitoring and logs
- API endpoints for ABI and logs

Files include:

- `contracts/` for Solidity contracts
- `scripts/` for deployment and compile operations
- `src/server.ts` for the Express server
- `src/api/` for ABI/log endpoints
- `data/` for addresses and generated JSON artifacts

This is where blockchain event logic is integrated with the backend application.

### Docker project
Path: [wirachain-docker-main/wirachain-docker-main](wirachain-docker-main/wirachain-docker-main)

This project manages the environment for the app:

- MySQL database
- backend API
- frontend web app

The `docker-compose.yml` shows the stack is designed to run in containers with environment variables for DB and ports.

### Datasets project
Path: [wirachain-datasets-main/wirachain-datasets-main](wirachain-datasets-main/wirachain-datasets-main)

This project contains CSV datasets for:

- entities
- event logs
- latency measurements
- transaction throughput (TPS)

This suggests the project has benchmarking and evaluation work, likely for blockchain performance and system analysis.

---

## 3. Core functionalities of the project

### Authentication and authorization
The backend uses JWT authentication and security settings from configuration:

- user login
- token issuance and validation
- secure access for different roles
- API protection using middleware and authorization

This is implemented through the `Security` module and `Program.cs` configuration.

### Clinic management
The system manages clinics as a first-class domain entity:

- create/update/list clinics
- clinic administrators
- doctor-to-clinic assignments
- patient access tied to clinics

### Doctor management
The `Doctors` module manages:

- doctor profiles
- specialization mappings
- doctor-clinic relationships
- doctor access to patients or services

### Patient management
The `Patients` module handles:

- patient registration and profile information
- patient-clinic permission tracking
- patient permissions and access delegation

### Medical specialty and test management
The system includes catalogs for:

- specialties
- medical tests
- specialty-to-doctor mapping
- test-to-clinic mapping

This is important in medical platforms because different healthcare providers can choose different tests and specialties.

### Medical consultations
The `MedicalConsultations` area likely covers:

- consultation records
- patient consultation timelines
- linked medical tests
- permissions around consultation data

### Permission system and blockchain integration
This is one of the strongest themes of the project.

The project appears to integrate Ethereum-like permission events for granting and revoking access to patient data. This is visible in:

- `Shared.Integration.Ethereum...`
- `GrantPermissionEventEmitter`
- `RevokePermissionEventEmitter`
- `EventEmitterFactory`
- smart contract deployment project

This means the platform is not only storing medical records; it is also managing patient access and permission changes on-chain or via smart-contract event mechanisms.

### FHIR interoperability
The backend also includes FHIR settings and service modules:

- `Shared.Integration.Fhir`
- `IFhirPatientService`

This indicates the platform is designed to interoperate with healthcare standards, likely for patient data exchange or medical record representation.

### Event logging and analytics
The project includes:

- event logs dataset
- log API in the smart contract deployment project
- Ethereum event integration

This suggests monitoring, auditability, and operational analytics are part of the platform’s design.

### Performance benchmarking
The datasets project contains latency and TPS files:

- latency comparisons for AWS vs local
- TPS measurements for grant access/revoke access scenarios

This implies the project was evaluated for performance under blockchain access conditions.

---

## 4. Observed technical strengths

- Good separation of concerns across backend domains.
- Role-based healthcare workflow design is clear.
- Blockchain and healthcare integration is a strong differentiator.
- React frontend is organized into feature-driven folders.
- Docker setup makes environment startup easier if the toolchain is present.
- Data/benchmarking artifacts show the project is research and system-validation oriented, not just a simple CRUD app.

---

## 5. Observed weaknesses / risks

- This is a distributed multi-project setup; without the right environment, it is difficult to run all pieces together.
- Some path references and project names need careful checking between repos.
- The backend and frontend expect a specific runtime environment (.NET, Node, Docker, MySQL).
- The project appears to depend on a lot of external integrations (Ethereum, FHIR, MySQL), which means local setup may be sensitive to configuration and network assumptions.

---

## 6. Bottom line

This project is a healthcare permission and data management platform that combines:

- medical domain workflows
- JWT-based security
- blockchain smart contract event handling
- FHIR-compatible healthcare interoperability
- React dashboard interfaces
- Dockerized deployment and benchmarking support

In short, it is a specialized healthcare blockchain system aimed at secure access control and data management in clinical scenarios.
