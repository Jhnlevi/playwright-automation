# Stage 1 - Build
# Base image of .NET SDK from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install systems dependencies for Playwright (Prerequisite step; Only for .NET)
RUN apt-get update && apt-get install -y \
    libnss3 libatk1.0-0 libcups2 libxss1 libasound2 \
    libx11-xcb1 libxcomposite1 libxdamage1 libxrandr2 \
    libgbm1 libgtk-3-0 fonts-liberation wget curl \
    --no-install-recommends && \
    rm -rf /var/lib/apt/lists/*

# Set working directory in container
WORKDIR /app

# Create folders for test outputs
RUN mkdir -p /app/TestResults /app/Reports

# Copy csproj and run dotnet restore
COPY Playwright.SauceDemo.csproj ./
RUN dotnet restore Playwright.SauceDemo.csproj

# Copy source files and build
COPY . ./
RUN dotnet build Playwright.SauceDemo.csproj --configuration Release

# Install Playwright browsers and CLI
RUN pwsh ./bin/Release/net8.0/playwright.ps1 install --with-deps

# Stage 2 - Runtime
# Base image of .NET SDK from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime

# Set working directory in container
WORKDIR /app

# Copy only compiled binaries and Playwright installation from build stage
COPY --from=build /app ./

# Reinstall Playwright browsers in runtime stage
RUN pwsh ./bin/Release/net8.0/playwright.ps1 install --with-deps

# Set PATH for Playwright CLI if needed
ENV PATH="$PATH:/root/.dotnet/tools"

# Run tests
CMD ["dotnet", "test", "Playwright.SauceDemo.csproj", "--configuration", "Release"]