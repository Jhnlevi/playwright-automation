# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet build -c Release --no-restore

# Runtime stage using Playwright's official docker image
FROM mcr.microsoft.com/playwright/dotnet:v1.55.0-jammy AS final
WORKDIR /src
COPY --from=build /app ./
RUN mkdir -p /src/Reports
CMD ["dotnet", "test", "Playwright.SauceDemo.csproj", "--configuration", "Release"]