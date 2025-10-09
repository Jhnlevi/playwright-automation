using Playwright.Parabank.Constants.Components;
using Playwright.Parabank.Constants.Public;
using Playwright.Parabank.Pages.Protected;
using Playwright.Parabank.Pages.Public;
using Playwright.Parabank.Utils;

namespace Playwright.Parabank.Tests.UI.Protected
{
    internal class LogoutTests : BaseTest
    {
        private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;
        private LoginPage _login;
        private OverviewPage _overview;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _login = new LoginPage(Page);
            _overview = new OverviewPage(Page);

            var URL = _config.Environments.Qa.BaseUrl;

            ReportManager.Log(_info, "Navigating to Parabank Website.");
            Page.GotoAsync(URL + LoginPageConstants.URL_PATH);

            // Will need to refactor this later
            ReportManager.Log(_info, "Logging in to Parabank.");
            _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME_FIELD, "JohnnySeed12").GetAwaiter().GetResult();
            _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD_FIELD, "JohnnyPassword01").GetAwaiter().GetResult();
            _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON).GetAwaiter().GetResult();
        }

        [Category("UI")]
        [Test]
        public async Task Logout_ShouldRedirectToLoginPage()
        {
            ReportManager.Log(_info, "Clicking 'Logout' button.");
            await _overview._menu.ClickElementAsync(MenuComponentConstants.MENU_LINK_LOGOUT);
            ReportManager.Log(_info, "Verifying that the user is redirected to login page.");

            var loginPanel = Page.Locator("#loginPanel");

            await Expect(loginPanel).ToBeVisibleAsync();
            Assert.That(Page.Url, Does.Contain("index.htm"));
        }
    }
}
