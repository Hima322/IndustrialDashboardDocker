# Step 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY IndustrialDashboard/IndustrialDashboard.csproj IndustrialDashboard/
RUN dotnet restore IndustrialDashboard/IndustrialDashboard.csproj

# Copy rest of code and publish
COPY . .
WORKDIR /src/IndustrialDashboard
RUN dotnet publish -c Release -o /app/publish

# Step 2: Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IndustrialDashboard.dll"]
