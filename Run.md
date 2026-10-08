# WiraChain Local Run Guide

This guide starts the verified local development stack on Arch Linux, Windows, or macOS:

- MySQL 8 in Docker, exposed to the host at port `3307`
- HAPI FHIR in Docker, exposed at port `8080`
- ASP.NET Core backend on `http://localhost:5273`
- React/Vite frontend on `http://localhost:5173`

Run the database and HAPI containers, then run the backend and frontend as host processes. Keep the backend and frontend terminals open while using the app.

## 1. Prerequisites

- .NET SDK 8.x
- Node.js and npm. The frontend has been built and tested with Node `v26.10.0`.
- Docker Engine with Docker Compose v2, or Docker Desktop on Windows/macOS
- Git, if you cloned the repository

Check versions:

```text
dotnet --version
node --version
npm --version
docker --version
docker compose version
```

## 2. Repository Locations

The commands below assume this folder layout:

```text
Folder/
├── wirachain-backend-main/wirachain-backend-main/
├── wirachain-frontend-main/wirachain-frontend-main/
├── wirachain-docker-main/wirachain-docker-main/
├── wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main/
└── wirachain-datasets-main/
```

If your `Folder` directory is somewhere else, replace the root path in the commands below.

## 3. Arch Linux

### One-time Docker setup

Start Docker and grant your user access to its socket:

```bash
sudo systemctl enable --now docker
sudo usermod -aG docker "$USER"
```

Log out and back in for the group change to apply to all applications. To refresh only the current terminal session instead, run:

```bash
newgrp docker
```

Verify Docker access:

```bash
docker run --rm hello-world
```

Membership in the `docker` group grants root-equivalent privileges.

### Terminal 1: MySQL

```bash
cd "$HOME/Documents/Folder/wirachain-docker-main/wirachain-docker-main"
```

If `.env` does not exist yet, create it from the template:

```bash
cp .env.template .env
```

Start MySQL and confirm it is running:

```bash
docker compose up -d wirachain-database
docker compose ps
```

The container publishes MySQL on host port `3307`. The database volume is retained when the container is stopped.

### Terminal 2: HAPI FHIR

The backend uses `http://localhost:8080/fhir`. Start HAPI once:

```bash
docker run -d --name wirachain-fhir --restart unless-stopped \
  -p 8080:8080 hapiproject/hapi:latest
```

If a container with that name already exists, do not run `docker run` again. Start the existing container instead:

```bash
docker start wirachain-fhir
```

Follow the first-start logs until HAPI reports that its application has started:

```bash
docker logs -f wirachain-fhir
```

Press `Ctrl+C` to stop following logs; this does not stop the container. Check the FHIR endpoint:

```bash
curl -fsS http://localhost:8080/fhir/metadata >/dev/null \
  && echo "HAPI FHIR is ready"
```

The default HAPI image uses an in-memory H2 database in this setup. FHIR test records can be lost if the HAPI container is removed or its process restarts.

### Terminal 3: Backend

```bash
cd "$HOME/Documents/Folder/wirachain-backend-main/wirachain-backend-main"
```

Load the database credentials from the Docker project's `.env` and point the host backend to MySQL's published port `3307`:

```bash
set -a
. "$HOME/Documents/Folder/wirachain-docker-main/wirachain-docker-main/.env"
set +a
export ConnectionStrings__WiraChainDbConnection="server=127.0.0.1;port=3307;user=${DATABASE_USER};password=${DATABASE_PASSWORD};database=${DATABASE_NAME}"
dotnet run --launch-profile http
```

Keep this terminal open. The backend and Swagger UI use port `5273`:

- API base: `http://localhost:5273/api/v0/`
- Swagger: `http://localhost:5273/swagger`

The backend calls HAPI during patient creation. HAPI must be ready before creating a patient.

### Terminal 4: Frontend

```bash
cd "$HOME/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main"
npm ci
npm run dev
```

`npm ci` is needed after a fresh checkout or when dependencies change. For later starts, run only `npm run dev`.

Open the URL Vite prints, normally:

```text
http://localhost:5173
```

The checked-in `.env.development` points the frontend at `http://localhost:5273/api/v0/`.

## 4. Windows (PowerShell)

Install .NET 8 SDK, Node.js/npm, and Docker Desktop. In Docker Desktop, enable the WSL 2 engine and Linux containers. Open a new PowerShell window after installation.

Set the repository root for the current PowerShell session:

```powershell
$Root = Join-Path $HOME "Documents\Folder"
```

Check the tools:

```powershell
dotnet --version
node --version
npm --version
docker --version
docker compose version
```

### Terminal 1: MySQL

```powershell
Set-Location "$Root\wirachain-docker-main\wirachain-docker-main"
if (-not (Test-Path .env)) { Copy-Item .env.template .env }
docker compose up -d wirachain-database
docker compose ps
```

### Terminal 2: HAPI FHIR

First start:

```powershell
docker run -d --name wirachain-fhir --restart unless-stopped -p 8080:8080 hapiproject/hapi:latest
```

If the container already exists:

```powershell
docker start wirachain-fhir
```

Watch startup logs; press `Ctrl+C` to stop following them without stopping HAPI:

```powershell
docker logs -f wirachain-fhir
```

Verify readiness:

```powershell
Invoke-WebRequest http://localhost:8080/fhir/metadata
```

### Terminal 3: Backend

```powershell
Set-Location "$Root\wirachain-backend-main\wirachain-backend-main"
$env:ConnectionStrings__WiraChainDbConnection = "server=127.0.0.1;port=3307;user=wirachain_user;password=wirachain_password;database=wirachain_db"
dotnet run --launch-profile http
```

The connection string values above match `.env.template`. If your Docker `.env` uses different values, substitute its `DATABASE_USER`, `DATABASE_PASSWORD`, and `DATABASE_NAME` values.

Keep this terminal open. Backend URLs:

- API base: `http://localhost:5273/api/v0/`
- Swagger: `http://localhost:5273/swagger`

### Terminal 4: Frontend

```powershell
Set-Location "$Root\wirachain-frontend-main\wirachain-frontend-main"
npm ci
npm run dev
```

For subsequent starts, `npm run dev` is sufficient. Open the URL Vite prints, normally `http://localhost:5173`.

## 5. macOS

Install .NET 8 SDK, Node.js/npm, and Docker Desktop. Start Docker Desktop and wait for the engine to be ready.

The remaining commands use the default `~/Documents/Folder` location and are the same as Arch Linux. In separate Terminal tabs/windows:

1. Start MySQL using the Arch Linux **Terminal 1** commands.
2. Start HAPI using the Arch Linux **Terminal 2** commands.
3. Start the backend using the Arch Linux **Terminal 3** commands.
4. Start the frontend using the Arch Linux **Terminal 4** commands.

If the repository is elsewhere, replace `$HOME/Documents/Folder` in those commands with its actual path.

## 6. Verify the Running Services

From another terminal:

```bash
curl -fsS http://localhost:8080/fhir/metadata >/dev/null \
  && echo "FHIR server reachable"
curl -fsS http://localhost:5273/swagger/index.html >/dev/null \
  && echo "Backend Swagger reachable"
```

Then load the Vite URL in a browser and try the workflow. Patient creation requires all three services to be available: MySQL, backend, and HAPI FHIR.

## 7. Stop the Services

Stop the foreground backend and frontend with `Ctrl+C` in their terminals. Stop containers without deleting the MySQL volume:

```bash
cd "$HOME/Documents/Folder/wirachain-docker-main/wirachain-docker-main"
docker compose stop wirachain-database
docker stop wirachain-fhir
```

To start them again later:

```bash
docker compose start wirachain-database
docker start wirachain-fhir
```

Do not use `docker compose down -v` unless you intend to delete the MySQL data volume.

## 8. Build and Test Commands

Frontend, from `wirachain-frontend-main/wirachain-frontend-main`:

```bash
npm run type-check
npm test
npm run build
```

Backend, from `wirachain-backend-main/wirachain-backend-main`:

```bash
dotnet restore
dotnet build --nologo
```

The frontend test suite has been verified on Node `v26.10.0`: 29 test files and 169 tests passed. The frontend production build also succeeded. The backend build succeeded with warnings and zero errors.

## 9. Optional Smart-Contract API

The smart-contract deployment project is not required to start the verified patient/clinic frontend and backend flow. Its package scripts currently provide a TypeScript build and a `dev` command. If you need the ABI/log API, from `wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main`:

```bash
npm install
npm run dev
```

It defaults to port `3000` (override with `PORT` if needed). Contract compilation/deployment also requires the blockchain RPC and contract configuration to be available; those operations are not part of the base startup steps above.

## 10. Current Docker Compose Limitation

The current Compose file is used here to start MySQL only. It does not define a HAPI FHIR service, and the frontend image build does not currently pass the Vite API URL build argument. Therefore, the local host-process workflow in this guide is the verified startup path. Avoid treating `docker compose up --build` as a complete working deployment until those Compose settings are updated.

The backend uses EF Core `EnsureCreated()` and this repository has no migration files. It can create a new database schema, but it will not migrate an existing schema after model changes. The destructive `EnsureDeleted()` call has been removed, so startup no longer deletes the database.
