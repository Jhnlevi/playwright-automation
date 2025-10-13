using Microsoft.Playwright;
using Playwright.API.Models;
using Playwright.API.Services;
using Playwright.API.Utils;

namespace Playwright.API.Tests
{
   internal abstract class BaseTest
   {
      protected AppSettings _config;
      protected IAPIRequestContext _context = null!;
      protected ApiHelper _apiHelper;
      protected PostService _postService;

      [OneTimeSetUp]
      public async Task GlobalSetup()
      {
         // Load appsettings.json
         _config = ConfigHelper.Load<AppSettings>("appsettings.json");

         // Initialize helper and services
         _apiHelper = new ApiHelper(_context);
         _postService = new PostService(_apiHelper);

         // Create new API context
         await _apiHelper.InitializeAsync(_config, "qa");

         // Set up extent report
         ReportManager.CreateExtentReport(_config.AppName);
      }

      [SetUp]
      public virtual void setup()
      {
         // Set up extent test
         ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
      }

      [TearDown]
      public void Teardown()
      {
         var context = TestContext.CurrentContext;
         var status = context.Result.Outcome.Status.ToString();
         var message = context.Result.Message ?? string.Empty;
         var trace = context.Result.StackTrace ?? string.Empty;

         // Log test results to extent report
         TestResultHelper.LogResults(status, message, trace);
      }

      [OneTimeTearDown]
      public async Task GlobalTearDown()
      {
         // Close extent report
         ReportManager.QuitExtentReport();

         // Dispose API context
         await _apiHelper.DisposeAsync();
      }
   }
}
