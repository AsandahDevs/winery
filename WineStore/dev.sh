#!/bin/bash

# Exit on error
set -e

echo "Installing dotnet-ef tool globally..."
dotnet tool install --global dotnet-ef --version 9.0.1

echo "Adding dotnet-ef tools to PATH..."
export PATH="$PATH:/root/.dotnet/tools"

echo "Verifying dotnet-ef installation..."
dotnet ef --version

echo "Enabling live reload..."
dotnet watch run --no-launch-profile
