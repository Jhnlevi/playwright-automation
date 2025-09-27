using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Models.Checkout;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Checkout;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;
using Playwright.SauceDemo.Utils.Providers;

namespace Playwright.SauceDemo.Tests.UI.Checkout
{
   internal class CheckoutOneTests : BaseTest
   {
      private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
      private ProductPage _product;
      private LoginPage _login;
      private CartPage _cart;
      private CheckoutOnePage _checkoutOne;

      [SetUp]
      public override void Setup()
      {
         base.Setup();
         _product = new ProductPage(Page);
         _login = new LoginPage(Page);
         _cart = new CartPage(Page);
         _checkoutOne = new CheckoutOnePage(Page);

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
      }

      [Category("UI")]
      [TestCaseSource(typeof(CustomDataSource), nameof(CustomDataSource.GetSingleValidTestCase))]
      public async Task CheckoutOne_VerifyValidInputs_ShouldSucceed(CheckoutOneData testData)
      {
         var data = testData;

         if (data == null)
         {
            Assert.Fail("Test data is null.");
            return;
         }

         ReportManager.Log(ReportInfo, "Entering first name.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_FIRSTNAME, data.FirstName);
         ReportManager.Log(ReportInfo, "Entering last name.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_LASTNAME, data.LastName);
         ReportManager.Log(ReportInfo, "Entering postal code.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_POSTAL, data.PostalCode);
         ReportManager.Log(ReportInfo, "Clicking 'CONTINUE'");
         await _checkoutOne.ClickElementAsync(CheckoutOnePageConstants.CHECKOUT_ONE_CONTINUE_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user is able to proceed to checkout step two.");

         var checkoutSummary = Page.Locator("#checkout_summary_container");

         Assert.That(Page.Url, Does.Contain("checkout-step-two"));
         await Expect(checkoutSummary).ToBeVisibleAsync();
      }

      [TestCaseSource(typeof(CheckoutOneProvider), nameof(CheckoutOneProvider.GetNegativeCases))]
      public async Task CheckoutOne_VerifyInvalidInputs_ShouldFail(CheckoutOneTestCase testCase)
      {
         var tc = testCase;

         if (tc == null)
         {
            Assert.Fail("Test case/s are null.");
            return;
         }

         ReportManager.Log(ReportInfo, "Entering first name.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_FIRSTNAME, tc.Data.FirstName);
         ReportManager.Log(ReportInfo, "Entering last name.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_LASTNAME, tc.Data.LastName);
         ReportManager.Log(ReportInfo, "Entering postal code.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_POSTAL, tc.Data.PostalCode);
         ReportManager.Log(ReportInfo, "Clicking 'CONTINUE'");
         await _checkoutOne.ClickElementAsync(CheckoutOnePageConstants.CHECKOUT_ONE_CONTINUE_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user cannot proceed to checkout step two with missing inputs.");
         await Expect(_checkoutOne.IsElementDisplayed(CheckoutOnePageConstants.CHECKOUT_ONE_ERROR_MESSAGE)).ToBeVisibleAsync();
      }

      [Test]
      public async Task CheckoutOne_CancelCheckoutStepOne_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Clicking 'CANCEL'");
         await _checkoutOne.ClickElementAsync(CheckoutOnePageConstants.CHECKOUT_ONE_CANCEL_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user  can cancel checkout step one process and is redirected to cart page.");

         var cartContainer = Page.Locator("#cart_contents_container");

         Assert.That(Page.Url, Does.Contain("cart"));
         await Expect(cartContainer).ToBeVisibleAsync();
      }

      // Filtered test cases.
      private static class CustomDataSource
      {
         public static IEnumerable<CheckoutOneData> GetSingleValidTestCase()
         {
            var testCase = CheckoutOneProvider.GetPositiveCases().FirstOrDefault();

            if (testCase != null)
               yield return testCase.Data;
         }
      }
   }
}
