using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Checkout;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests.UI.Checkout
{
   internal class CheckoutTwoTests : BaseTest
   {
      private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
      private ProductPage _product;
      private LoginPage _login;
      private CartPage _cart;
      private CheckoutOnePage _checkoutOne;
      private CheckoutTwoPage _checkoutTwo;

      [SetUp]
      public override void Setup()
      {
         base.Setup();
         _product = new ProductPage(Page);
         _login = new LoginPage(Page);
         _cart = new CartPage(Page);
         _checkoutOne = new CheckoutOnePage(Page);
         _checkoutTwo = new CheckoutTwoPage(Page);

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
      }

      [Test]
      public async Task CheckoutTwo_CompleteCheckoutProcess_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Verifying that the cart is visible to the user.");
         await Expect(_checkoutTwo.IsElementDisplayed(CheckoutTwoPageConstants.CHECKOUT_TWO_CART_LIST)).ToBeVisibleAsync();
         ReportManager.Log(ReportInfo, "Verifying that the payment summary info is visible to the user.");
         await Expect(_checkoutTwo.IsElementDisplayed(CheckoutTwoPageConstants.CHECKOUT_TWO_SUMMARY_INFO)).ToBeVisibleAsync();
         ReportManager.Log(ReportInfo, "Clicking 'FINISH' button");
         await _checkoutTwo.ClickElementAsync(CheckoutTwoPageConstants.CHECKOUT_TWO_FINISH_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the checkout process is complete, the cart is cleared, and the user is redirected to checkout complete page.");

         var checkoutCompleteContainer = Page.Locator("#checkout_complete_container");

         Assert.That(Page.Url, Does.Contain("checkout-complete"));
         await Expect(_checkoutTwo._header.IsElementDisplayed(HeaderComponentConstants.HEADER_CART_BADGE)).ToBeHiddenAsync();
         await Expect(checkoutCompleteContainer).ToBeVisibleAsync();
      }

      [Test]
      public async Task CheckoutTwo_CancelCheckoutProcess_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Verifying that the cart is visible to the user.");
         await Expect(_checkoutTwo.IsElementDisplayed(CheckoutTwoPageConstants.CHECKOUT_TWO_CART_LIST)).ToBeVisibleAsync();
         ReportManager.Log(ReportInfo, "Verifying that the payment summary info is visible to the user.");
         await Expect(_checkoutTwo.IsElementDisplayed(CheckoutTwoPageConstants.CHECKOUT_TWO_SUMMARY_INFO)).ToBeVisibleAsync();
         ReportManager.Log(ReportInfo, "Clicking 'CANCEL' button");
         await _checkoutTwo.ClickElementAsync(CheckoutTwoPageConstants.CHECKOUT_TWO_CANCEL_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that once the user cancels the checkout process, the user is redirected back to products page.");

         var productList = Page.Locator(".inventory_list");

         Assert.That(Page.Url, Does.Contain("inventory"));
         await Expect(productList).ToBeVisibleAsync();
      }
   }
}
