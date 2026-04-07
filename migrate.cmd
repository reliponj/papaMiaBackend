@echo off
cd /d "%~dp0"
dotnet ef database update --project papaMiaBackend.DataAccess --startup-project papaMiaBackend.Api
