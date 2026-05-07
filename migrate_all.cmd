@echo off
setlocal
cd /d "%~dp0"
set DATA=papaMiaBackend.DataAccess
set API=papaMiaBackend.Api
for %%C in (RoleContext UserContext ProductContext LocationContext BannerContext PromocodeContext OrderContext ArticleContext IngridientContext) do (
  echo Applying %%C...
  dotnet ef database update --project %DATA% --startup-project %API% --context %%C || exit /b 1
)
echo All migrations applied.
