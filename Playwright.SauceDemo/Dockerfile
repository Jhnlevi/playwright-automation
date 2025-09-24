# Base image of .NET SDK from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install systems dependencies for Playwright (Prerequisite step; Only for .NET)
RUN apt-get update && apt-get install -y \
    libnss3 \
    libatk1.0-0 \
    libcups2 \
    libxss1 \
    libasound2 \
    libx11-xcb1 \
    libxcomposite1 \
    libxdamage1 \
    libxrandr2 \
    libgbm1 \
    libgtk-3-0 \
    fonts-liberation \
    wget \
    curl \
    --no-install-recommends && \
    rm -rf /var/lib/apt/lists/*

# Set working directory in container
WORKDIR /app

# Optional: pre-create TestResults folder to avoid errors
# Your test framework may create it automatically, but this ensures safety
RUN mkdir -p /app/TestResults

# Copy project files into the container
COPY ..

# Restore NuGet packages and build the project
RUN dotnet restorew
RUN dotnet build --configuration Release

# Install Playwright browsers and CLI
RUN dotnet tool install --global Microsoft.Playwright.CLI && playwright install --with-deps

# Run tests
CMD ["dotnet", "tests", "--configuration", "Release"]