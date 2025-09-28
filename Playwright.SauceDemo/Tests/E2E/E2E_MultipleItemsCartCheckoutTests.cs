using Playwright.SauceDemo.Constants.Cart;
using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Models.E2E;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Checkout;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;
using Playwright.SauceDemo.Utils.Providers;

namespace Playwright.SauceDemo.Tests.E2E
{
   internal class E2E_MultipleItemsCartCheckoutTests : BaseTest
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
      [TestCaseSource(typeof(E2EProvider), nameof(E2EProvider.GetMultipleItem))]
      public async Task E2E_MultipleItemsCartCheckoutFlow(E2ETestCase testData)
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

         // Product
         var cartItemCount = 0;

         foreach (var product in products!)
         {
            ReportManager.Log(ReportInfo, $"Adding {product.ItemName} product to cart");
            await _product.ClickAddProductToCart(ProductPageConstants.PRODUCT_ITEM, product.ItemName);
            cartItemCount++;
         }

         ReportManager.Log(ReportInfo, $"Verifying that {products.Count} product/s are added to cart.");

         var badgeCounter = await _product._header.GetTextAsync(HeaderComponentConstants.HEADER_CART_BADGE);

         Assert.That(badgeCounter, Is.EqualTo(cartItemCount.ToString()));

         await _product._header.ClickElementAsync(HeaderComponentConstants.HEADER_CART_ICON);

         // Cart
         foreach (var product in products!)
         {
            ReportManager.Log(ReportInfo, $"Verifying {product.ItemName} is present in the cart.");
            var item = Page.Locator(".cart_item_label")
               .Locator(".inventory_item_name")
               .Filter(new() { HasText = product.ItemName });
            await Expect(item).ToHaveCountAsync(1);
         }

         ReportManager.Log(ReportInfo, "Clicking 'REMOVE' button of Sauce Labs Backpack.");
         await _cart.ClickRemoveCartItem(CartPageConstants.CART_ITEM, "Sauce Labs Bolt T-Shirt");
         ReportManager.Log(ReportInfo, "Verifying that the item 'Sauce Labs Bolt T-Shirt' is removed from the cart");

         var removedItem = Page.Locator($"{CartPageConstants.CART_ITEM}:has-text(\"Sauce Labs Bolt T-Shirt\")");

         await Expect(removedItem).ToHaveCountAsync(0);

         ReportManager.Log(ReportInfo, "Clicking 'Checkout'.");
         await _cart.ClickElementAsync(CartPageConstants.CART_ITEM_CHECKOUT_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user is redirected to checkout step one page.");

         var checkoutWrapper = Page.Locator(".checkout_info_wrapper");

         Assert.That(Page.Url, Does.Contain("checkout-step-one"));
         await Expect(checkoutWrapper).ToBeVisibleAsync();

         // Checkout step one
         ReportManager.Log(ReportInfo, "Entering first name.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_FIRSTNAME, user.FirstName!);
         ReportManager.Log(ReportInfo, "Entering last name.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_LASTNAME, user.LastName!);
         ReportManager.Log(ReportInfo, "Entering postal code.");
         await _checkoutOne.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_POSTAL, user.PostalCode!);
         ReportManager.Log(ReportInfo, "Clicking 'CONTINUE'");
         await _checkoutOne.ClickElementAsync(CheckoutOnePageConstants.CHECKOUT_ONE_CONTINUE_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user is able to proceed to checkout step two.");

         var checkoutSummary = Page.Locator("#checkout_summary_container");

         Assert.That(Page.Url, Does.Contain("checkout-step-two"));
         await Expect(checkoutSummary).ToBeVisibleAsync();

         // Checkout step two
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
