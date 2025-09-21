using Microsoft.Playwright.NUnit;
using Playwright.SauceDemo.Models;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests
{
   internal abstract class BaseTest : PageTest
   {
      protected Config _config;

      //Initialize report.
      [OneTimeSetUp]
      public void ReportSetup() => Util_ReportManager.CreateExtentReport("SauceDemo");

      [SetUp]
      public virtual void Setup()
      {
         // Load app config settings.
         _config = Util_ConfigLoader.Load<Config>("appsettings.json", "ConfigSettings");

         // Initialize report test.
         Util_ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.FullName);
      }

      // Close report.
      [OneTimeTearDown]
      public void ReportClose() => Util_ReportManager.QuitExtentReport();
   }
}
