using Microsoft.Playwright;
using Playwright.API.Models;
using Playwright.API.Utils;

namespace Playwright.API.Tests
{
    internal class BaseTest
    {
        protected AppSettings _config;
        protected IAPIRequestContext _context;
        protected ApiHelper _apiHelper;

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            _config = ConfigHelper.Load<AppSettings>("appsettings.json");

            var environment = "qa";

            await CreateAPIRequestContext(environment);

            ReportManager.CreateExtentReport(_config.AppName);
        }

        private async Task CreateAPIRequestContext(string env = "dev")
        {
            var envSettings = _config.Environments[env];

            var headers = new Dictionary<string, string>
         {
            { "Accept", envSettings.DefaultHeaders.Accept },
            { "Content-Type", envSettings.DefaultHeaders.ContentType }
         };

            var pw = await Microsoft.Playwright.Playwright.CreateAsync();

            _context = await pw.APIRequest.NewContextAsync(new()
            {
                BaseURL = envSettings.BaseUrl,
                ExtraHTTPHeaders = headers
            });

            _apiHelper = new ApiHelper(_context);
        }

        [SetUp]
        public virtual void setup()
        {
            ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void Teardown()
        {
            var context = TestContext.CurrentContext;
            var status = context.Result.Outcome.Status.ToString();
            var message = context.Result.Message ?? string.Empty;
            var trace = context.Result.StackTrace ?? string.Empty;

            TestResultHelper.LogResults(status, message, trace);
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            ReportManager.QuitExtentReport();

            if (_context != null)
                await _context.DisposeAsync();
        }
    }
}
