using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Models.E2E;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Checkout;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;
using Playwright.SauceDemo.Utils.Providers;

namespace Playwright.SauceDemo.Tests.E2E
{
    internal class E2E_LoginLogoutTests : BaseTest
    {
        private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
        private LoginPage _login;
        private ProductPage _product;
        private CartPage _cart;
        private CheckoutOnePage _checkoutOne;
        private CheckoutTwoPage _checkoutTwo;
        private CheckoutCompletePage _checkoutComplete;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _login = new LoginPage(Page);
            _product = new ProductPage(Page);
            _cart = new CartPage(Page);
            _checkoutOne = new CheckoutOnePage(Page);
            _checkoutTwo = new CheckoutTwoPage(Page);
            _checkoutComplete = new CheckoutCompletePage(Page);

            ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
            Page.GotoAsync(_config.BaseUrl);
        }

        [Category("E2E")]
        [TestCaseSource(typeof(E2EProvider), nameof(E2EProvider.GetLoginLogout))]
        public async Task E2E_LoginLogoutFlow(E2ETestCase testData)
        {
            var data = testData.Data;

            if (data == null)
            {
                Assert.Fail("Test data is missing.");
                return;
            }

            var user = data.User;
            var order = data.Order;
            var products = data.Order?.Products;
            var sorters = data.Order?.Sorters;


            // Login
            ReportManager.Log(ReportInfo, "Entering Username.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, user.UserName);
            ReportManager.Log(ReportInfo, "Entering Password.");
            await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, user.Password);
            ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
            await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");

            var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

            Assert.That(Page.Url, Does.Contain("inventory"));
            await Expect(inventoryContainer).ToBeVisibleAsync();

            // Logout
            ReportManager.Log(ReportInfo, "Clicking menu button.");
            await _product._header.ClickElementAsync(HeaderComponentConstants.HEADER_MENU_BUTTON);
            ReportManager.Log(ReportInfo, "Clicking 'Logout' button.");
            await _product._menu.ClickElementAsync(MenuComponentConstants.MENU_LOGOUT);
            ReportManager.Log(ReportInfo, "Verifying that user is redirected to login page after logging out.");

            var loginWrapper = Page.Locator(".login_wrapper-inner");

            Assert.That(Page.Url, Does.Contain("index"));
            await Expect(loginWrapper).ToBeVisibleAsync();
        }
    }
}
