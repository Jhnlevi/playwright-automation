# SauceDemo Project (Playwright)

A web automation project using Playwright to perform UI and End-To-End (E2E) testing on SauceDemo website.

## Description

This project is a work in progress Playwright automation framework built in C#/.NET. It currently focuses on automating the login workflow on SauceDemo and aims to provide:

- A modular Page Object Model (POM) structure for scalable test development
- Centralized configuration management with appsettings.json
- Automated browser testing using Playwright’s Page and Locator APIs
- Screenshots for debugging and reporting
- HTML reporting with ExtentReports

The framework will expand to include additional pages, user flows, and E2E test scenarios as development continues.

## Features

Here are the implemented features (so far):

- Implemented Playwright integration in .NET for browser automation
- Page Object Model (POM) for the login page (Page_Login) with reusable locators and actions
- BaseTest class using PageTest for shared browser setup
- Configuration management with appsettings.json and loader utilities
- ExtentReports integration for generating HTML reports
- Screenshot capture for visual debugging and reporting

Upcomming Features:

- Additional POM classes for other pages (inventory, checkout, etc.)
- Implement Data-Driven Testing (DDT) to run tests with multiple sets of input data efficiently
- Expand E2E test coverage using DDT for login, inventory, and checkout scenarios

## Getting Started

*Steps will be added here as I build the project*

## Tech Stack

Language: C#
Automation Framework: Playwright for .NET
Testing Framework: NUnit
Reporting: ExtentReports
Configuration: appsettings.json
CI/CD: Can integrate with GitHub Actions or other pipelines

## Author

- John Levi P. Barcenas - [@Jhnlevi](https://github.com/Jhnlevi)