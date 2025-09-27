using Playwright.SauceDemo.Constants.Cart;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests.UI.Cart
{
   internal class CartTests : BaseTest
   {
      private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
      private ProductPage _product;
      private LoginPage _login;
      private CartPage _cart;

      [SetUp]
      public override void Setup()
      {
         base.Setup();
         _product = new ProductPage(Page);
         _login = new LoginPage(Page);
         _cart = new CartPage(Page);

         ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
         Page.GotoAsync(_config.BaseUrl);
         ReportManager.Log(ReportInfo, "Login as standard user");
         TestPreconditions.LoginAsStandardUserAsync(_login).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Adding three (3) items to cart.");
         TestPreconditions.AddItemsToCartAsync(_product).GetAwaiter().GetResult();
         ReportManager.Log(ReportInfo, "Navigate to cart.");
         TestPreconditions.NavigateToCart(_product).GetAwaiter().GetResult();
      }

      [Test]
      public async Task Cart_RemoveItems_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Clicking 'REMOVE' button of Sauce Labs Backpack.");
         await _cart.ClickRemoveCartItem(CartPageConstants.CART_ITEM, "Sauce Labs Backpack");
         ReportManager.Log(ReportInfo, "Verifying that the item 'Sauce Labs Backpack' is removed from the cart");

         var item = Page.Locator($"{CartPageConstants.CART_ITEM}:has-text(\"Sauce Labs Backpack\")");

         await Expect(item).ToHaveCountAsync(0);

      }

      [Test]
      public async Task Cart_VerifyContinueShopping_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Clicking 'Continue Shopping'.");
         await _cart.ClickElementAsync(CartPageConstants.CART_ITEM_CONTINUE_SHOPPING_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user is redirected to products page.");

         var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

         await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
         await Expect(inventoryContainer).ToBeVisibleAsync();
      }

      [Test]
      public async Task Cart_VerifyCheckout_ShouldSucceed()
      {
         ReportManager.Log(ReportInfo, "Clicking 'Checkout'.");
         await _cart.ClickElementAsync(CartPageConstants.CART_ITEM_CHECKOUT_BUTTON);
         ReportManager.Log(ReportInfo, "Verifying that the user is redirected to checkout step one page.");

         var checkoutWrapper = Page.Locator(".checkout_info_wrapper");

         Assert.That(Page.Url, Does.Contain("checkout-step-one"));
         await Expect(checkoutWrapper).ToBeVisibleAsync();
      }
   }
}
