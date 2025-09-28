using Playwright.SauceDemo.Constants.Cart;
using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Pages.Cart;
using Playwright.SauceDemo.Pages.Checkout;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils.Providers;

namespace Playwright.SauceDemo.Utils
{
   internal class TestPreconditions
   {
      private const string LoginUsername = "standard_user";
      private const string LoginPassword = "secret_sauce";

      /// <summary>
      /// Precondition #1: Login as standard user
      /// </summary>
      public static async Task LoginAsStandardUserAsync(LoginPage page)
      {
         await page.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, LoginUsername);
         await page.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, LoginPassword);
         await page.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
      }

      /// <summary>
      /// Precondition #2: Add three items to the cart
      /// </summary>
      public static async Task AddItemsToCartAsync(ProductPage page)
      {
         // Get three items
         var items = ProductProvider.GetAllProducts().Take(3).ToList();

         foreach (var item in items)
         {
            await page.ClickAddProductToCart(ProductPageConstants.PRODUCT_ITEM, item.ItemName);
         }
      }

      /// <summary>
      /// Precondition #3: Click item to open product details page
      /// </summary>
      public static async Task NavigateToProductDetails(ProductPage page)
      {
         var item = ProductProvider.GetAllProducts().FirstOrDefault();

         if (item != null)
            await page.ClickProductByName(ProductPageConstants.PRODUCT_ITEM, item.ItemName);
      }

      /// <summary>
      /// Precondition #4: Click cart icon to go to cart page
      /// </summary>
      public static async Task NavigateToCart(ProductPage page)
      {
         await page._header.ClickElementAsync(HeaderComponentConstants.HEADER_CART_ICON);
      }

      /// <summary>
      /// Precondition #5: Click checkout button to go to checkout
      /// </summary>
      public static async Task NavigateToCheckoutOne(CartPage page)
      {
         await page.ClickElementAsync(CartPageConstants.CART_ITEM_CHECKOUT_BUTTON);
      }

      /// <summary>
      /// Precondition #6: Entering first name, last name, and postal code, then clicking continue button
      /// </summary>
      /// 
      public static async Task ProceedToCheckoutTwo(CheckoutOnePage page)
      {
         await page.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_FIRSTNAME, "precondition-first-name");
         await page.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_LASTNAME, "precondition-first-name");
         await page.EnterTextAsync(CheckoutOnePageConstants.CHECKOUT_ONE_POSTAL, "precondition122333");
         await page.ClickElementAsync(CheckoutOnePageConstants.CHECKOUT_ONE_CONTINUE_BUTTON);
      }

      /// <summary>
      /// Precondition #7: Clicking 'FINISH' button in checkout step two
      /// </summary>
      public static async Task ProceedToCompletePage(CheckoutTwoPage page)
      {
         await page.ClickElementAsync(CheckoutTwoPageConstants.CHECKOUT_TWO_FINISH_BUTTON);
      }
   }
}
