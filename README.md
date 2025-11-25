# AzureMon – Pokémon Inventory API on Azure

AzureMon is a lightweight .NET API that manages an inventory of captured Pokémon.
It was designed as a hands-on project to cover key Azure developer skills:
- Azure App Service
- Azure SQL Database
- Entity Framework Core
- Microsoft Entra ID authentication
- Application Insights
- GitHub Actions CI/CD

The result is a small but realistic cloud service that behaves like a production application.

## Overview

AzureMon exposes endpoints to add a Pokémon, list all Pokémon, delete a Pokémon and retrieve a simple statistic (total count)

A Pokémon includes:
- id (GUID)
- name
- species
- level
- hp
- attack
- defense
- move1
- move2 (nullable)

All API routes are protected with Microsoft login (App Service Authentication).

## Architecture
- Backend: .NET 9 Minimal API
- Database: Azure SQL
- ORM: Entity Framework Core 9
- Hosting: Azure App Service
- Auth: Microsoft Entra ID (EasyAuth)
- Monitoring: Application Insights
- CI/CD: GitHub Actions

## Authentication

All routes require authentication.
To log in:
> https://azuremon-api-dev-hdebdcaddxd3f5g3.francecentral-01.azurewebsites.net/.auth/login/aad

After login, you can call any authenticated endpoint.

## Base URL

> https://azuremon-api-dev-hdebdcaddxd3f5g3.francecentral-01.azurewebsites.net/

## Endpoints

### GET /pokemon
Returns all stored Pokémon.

### POST /pokemon
Adds a Pokémon.

Example body:
``` json
{
  "name": "Sparky",
  "species": "Pikachu",
  "level": 12,
  "hp": 35,
  "attack": 55,
  "defense": 30,
  "move1": "Thunder Shock",
  "move2": "Quick Attack"
}
```

### DELETE /pokemon/{id}
Deletes a Pokémon by ID.
> DELETE /pokemon/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx

### GET /stats
Returns:
``` json
{
  "count": <total>
}
```

## Requirements
### Tools
- .NET SDK 9
- Git
- Azure Portal access
- GitHub Actions enabled

### Azure Resources
- Azure SQL Server + Database
- Azure App Service
- Application Insights
- App Registration (generated automatically by App Service Authentication)

### Configuration
The connection string must be configured in App Service. EF Core migrations must be applied to the Azure SQL database.

## Automated deployment on the repo
Deployment is automated via GitHub Actions.

Any push to main or master triggers:
1. Restore
2. Build
3. Publish
4. Deploy to Azure App Service via OIDC

Runs are visible under [this link](https://github.com/RaphLeFlamboyant/AzureMon/actions)

## Monitoring
Application Insights provides:
- Request logs
- Performance metrics
- SQL dependency tracking
- Exceptions
- Live streaming metrics