# WiraChain — Local Development Setup

This guide explains how to configure and run WiraChain locally for development and testing.

## 1. Architecture

WiraChain consists of the following components:

* **Frontend:** React, TypeScript, Vite
* **Backend:** .NET / ASP.NET Core Web API
* **Database:** MySQL 8
* **Healthcare interoperability:** HAPI FHIR
* **Optional blockchain service:** Node.js / Express smart-contract and ABI service

### Service overview

| Component                       | Local URL / Port              |
| ------------------------------- | ----------------------------- |
| Frontend                        | http://localhost:5173         |
| Backend API                     | http://localhost:5273         |
| Swagger API documentation       | http://localhost:5273/swagger |
| MySQL                           | `127.0.0.1:3307`              |
| HAPI FHIR                       | http://localhost:8080/fhir    |
| Optional smart-contract service | Port `3000` by default        |

## 2. Prerequisites

Install the following software before starting:

* Git
* .NET 8 SDK
* Node.js and npm
* Docker Engine
* Docker Compose
* curl

Verify the installations:

```bash
git --version
dotnet --version
node --version
npm --version
docker --version
docker compose version
```

On Arch Linux, the basic installation commands are:

```bash
sudo pacman -Syu
sudo pacman -S --needed git dotnet-sdk nodejs npm docker docker-compose curl
sudo systemctl enable --now docker
```

If Docker requires additional permissions, configure Docker access according to the official Docker documentation.

## 3. Prepare the project workspace

Place the frontend, backend, and Docker repositories in a common workspace. The commands below assume this directory structure:

```text
Folder/
├── wirachain-frontend-main/
│   └── wirachain-frontend-main/
├── wirachain-backend-main/
│   └── wirachain-backend-main/
├── wirachain-docker-main/
│   └── wirachain-docker-main/
└── wirachain-smart-contract-deployment-main/
    └── wirachain-smart-contract-deployment-main/
```

If you have not downloaded the repositories, clone each repository using its actual GitHub URL and place it in the corresponding directory.

Set the workspace path:

```bash
export ROOT="$HOME/Documents/Folder"
```

If your workspace is somewhere else, change `ROOT` accordingly.

## 4. Configure environment variables

Navigate to the Docker project:

```bash
cd "$ROOT/wirachain-docker-main/wirachain-docker-main"
```

Create the local environment file from the provided template:

```bash
cp .env.template .env
```

If `.env` already exists, keep it and verify that the required database variables are configured.

Review the environment settings:

```bash
nano .env
```

The Docker configuration and backend startup command use these database variables:

* `DATABASE_NAME`
* `DATABASE_USER`
* `DATABASE_PASSWORD`

Use appropriate local development credentials. Never commit `.env` files or real secrets to GitHub.

## 5. Start the infrastructure

### 5.1 Start MySQL

From the Docker project directory, run:

```bash
docker compose up -d wirachain-database
docker compose ps
```

Verify that the database container is running before starting the backend.

MySQL is exposed to the host on port `3307`, while the container uses port `3306`.

### 5.2 Start HAPI FHIR

If the HAPI FHIR container already exists, start it:

```bash
docker start wirachain-fhir
```

For a first-time setup, create the container instead:

```bash
docker run -d \
  --name wirachain-fhir \
  --restart unless-stopped \
  -p 8080:8080 \
  hapiproject/hapi:latest
```

Wait for HAPI FHIR to finish starting, then check its FHIR metadata endpoint:

```bash
curl -fsS \
  -H 'Accept: application/fhir+json' \
  http://localhost:8080/fhir/metadata | head -c 200
```

A successful response confirms that the FHIR endpoint is responding.

**Important:** The default HAPI image uses an in-memory H2 database. Do not treat this default configuration as persistent healthcare data storage.

## 6. Start the backend API

Open a new terminal and run:

```bash
export ROOT="$HOME/Documents/Folder"

cd "$ROOT/wirachain-backend-main/wirachain-backend-main"

set -a
source "$ROOT/wirachain-docker-main/wirachain-docker-main/.env"
set +a

export ConnectionStrings__WiraChainDbConnection="server=127.0.0.1;port=3307;user=${DATABASE_USER};password=${DATABASE_PASSWORD};database=${DATABASE_NAME}"

dotnet restore
dotnet build --nologo
dotnet run --launch-profile http
```

The backend runs on the host and connects to MySQL through port `3307`.

Once the application starts, open:

* **Swagger UI:** http://localhost:5273/swagger
* **Backend API:** http://localhost:5273

Keep this terminal open while using the application.

## 7. Start the frontend

Open another terminal:

```bash
export ROOT="$HOME/Documents/Folder"

cd "$ROOT/wirachain-frontend-main/wirachain-frontend-main"
```

Install the project dependencies:

```bash
npm ci
```

Run the TypeScript check:

```bash
npm run type-check
```

Run the automated tests:

```bash
npm test
```

Start the Vite development server:

```bash
npm run dev -- --host 0.0.0.0
```

Open the URL printed by Vite, normally:

**http://localhost:5173**

The frontend development API configuration is read from `.env.development` and should point to:

```text
http://localhost:5273/api/v0/
```

Keep the frontend terminal open while using the application.

## 8. Optional smart-contract / ABI service

The smart-contract service is separate from the core frontend and backend startup process.

Open another terminal:

```bash
export ROOT="$HOME/Documents/Folder"

cd "$ROOT/wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main"

npm ci
npm run dev
```

The service uses port `3000` by default.

**Additional dependencies:** Blockchain consent events require an Ethereum JSON-RPC node at `localhost:8545` and a contract metadata service configured in `appsettings.json`. These services are not started by the current Docker Compose setup. Therefore, starting this optional service alone does not establish a complete blockchain integration.

## 9. Verify the running application

Check the components individually:

```bash
# MySQL container status
cd "$ROOT/wirachain-docker-main/wirachain-docker-main"
docker compose ps
```

```bash
# HAPI FHIR
curl -sS -o /dev/null \
  -w 'FHIR HTTP status: %{http_code}\n' \
  http://localhost:8080/fhir/metadata
```

```bash
# Backend
curl -sS -o /dev/null \
  -w 'Backend HTTP status: %{http_code}\n' \
  http://localhost:5273/swagger
```

Then open the frontend and test the relevant user workflows.

A successful HTTP response confirms that an endpoint responds; it does not, by itself, prove that authentication, database operations, or every application feature works correctly.

## 10. Recommended startup order

Start services in this order:

1. Docker Engine
2. MySQL container
3. HAPI FHIR container
4. .NET backend
5. React/Vite frontend
6. Optional smart-contract service and its dependencies

The frontend and backend should remain running in separate terminals during development.

## 11. Troubleshooting

### Backend cannot connect to MySQL

* Check `docker compose ps`.
* Confirm MySQL is listening on host port `3307`.
* Confirm the backend uses the same database credentials as the Docker `.env` file.

### Frontend cannot reach the backend

* Confirm the backend is running on port `5273`.
* Check `.env.development` for the correct API base URL.
* Inspect the browser developer console and Network tab for failed requests.

### HAPI FHIR connection refused

* Confirm the `wirachain-fhir` container is running.
* Wait for HAPI to complete initialization.
* Verify `http://localhost:8080/fhir/metadata`.

### Type-check or test failures

Run:

```bash
npm run type-check
npm test
```

Resolve the reported errors before assuming the frontend is ready.

### Docker build-context permission errors

If the Docker Compose build requires access to sibling project directories, check the Compose build contexts and Docker Buildx permissions. Do not assume the entire stack can run inside Docker without additional configuration: the verified development workflow runs the frontend and backend on the host and MySQL and HAPI FHIR in containers.

## 12. Database safety

* Do not run `docker compose down -v` unless you intentionally want to delete the Compose-managed database volume.
* Back up development data before schema changes.
* The backend currently uses `EnsureCreated()` and an additive consent migration; the project does not yet have a complete migration history.

## 13. Security notes

* Use development-only credentials locally.
* Never commit `.env` files, private keys, database passwords, production secrets, or patient data.
* Review authorization controls before exposing the application to external users.
* Do not use this development configuration as a production healthcare deployment without appropriate security, privacy, persistence, and operational safeguards.

## 14. Development workflow

A typical development cycle is:

1. Start infrastructure services.
2. Start the backend API.
3. Start the frontend.
4. Validate API behavior in Swagger.
5. Test relevant user workflows in the browser.
6. Run TypeScript checks and automated tests.
7. Review changes and commit them to Git.
8. Push changes to GitHub.

---

**Status:** This guide describes the local development workflow. Individual endpoints and features should be tested before describing the complete platform as production-ready.
