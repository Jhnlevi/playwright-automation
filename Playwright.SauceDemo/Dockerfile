# Build stage using dotnet sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
# Copy .csproj file and run dotnet restore
COPY Playwright.SauceDemo.csproj ./
RUN dotnet restore
# After copying .csproj, copy all files and run dotnet build on release
COPY . ./
RUN dotnet build Playwright.SauceDemo.csproj -c Release --no-restore

# Runtime stage using Playwright's official docker image
FROM mcr.microsoft.com/playwright/dotnet:v1.55.0-jammy AS final
WORKDIR /src
# Copt all files from build stage
COPY --from=build /app ./
# Create a folder for reports
RUN mkdir -p /src/Reports
# Run dotnet test
CMD ["dotnet", "test", "Playwright.SauceDemo.csproj", "--configuration", "Release"]