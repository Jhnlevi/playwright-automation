<a id="top-read"></a>
# JsonPlaceholder API Automation (Playwright .NET) 

This is an **API test automation project** built with **Playwright (.NET)** for the [JsonPlacehodler](https://jsonplaceholder.typicode.com/) API.

<br>

## About The Project

This project focuses on automating the testing of the JsonPlaceholder API endpoints using Playwright with C#. The primary goal is to gain hands-on experience in **API automation testing** and to further strengthen my Playwright and overall automation testing skills.

The project follows testing best practices similar to my other automation projects. It is designed purely with testing in mind, without CI/CD or Docker integration, as my current focus is on becoming fully familiar with API testing fundamentals.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Features

- **API Helper**: Handles HTTP requests and responses for all API endpoints, providing reusable methods for `GET`, `POST`, `PUT`, and `DELETE` operations.
- **Configuration Manager**: Centralized setting with `appsettings.json`.
- **Reporting**: Integrated `ExtentReports` with detailed logging and automatic report generation after each test run.
- **Playwright**: Utilizes Playwright's robust test runner and assertion library (`Test`, `Expect`, and more) to structure and validate API tests effectively without involving any browser automation.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Installation

These steps will set up the project locally, install required dependencies, and ensure all browsers are available for cross browser testing.

- **Prerequisites:**
  - [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

- **Clone the repository:**

```
# For the repository url: Go to the repository, click "<> Code", copy the url, and paste it in <repository-url>.

  git clone <repository-url>

  cd Playwright.API
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

  dotnet run --project Playwright.API -- install
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

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Project Structure

```
PlaywrightAutomation.sln                 # The solution file
  .github/
    workflows/
      ci-playwright.yml                  # GitHub Actions CI pipeline
  docker-compose.yml                     # Docker compose file 

Playwright.API/                    # The main project root
  Models/                                # Contains all data models to map .json files
  Reports/                               # Contains all reports (ExtentReports)
  Services/                              # Contains service classes for API
    Interfaces/                          # Contains interface classes for services
  Tests/                                 # Contains all test classes
  Utils/                                 # Contains all utility classes
  appsettings.json 
```

### Explanation of Key Folders:

- **Models/**:  Maps JSON test data into structured objects for cleaner, reusable code.
- **Reports/**: Contains test reports and screenshots for debugging failures.
- **Services/**: Contains service classes.
- **Interfaces/**: Contains interface classes.
- **Tests/**: Divided into UI and E2E (full workflow) test classes.
- **Utils/**: Utility or helper functions used across tests and page objects.
- **appsettings.json**: Centralized configuration for environments, URLs, and browser settings.

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
- Create your feature branch `git checkout -b project/your-amazing-feature`.
- Commit your changes `git commit -m 'Add some AmazingFeature'`.
- Push your branch `git push origin project/your-amazing-feature`.
- Open a Pull Request.

<p align="right">(<a href="#top-read">back to top</a>)</p>

## Author

- John Levi P. Barcenas - [@Jhnlevi](https://github.com/Jhnlevi)

<p align="right">(<a href="#top-read">back to top</a>)</p>