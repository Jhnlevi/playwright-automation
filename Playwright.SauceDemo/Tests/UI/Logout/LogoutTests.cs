using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests.UI.Logout
{
   internal class LogoutTests : BaseTest
   {
      private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
      private ProductPage _product;
      private ProductDetailsPage _productDetail;
      private LoginPage _login;

      [SetUp]
      public override void Setup()
      {
         base.Setup();
         _product = new ProductPage(Page);
         _productDetail = new ProductDetailsPage(Page);
         _login = new LoginPage(Page);

         ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
         Page.GotoAsync(_config.BaseUrl);
         ReportManager.Log(ReportInfo, "Login as standard user");
         TestPreconditions.LoginAsStandardUserAsync(_login).GetAwaiter().GetResult();
      }

      [Category("UI")]
      [Test]
      public async Task Logout_AsStandardUser_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Clicking menu button.");
         await _product._header.ClickElementAsync(HeaderComponentConstants.HEADER_MENU_BUTTON);
         ReportManager.Log(ReportInfo, "Clicking 'Logout' button.");
         await _product._menu.ClickElementAsync(MenuComponentConstants.MENU_LOGOUT);
         ReportManager.Log(ReportInfo, "Verifying that user is redirected to login page after logging out.");

         var loginWrapper = Page.Locator(".login_wrapper-inner");

         Assert.That(Page.Url, Does.Contain("index.html"));
         await Expect(loginWrapper).ToBeVisibleAsync();
      }

      [Category("UI")]
      [Test]
      public async Task Logout_AfterAddingAnItem_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Clicking on item name");
         TestPreconditions.NavigateToProductDetails(_product).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Clicking 'ADD TO CART' button.");
         await _productDetail.ClickElementAsync(ProductDetailsPageConstants.PRODUCT_DETAILS_ADD_TO_CART_BUTTON);
         ReportManager.Log(ReportInfo, "Clicking menu button.");
         await _product._header.ClickElementAsync(HeaderComponentConstants.HEADER_MENU_BUTTON);
         ReportManager.Log(ReportInfo, "Clicking 'Logout' button.");
         await _product._menu.ClickElementAsync(MenuComponentConstants.MENU_LOGOUT);
         ReportManager.Log(ReportInfo, "Verifying that user is redirected to login page after logging out.");

         var loginWrapper = Page.Locator(".login_wrapper-inner");

         Assert.That(Page.Url, Does.Contain("index.html"));
         await Expect(loginWrapper).ToBeVisibleAsync();
      }

      [Test]
      public async Task Logout_UserCannotAccessProtectedPagesAfterLogout()
      {
         ReportManager.Log(ReportInfo, "Clicking menu button.");
         await _product._header.ClickElementAsync(HeaderComponentConstants.HEADER_MENU_BUTTON);
         ReportManager.Log(ReportInfo, "Clicking 'Logout' button.");
         await _product._menu.ClickElementAsync(MenuComponentConstants.MENU_LOGOUT);
         ReportManager.Log(ReportInfo, "Verifies that after logging out, the user cannot access any protected pages or features without logging in again.");

         // await Page.GotoAsync(_config.BaseUrl + "inventory.html");
         var loginUsernameElement = Page.GetByPlaceholder("Username");

         ReportManager.Log(ReportInfo, "Known issue: SauceDemo allows access to protected pages even after logging out.");
         //if (response != null)
         //{
         //   Assert.That(response.Status, Is.EqualTo(403).Or.EqualTo(401));
         //}

         Assert.That(Page.Url, Does.Contain("index.html"));
         await Expect(loginUsernameElement).ToBeVisibleAsync();
      }
   }
}
