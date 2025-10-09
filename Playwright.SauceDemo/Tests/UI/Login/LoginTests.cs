using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Models.Login;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Utils;
using Playwright.SauceDemo.Utils.Provider;

namespace Playwright.SauceDemo.Tests.UI.Login
{
    internal class LoginTests : BaseTest
    {
        private LoginPage _login;
        private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _login = new LoginPage(Page);

            ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
            Page.GotoAsync(_config.BaseUrl);
        }

        // Tests
        [Category("UI")]
        [TestCaseSource(typeof(CustomDataSource), nameof(CustomDataSource.GetStandardUser))]
        public async Task Login_VerifyStandardUserAccount_ShouldSucceed(LoginTestCase testCase)
        {
            var data = testCase.Data;

            if (data == null)
            {
                Assert.Fail("Test data is null.");
                return;
            }

            ReportManager.Log(ReportInfo, "Entering Username.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, data.Username);
            ReportManager.Log(ReportInfo, "Entering Password.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, data.Password);
            ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
            await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");
            var inventoryContainer = Page.Locator("#inventory_container.inventory_container");
            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
            await Expect(inventoryContainer).ToBeVisibleAsync();
        }

        [TestCaseSource(typeof(LoginProvider), nameof(LoginProvider.GetPositiveCases))]
        public async Task Login_VerifyWithValidCredentials_ShouldSucceed(LoginTestCase testCase)
        {
            var data = testCase.Data;

            if (data == null)
            {
                Assert.Fail("Test data is null.");
                return;
            }

            ReportManager.Log(ReportInfo, "Entering Username.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, data.Username);
            ReportManager.Log(ReportInfo, "Entering Password.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, data.Password);
            ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
            await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");

            var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
            await Expect(inventoryContainer).ToBeVisibleAsync();
        }

        [TestCaseSource(typeof(CustomDataSource), nameof(CustomDataSource.GetInvalidCases))]
        public async Task Login_VerifyWithInvalidCredentials_ShouldFail(LoginTestCase testCase)
        {
            var data = testCase.Data;

            if (data == null)
            {
                Assert.Fail("Test data is null.");
                return;
            }

            ReportManager.Log(ReportInfo, "Entering Username.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, data.Username);
            ReportManager.Log(ReportInfo, "Entering Password.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, data.Password);
            ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
            await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that the user cannot login with invalid/missing credentials.");
            await Expect(_login.IsElementDisplayed(LoginPageConstants.LOGIN_ERROR_MESSAGE)).ToBeVisibleAsync();
        }

        [TestCaseSource(typeof(CustomDataSource), nameof(CustomDataSource.GetLockedOutUsers))]
        public async Task Login_VerifyLockedUserAccount_ShouldFail(LoginTestCase testCase)
        {
            var data = testCase.Data;

            if (data == null)
            {
                Assert.Fail("Test data is null.");
                return;
            }

            ReportManager.Log(ReportInfo, "Entering Username.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, data.Username);
            ReportManager.Log(ReportInfo, "Entering Password.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, data.Password);
            ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
            await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that the user cannot login with invalid/missing credentials.");
            await Expect(_login.IsElementDisplayed(LoginPageConstants.LOGIN_ERROR_MESSAGE)).ToBeVisibleAsync();
        }

        // Filtered test cases.
        private static class CustomDataSource
        {
            public static IEnumerable<LoginTestCase> GetStandardUser() => LoginProvider.GetPositiveCases().Where(tc => tc.Id == "TC_Login_0001_1");
            public static IEnumerable<LoginTestCase> GetLockedOutUsers() => LoginProvider.GetNegativeCases().Where(tc => tc.Type == "locked_out_user");
            public static IEnumerable<LoginTestCase> GetInvalidCases() => LoginProvider.GetNegativeCases().Where(tc => tc.Type != "locked_out_user");
        }
    }
}
