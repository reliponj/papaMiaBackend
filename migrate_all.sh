#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
DATA=papaMiaBackend.DataAccess
API=papaMiaBackend.Api
contexts=(
  RoleContext
  UserContext
  ProductContext
  LocationContext
  BannerContext
  PromocodeContext
  OrderContext
  ArticleContext
  IngridientContext
  CustomPizzaContext
)
for ctx in "${contexts[@]}"; do
  echo "Applying $ctx..."
  dotnet ef database update --project "$DATA" --startup-project "$API" --context "$ctx"
done
echo "All migrations applied."
