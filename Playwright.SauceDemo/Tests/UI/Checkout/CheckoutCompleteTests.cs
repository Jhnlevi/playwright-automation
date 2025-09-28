using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Checkout;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests.UI.Checkout
{
   internal class CheckoutCompleteTests : BaseTest
   {
      private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
      private ProductPage _product;
      private LoginPage _login;
      private CartPage _cart;
      private CheckoutOnePage _checkoutOne;
      private CheckoutTwoPage _checkoutTwo;
      private CheckoutCompletePage _checkoutComplete;

      [SetUp]
      public override void Setup()
      {
         base.Setup();
         _product = new ProductPage(Page);
         _login = new LoginPage(Page);
         _cart = new CartPage(Page);
         _checkoutOne = new CheckoutOnePage(Page);
         _checkoutTwo = new CheckoutTwoPage(Page);
         _checkoutComplete = new CheckoutCompletePage(Page);

         ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
         Page.GotoAsync(_config.BaseUrl);
         ReportManager.Log(ReportInfo, "Login as standard user");
         TestPreconditions.LoginAsStandardUserAsync(_login).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Adding three (3) items to cart.");
         TestPreconditions.AddItemsToCartAsync(_product).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Navigate to cart.");
         TestPreconditions.NavigateToCart(_product).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Navigate to checkout step one.");
         TestPreconditions.NavigateToCheckoutOne(_cart).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Enter data in fields and navigate to checkout step two.");
         TestPreconditions.ProceedToCheckoutTwo(_checkoutOne).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Finishing the checkout process.");
         TestPreconditions.ProceedToCompletePage(_checkoutTwo).GetAwaiter().GetResult();
      }

      [Test]
      public async Task CheckoutComplete_ProcessComplete_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Verifying the user is able to complete the checkout process.");
         await Expect(_checkoutComplete.IsElementDisplayed(CheckoutCompletePageConstants.CHECKOUT_COMPLETE_CONTAINER)).ToBeVisibleAsync();
      }
   }
}
