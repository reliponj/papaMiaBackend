# Papa Mia Backend

C# .NET Restaurant with Delivery Backend Application

## Project structure

Api / BL / DataAccess / Domain

## Features

- Full Auth + JWT + RBAC
- Full Admin CRUD divided on two swaggers
- EF + AutoMapper

## Swagger

- [Public API](https://dev.api.papamia.reliponj.online/swagger/index.html?urls.primaryName=Public+API)
- [Admin API](https://dev.api.papamia.reliponj.online/swagger/index.html?urls.primaryName=Admin+API)

## Links

| | |
|---|---|
| Frontend | [https://dev.papamia.reliponj.online/](https://dev.papamia.reliponj.online/) |
| Backend Swagger | [https://dev.api.papamia.reliponj.online/swagger](https://dev.api.papamia.reliponj.online/swagger) |

## Migrations

| Script | Description |
|--------|-------------|
| `migrate_all.cmd` | Do all migrations by every context (Windows) |
| `migrate_all.sh` | Same command (Linux/Mac) |

## Launching project

```bash
dotnet run --project papaMiaBackend.Api
```

or

```cmd
run.cmd
```
