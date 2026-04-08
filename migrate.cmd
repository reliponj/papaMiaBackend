@echo off
cd /d "%~dp0"
if "%~1"=="" (set CTX=UserContext) else (set CTX=%~1)
dotnet ef database update --project papaMiaBackend.DataAccess --startup-project papaMiaBackend.Api --context %CTX%
