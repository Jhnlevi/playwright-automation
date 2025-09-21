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
         Util_ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
      }

      [TearDown]
      public async Task Teardown()
      {
         var context = TestContext.CurrentContext;
         var status = context.Result.Outcome.Status.ToString();
         var message = context.Result.Message;
         var trace = context.Result.StackTrace;
         var name = context.Test.MethodName;

         // Log results in report.
         await Util_ResultHelper.LogResultsAsync(Page, status, message, trace!, name!);
      }

      // Close report.
      [OneTimeTearDown]
      public void ReportClose() => Util_ReportManager.QuitExtentReport();
   }
}
