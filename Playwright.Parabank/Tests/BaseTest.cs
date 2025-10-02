using Microsoft.Playwright.NUnit;
using Playwright.Parabank.Models;
using Playwright.Parabank.Utils;

namespace Playwright.Parabank.Tests
{
   internal class BaseTest : PageTest
   {
      protected AppSettings _config;

      [OneTimeSetUp]
      public void ReportSetup() => ReportManager.CreateExtentReport("Parabank");

      [SetUp]
      public virtual void Setup()
      {
         _config = ConfigHelper.Load<AppSettings>("appsettings.json", "ConfigSettings");

         ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
      }

      [TearDown]
      public async Task Teardown()
      {
         var context = TestContext.CurrentContext;
         var status = context.Result.Outcome.Status.ToString();
         var message = context.Result.Message;
         var trace = context.Result.StackTrace;
         var name = context.Test.MethodName;

         await ResultHelper.LogResultsAsync(Page, status, message, trace!, name!);
      }

      [OneTimeTearDown]
      public void ReportClose() => ReportManager.QuitExtentReport();
   }
}
