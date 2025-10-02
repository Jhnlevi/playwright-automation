# Build stage; Using Playwright's official docker image
FROM mcr.microsoft.com/playwright/dotnet:v1.55.0-jammy AS build
WORKDIR /src

# Create a folder for reports
RUN mkdir -p /src/Reports

# Copy .csproj file and run dotnet restore
COPY Playwright.Parabank.csproj ./
RUN dotnet restore

# After copying .csproj, copy all files and run dotnet build on release
COPY . ./
RUN dotnet build Playwright.Parabank.csproj -c Release --no-restore

# Runtime stage
FROM mcr.microsoft.com/playwright/dotnet:v1.55.0-jammy AS runtime
WORKDIR /src

# Copy only build outputs
COPY --from=build /src ./

# Run dotnet test
CMD ["dotnet", "test", "Playwright.Parabank.csproj", "--configuration", "Release"]