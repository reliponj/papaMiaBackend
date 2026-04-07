@echo off
cd /d "%~dp0"
if "%~1"=="" (
  echo Usage: makemigrations ^<MigrationName^>
  exit /b 1
)
dotnet ef migrations add "%~1" --project papaMiaBackend.DataAccess --startup-project papaMiaBackend.Api
