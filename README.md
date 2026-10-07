# WiraChain Healthcare Consent Platform

A secure, consent-aware healthcare data exchange platform designed for patient-doctor-laboratory workflows. The project combines healthcare domain logic, FHIR-based interoperability, authorization and consent enforcement, and blockchain-backed provenance for access auditing.

## Project Overview

This repository contains a multi-service healthcare platform with the following major components:

- Backend: ASP.NET Core .NET 8 API
- Frontend: React + TypeScript + Vite
- Smart Contract Service: Node.js + TypeScript + Express
- Database: MySQL via Docker
- Datasets: benchmarking and evaluation data
- Documentation: research, project analysis, and paper-ready notes

## Repository Structure

```text
Folder/
├── wirachain-backend-main/
├── wirachain-frontend-main/
├── wirachain-smart-contract-deployment-main/
├── wirachain-docker-main/
├── wirachain-datasets-main/
├── Sys.md
├── updated.md
├── guide-ready.md
├── literature-review-base.md
├── literature-review-final.md
├── related-work-gap-analysis.md
├── system-design-and-methodology.md
├── implementation-evaluation-and-conclusion.md
├── full-project-report.md
├── project-roadmap.md
├── README.md
└── .gitignore
```

## Core Research Objective

The goal of this project is to design and prototype a secure healthcare data exchange system that:

- supports patient-controlled consent
- enables physician and laboratory access under valid permission
- standardizes medical data exchange using FHIR-based resources
- records access and consent provenance through blockchain-backed events
- provides a practical prototype for healthcare interoperability and access governance

## Technologies Used

### Backend
- ASP.NET Core
- C#
- .NET 8
- Entity Framework Core
- MySQL
- JWT Authentication
- Swagger

### Frontend
- React
- TypeScript
- Vite
- Redux Toolkit
- PrimeReact
- Tailwind CSS

### Blockchain / Smart Contract Layer
- Node.js
- TypeScript
- Express
- Ethers.js
- Solidity
- Smart contract deployment scripts

### Infrastructure
- Docker
- Docker Compose
- GitHub version control

## Key Research Themes

- Secure healthcare data exchange
- Patient consent and authorization
- Ethical and privacy-aware healthcare access
- FHIR interoperability
- Permissioned blockchain auditability
- Patient-doctor-laboratory workflows

## Current Status

This repository is being evolved from a general healthcare project foundation into a research-focused prototype for consent-aware healthcare data exchange.

## Getting Started

### Prerequisites
- .NET 8 SDK
- Node.js 20+
- Docker + Docker Compose
- Git

### Backend Setup

```bash
cd wirachain-backend-main/wirachain-backend-main
dotnet restore
dotnet run
```

### Frontend Setup

```bash
cd wirachain-frontend-main/wirachain-frontend-main
npm install
npm run dev
```

### Docker Setup

```bash
cd wirachain-docker-main/wirachain-docker-main
cp .env.template .env
docker compose up --build
```

### Smart Contract Service Setup

```bash
cd wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main
npm install
npm run dev
```

## Future Roadmap

The project will continue to evolve by:

- formalizing the consent model
- aligning internal data with FHIR resources
- strengthening backend authorization enforcement
- improving frontend consent and lab workflows
- linking blockchain events to real access decisions
- preparing final paper and evaluation documentation

## License

This project is currently intended for academic and research use.

## Contact

This repository is being developed as a major project prototype and research platform for secure healthcare data exchange.
