# Phase 1: Builder
FROM node:24 AS builder

# Phase 2: Builder
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY tsconfig.json ./
COPY src ./src

RUN npm run build


# Phase 2: Run
FROM node:24-alpine AS runner

WORKDIR /app
COPY package*.json ./
RUN npm install --only=production

# Copy just the result from builder
COPY --from=builder /app/dist ./dist
COPY data ./data
EXPOSE 3000

CMD ["node", "dist/server.js"]

