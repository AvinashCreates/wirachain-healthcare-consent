# Execute Guide for the WiraChain Project

This guide explains how to run the project on both Windows and Arch Linux using the current repository structure.

---

## 1. Project structure

The workspace contains the following main folders:

- Backend: `wirachain-backend-main/wirachain-backend-main`
- Frontend: `wirachain-frontend-main/wirachain-frontend-main`
- Smart contract / ABI service: `wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main`
- Docker orchestration: `wirachain-docker-main/wirachain-docker-main`

---

## 2. Prerequisites

### Windows
Install:
- .NET 8 SDK
- Node.js LTS
- Docker Desktop with WSL2 enabled
- Git

### Arch Linux
Install:
- .NET SDK
- Node.js and npm
- Docker and Docker Compose
- MySQL only if you are not using Docker

Example package installation:

```bash
sudo pacman -Syu
sudo pacman -S dotnet-sdk nodejs npm docker docker-compose
sudo systemctl enable docker
sudo systemctl start docker
```

---

## 3. Recommended setup: run with Docker Compose

This is the easiest and most reliable method.

### Windows
Open PowerShell in the docker folder:

```powershell
cd wirachain-docker-main\wirachain-docker-main
docker compose up -d --build
```

### Arch Linux
Open terminal:

```bash
cd /home/YOUR_USER/Documents/Folder/wirachain-docker-main/wirachain-docker-main
docker compose up -d --build
```

After startup, check:

- Backend Swagger: http://localhost:5273/swagger
- Frontend: http://localhost:3000

The Docker config is defined in:

- `wirachain-docker-main/wirachain-docker-main/docker-compose.yml`
- `wirachain-docker-main/wirachain-docker-main/.env`

---

## 4. Run each project manually

### 4.1 Backend

#### Windows
```powershell
cd wirachain-backend-main\wirachain-backend-main
dotnet restore
dotnet run --urls http://localhost:5273
```

#### Arch Linux
```bash
cd /home/YOUR_USER/Documents/Folder/wirachain-backend-main/wirachain-backend-main
dotnet restore
dotnet run --urls http://localhost:5273
```

The backend uses the connection string from:

- `wirachain-backend-main/wirachain-backend-main/appsettings.json`

If MySQL is not running, the backend will fail at startup.

---

### 4.2 Frontend

#### Windows
```powershell
cd wirachain-frontend-main\wirachain-frontend-main
npm install
npm run dev -- --host 0.0.0.0 --port 3000
```

#### Arch Linux
```bash
cd /home/YOUR_USER/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main
npm install
npm run dev -- --host 0.0.0.0 --port 3000
```

Then open the browser at:

- http://localhost:3000

---

### 4.3 Smart contract / ABI service

This service is separate and supports the blockchain permission event layer.

#### Windows
```powershell
cd wirachain-smart-contract-deployment-main\wirachain-smart-contract-deployment-main
npm install
npm run dev
```

#### Arch Linux
```bash
cd /home/YOUR_USER/Documents/Folder/wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main
npm install
npm run dev
```

This project exposes the ABI/contract-related API used by the backend event emitter logic.

---

## 5. MySQL / database note

The backend and Docker setup expect MySQL to be available before backend startup.

In Docker, this is handled automatically by the compose file.

If using a local MySQL instance, confirm the DB is running and that the connection string matches the database name, user, and password.

---

## 6. Demo credentials

The backend includes seeded demo users for testing.

### Doctor
- Email: `paul.jones@gmail.com`
- Password: `1234`

### Clinic Admin
- Email: `john.doe@gmail.com`
- Password: `1234`

### Another Clinic Admin
- Email: `leonardo.grau@gmail.com`
- Password: `1234`

### System Admin
- Email: `joao.urrunaga@gmail.com`
- Password: `5678`

These are defined in the seed files under:

- `wirachain-backend-main/wirachain-backend-main/Shared/Persistence/Seeding/DoctorSeeding.cs`
- `wirachain-backend-main/wirachain-backend-main/Shared/Persistence/Seeding/ClinicAdministratorsSeeding.cs`
- `wirachain-backend-main/wirachain-backend-main/Shared/Persistence/Seeding/SystemAdministratorSeeding.cs`

---

## 7. Common troubleshooting

### 1. Backend fails because MySQL is not running
Solution:
- start Docker compose, or
- start MySQL locally, or
- confirm the connection string settings in `appsettings.json` and `.env`

### 2. Frontend cannot reach backend
Solution:
- confirm backend is running on the expected port
- verify Vite environment variables for API URL

### 3. Smart contract service not responding
Solution:
- ensure the Node service is started
- confirm the blockchain RPC and contract address are valid

---

## 8. Final run summary

### Fastest method
```bash
cd wirachain-docker-main/wirachain-docker-main
docker compose up -d --build
```

### Manual method
```bash
# backend
cd wirachain-backend-main/wirachain-backend-main
dotnet restore
dotnet run --urls http://localhost:5273

# frontend
cd wirachain-frontend-main/wirachain-frontend-main
npm install
npm run dev -- --host 0.0.0.0 --port 3000

# blockchain service
cd wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main
npm install
npm run dev
```

---

## 9. Important note for this environment

This execution guide is written for a local machine with the required tools installed. In the current sandbox environment, Docker, .NET, and Node are not installed, so the app cannot be started here directly.

The guide above is the correct setup path for Windows and Arch Linux machines.
