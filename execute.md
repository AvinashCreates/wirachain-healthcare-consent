# WiraChain Execute Guide: Arch Linux

This guide covers the current local development setup on Arch Linux: MySQL and HAPI FHIR in Docker, with the .NET backend and Vite frontend running on the host.

---

## 1. Project structure

The workspace contains the following main folders:

- Backend: `wirachain-backend-main/wirachain-backend-main`
- Frontend: `wirachain-frontend-main/wirachain-frontend-main`
- Smart contract / ABI service: `wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main`
- Docker orchestration: `wirachain-docker-main/wirachain-docker-main`

---

## 2. Prerequisites

### Arch Linux
Install:
- .NET 8 SDK
- Node.js and npm
- Docker and Docker Compose
- curl

Example package installation:

```bash
sudo pacman -Syu
sudo pacman -S --needed dotnet-sdk nodejs npm docker docker-compose curl
sudo systemctl enable --now docker
```

Add your user to the Docker group if needed, then log out and back in for the group change to take effect:

```bash
sudo usermod -aG docker "$USER"
```

---

## 3. Start MySQL

The current verified local workflow runs MySQL in Docker and the backend/frontend directly on Arch Linux.

```bash
export ROOT="$HOME/Documents/Folder"
cd "$ROOT/wirachain-docker-main/wirachain-docker-main"
if [[ ! -f .env ]]; then cp .env.template .env; fi
docker compose up -d wirachain-database
docker compose ps
```

MySQL is published at `127.0.0.1:3307`. Data is stored in the `mysql_data` Docker volume. Do not run `docker compose down -v` unless you intend to delete that database volume.

---

## 4. Run each project manually

### 4.1 HAPI FHIR

The backend uses `http://localhost:8080/fhir`. If the named container already exists, start it:

```bash
docker start wirachain-fhir
```

For first-time setup, create it instead:

```bash
docker run -d --name wirachain-fhir --restart unless-stopped -p 8080:8080 hapiproject/hapi:latest
```

Wait for HAPI to finish startup, then check FHIR R4 metadata:

```bash
curl -fsS -H 'Accept: application/fhir+json' http://localhost:8080/fhir/metadata | head -c 200
```

The default HAPI image uses in-memory H2. Its test resources may be lost if the container is removed or restarted.

---

### 4.2 Backend

```bash
export ROOT="$HOME/Documents/Folder"
cd "$ROOT/wirachain-backend-main/wirachain-backend-main"
set -a
source "$ROOT/wirachain-docker-main/wirachain-docker-main/.env"
set +a
export ConnectionStrings__WiraChainDbConnection="server=127.0.0.1;port=3307;user=${DATABASE_USER};password=${DATABASE_PASSWORD};database=${DATABASE_NAME}"
dotnet build --nologo
dotnet run --launch-profile http
```

The backend connects to the Docker-published MySQL port `3307`. It also requires HAPI FHIR on `http://localhost:8080/fhir` for patient and consent workflows. Swagger is at `http://localhost:5273/swagger`.

If MySQL or HAPI is unavailable, dependent backend operations will fail.

---

### 4.3 Frontend

```bash
cd "$HOME/Documents/Folder/wirachain-frontend-main/wirachain-frontend-main"
npm ci
npm run type-check
npm test
npm run dev -- --host 0.0.0.0
```

Vite prints the frontend URL, normally `http://localhost:5173`. The development API URL is read from `.env.development` and points to `http://localhost:5273/api/v0/`.


---

### 4.4 Optional smart contract / ABI service

This service is separate and supports the blockchain permission event layer.

```bash
cd "$HOME/Documents/Folder/wirachain-smart-contract-deployment-main/wirachain-smart-contract-deployment-main"
npm ci
npm run dev
```

This optional service uses port `3000` by default. Consent blockchain events additionally require an Ethereum JSON-RPC node at `localhost:8545` and a contract metadata service at the URL configured in `appsettings.json`; these are not started by the current Compose file.

---

## 5. Database notes

- The Compose `.env` file provides the MySQL credentials used by the backend command above.
- MySQL is exposed to the host on port `3307`; the backend must use that port when running outside Docker.
- The backend runs `EnsureCreated()` and applies an additive consent migration at startup. It no longer deletes the database, but back up data before schema changes because the project does not yet have a complete migration history.
- Never run `docker compose down -v` unless you intentionally want to erase the MySQL volume.

---

## 6. Common troubleshooting

### Backend cannot connect to MySQL

Confirm that the database container is running with `docker compose ps`, then confirm the host connection uses port `3307` and the same credentials as the Docker `.env` file.

### Frontend cannot reach backend

Confirm the backend is listening on port `5273` and that `.env.development` contains the matching Vite API base URL.

### HAPI reports connection refused

Confirm the HAPI container is running and wait for startup to finish before creating patients or consent records.

### Docker Buildx requests filesystem permission

The Compose build contexts point to sibling folders. From the Docker project directory, allow Buildx to read the parent folder, build images, then start Compose:

```bash
cd "$HOME/Documents/Folder/wirachain-docker-main/wirachain-docker-main"
docker buildx bake --file docker-compose.yml --allow=fs.read=.. --load
docker compose up -d
```

This only resolves build-context access. Current Compose does not include HAPI FHIR, and the backend container must use a Compose service hostname instead of `localhost` for FHIR. The verified development path is to keep backend/frontend on the host and MySQL/HAPI in containers.

## 7. Security and deployment notes

- Seeded accounts and private keys in the repository are development-only; rotate them before any shared deployment.
- Do not expose staff-account creation endpoints publicly. Authorization hardening is still required.
- The Docker group grants root-equivalent privileges.
- Never commit `.env` files, private keys, real credentials, or patient data.
