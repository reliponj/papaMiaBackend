#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")"
CTX="${1:-UserContext}"
dotnet ef database update --project papaMiaBackend.DataAccess --startup-project papaMiaBackend.Api --context "$CTX"
