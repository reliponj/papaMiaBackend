@echo off
cd /d "%~dp0"
if "%~1"=="" (
  echo Usage: makemigrations ^<MigrationName^> [ContextName]
  echo   ContextName: UserContext ^(default^) or ProductContext
  exit /b 1
)
if "%~2"=="" (set CTX=UserContext) else (set CTX=%~2)
dotnet ef migrations add "%~1" --project papaMiaBackend.DataAccess --startup-project papaMiaBackend.Api --context %CTX%
