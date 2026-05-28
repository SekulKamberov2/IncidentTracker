# Incident Tracker

Simple internal tool for tracking and resolving incidents.

## Features

- Create, list, and resolve incidents
- In-memory storage (backend)
- React + TypeScript frontend
- .NET 8 Web API backend
- Docker & Docker Compose
- E2E tests with Playwright
- CI/CD with GitHub Actions

## Tech Stack

Frontend: React, TypeScript, Vite
Backend: .NET 8, ASP.NET Core
E2E Tests: Playwright
Container: Docker, Docker Compose
CI/CD: GitHub Actions

## Quick Start

### With Docker (recommended)

docker-compose up --build

- Frontend: http://localhost:3000
- Backend API: http://localhost:5000/api/incidents
- Swagger: http://localhost:5000/swagger

### Without Docker

Backend:
cd IncidentTracker/IncidentTracker.Api
dotnet run

Frontend:
cd IncidentTrackerClient
npm install
npm run dev

## API Endpoints

GET /api/incidents - Get all incidents
POST /api/incidents - Create incident
POST /api/incidents/{id}/resolve - Resolve incident

## Testing

### E2E Tests (Playwright)

cd IncidentTrackerClient
npx playwright test

### Run with visible browser

npx playwright test --headed

## CI/CD

GitHub Actions runs automatically on push to main branch:
- Backend unit tests
- Frontend build
- E2E tests with Playwright
- Upload test reports as artifacts

## Notes

- In-memory storage only - data resets when backend restarts
- CORS configured for frontend communication
- E2E tests use unique incident titles 
- CI runs only Chromium for speed 
