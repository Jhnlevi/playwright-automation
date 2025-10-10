<a id="top-read"></a>
# SauceDemo Automation (Playwright .NET) 

This is a **test automation project** built with **Playwright (.NET)** for the [SauceDemo](https://www.saucedemo.com/) website.

<br>

## About The Project

This project demonstrates a complete, production style setup for implementing clean architecture practices (POMs, configuration management, data driven testing) while also integrating with modern tooling such as Docker and GitHub Actions.

It performs both UI (User Interface) and End to End (E2E) testing to ensure SauceDemo’s workflows are covered.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Features

- **Page Object Models (POMS)**: Organized and maintainable page classes.
- **Data Driven testing**: Flexible test data through `.json` files, constants and dictionaries (.NET).
- **Cross Browser Testing**: Supports execution across **Chromium, Firefox, and WebKit**, ensuring consistent behavior and compatibility across major browsers.
- **Configuration Manager**: Centralized setting with `appsettings.json`.
- **Reporting**: Integrated `ExtentReports` with screenshots capture on failed test runs.
- **Playwright**: Fully utilizes Playwright's capabilities (`PageTest`, `Page`, `Expect`, and more) for reliable, expressive test automation.
- **Docker Integration**: Packaged into a custom Docker image with `docker-compose` support, enabling consistent, reproducible test runs across environments.
- **Continuous Integration**: Integrated GitHub Actions pipeline that runs tests inside the custom Docker image for reliable CI/CD automation.  
- **Test Coverage**: Comprehensive **UI** and **E2E** scenarios using NUnit attributes, covering login, cart, checkout, and more.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Installation

These steps will set up the project locally, install required dependencies, and ensure all browsers are available for cross browser testing.

- **Prerequisites:**
  - [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - [Docker Desktop](https://www.docker.com/products/docker-desktop/) (optional, if using Docker commands)

- **Clone the repository:**

```
# For the repository url: Go to the repository, click "<> Code", copy the url, and paste it in <repository-url>.

  git clone <repository-url>

  cd Playwright.SauceDemo
```

- **Restore .NET dependencies:**

```
  dotnet restore
```

- **Install Playwright Browsers (Windows):**

  From the project root, run:
```
# Allow running scripts for Playwright installation

  Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

# Install Playwright browsers
  
  .\bin\Debug\net8.0\playwright.ps1 install

```

- **Install Playwright Browsers (Linux/macOS):**

  From the project root, run:
```
# Install Playwright browsers

  dotnet run --project Playwright.SauceDemo -- install
```

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Running Tests

- **Run tests locally:**

```
# Run all tests:

  dotnet test

# Run a single test:

  dotnet test --filter "TestName=YourTestName"

# Run tests in Chromium only:

  dotnet test -- TestBrowser=chromium

# Run tests in Firefox:
  
  dotnet test -- TestBrowser=firefox
```

- **Run tests in Docker:**

```
  docker compose build saucedemo

  docker compose run --rm saucedemo
```

- **Run tests in CI:**

  *GitHub Actions is configured to run tests inside the Docker container automatically (Check CI YAML file in the file structure).*

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Project Structure

```
PlaywrightAutomation.sln                 # The solution file
  .github/
    workflows/
      ci-playwright.yml                  # GitHub Actions CI pipeline
  docker-compose.yml                     # Docker compose file 

Playwright.SauceDemo/                    # The main project root
  Constants/                             # Contains dictionary keys and constants for POMs, and tests
  Models/                                # Contains all data models to map .json files
  Pages/                                 # Contains Page Object Model classes
  Reports/                               # Contains all reports (ExtentReports)
    Screenshots/                         # Contains screenshots captured on test failures
  TestData/                              # Contains .json files for data driven testing
  Tests/                                 # Contains all test classes
  Utils/                                 # Contains all utility classes
  appsettings.json 
  Dockerfile                             # Custom docker image for this project
  .dockerignore                          # Files/folders ignored in Docker build
```

### Explanation of Key Folders:

- **Constants/**: Holds keys and constants used throughout POMs and test classes to improve maintainability.
- **Models/**:  Maps JSON test data into structured objects for cleaner, reusable code.
- **Pages/**:  Implements the Page Object Model, encapsulating locators and page actions.
- **Reports/**: Contains test reports and screenshots for debugging failures.
- **TestData/**: JSON files that feed test inputs for Data Driven Tests (DDT).
- **Tests/**: Divided into UI and E2E (full workflow) test classes.
- **Utils/**: Utility or helper functions used across tests and page objects.
- **appsettings.json**: Centralized configuration for environments, URLs, and browser settings.
- **Dockerfile & docker-compose.yml**: Optional Docker setup to run tests in a consistent environment.
- **.github/workflows/**: CI/CD configuration using GitHub Actions to automate test execution.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Built With

- ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
- ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
- ![Playwright](https://img.shields.io/badge/-playwright-%232EAD33?style=for-the-badge&logo=playwright&logoColor=white)
- ![GitHub Actions](https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white)
- ![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Contributing

Contributions, issues, and feature requests are welcome!  

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement". Don't forget to give the project a star! Thanks again!

- Fork the repository.
- Choose the project.
- Create your feature branch `git checkout -b feature/project/your-amazing-feature`.
- Commit your changes `git commit -m 'Add some AmazingFeature'`.
- Push your branch `git push origin feature/project/your-amazing-feature`.
- Open a Pull Request.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Author

- John Levi P. Barcenas - [@Jhnlevi](https://github.com/Jhnlevi)

<p align="right">(<a href="#top-read">back to top</a>)</p>