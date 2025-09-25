using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Models.Product;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;
using Playwright.SauceDemo.Utils.Providers;

namespace Playwright.SauceDemo.Tests.UI.Product
{
   internal class ProductTests : BaseTest
   {
      private readonly ReportManager.LogLevel ReportInfo = ReportManager.LogLevel.Info;
      private ProductPage _product;
      private LoginPage _login;

      [SetUp]
      public override void Setup()
      {
         base.Setup();
         _product = new ProductPage(Page);
         _login = new LoginPage(Page);

         ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
         Page.GotoAsync(_config.BaseUrl);
         ReportManager.Log(ReportInfo, "Login as standard user");
         TestPreconditions.LoginAsStandardUser(_login).GetAwaiter().GetResult();
      }

      [TestCaseSource(typeof(ProductProvider), nameof(ProductProvider.GetAllSorters))]
      public async Task Product_VerifyProductListSort_ShouldSort(ProductSortTestCase testCase)
      {
         bool isSorted;
         var data = testCase;
         var originalOrder = await Page.Locator(".inventory_item_name").AllTextContentsAsync();
         var originalPrices = await Page.Locator(".inventory_item_price").AllTextContentsAsync();

         ReportManager.Log(ReportInfo, $"Selecting dropdown option: {data.SortName}");
         await _product.SelectDropdownByValue(ProductPageConstants.PRODUCT_SORT_DROPDOWN, data.SortValue);

         var newOrder = await Page.Locator(".inventory_item_name").AllTextContentsAsync();
         var newPrices = await Page.Locator(".inventory_item_price").AllTextContentsAsync();

         switch (data.SortValue)
         {
            case "za":
               isSorted = newOrder.SequenceEqual(newOrder.OrderByDescending(x => x));
               break;
            case "lohi":
               var pricesLoHi = newPrices.Select(x => decimal.Parse(x.Replace("$", ""))).ToList();
               isSorted = pricesLoHi.SequenceEqual(pricesLoHi.OrderBy(x => x));
               break;
            case "hilo":
               var pricesHiLo = newPrices.Select(x => decimal.Parse(x.Replace("$", ""))).ToList();
               isSorted = pricesHiLo.SequenceEqual(pricesHiLo.OrderByDescending(x => x));
               break;
            default:
               isSorted = true;
               break;
         }

         ReportManager.Log(ReportInfo, "Verifying that product lists are sorted.");
         Assert.That(isSorted, Is.True, $"Products are not sorted correctly for {data.SortName}");
      }

      [TestCaseSource(typeof(CustomDataSource), nameof(CustomDataSource.GetSingleTestCase))]
      public async Task Product_VerifyNavigationProductDetails_ShouldSucceed(ProductTestCase testCase)
      {
         ReportManager.Log(ReportInfo, "Clicking the product name.");
         await _product.ClickProductByName(ProductPageConstants.PRODUCT_ITEM, testCase.ItemName);
         ReportManager.Log(ReportInfo, $"Verifying that the user is redirected to product details page of {testCase.ItemName}");

         var inventoryDetails = Page.Locator(".inventory_details_container");

         Assert.That(Page.Url, Does.Contain("inventory-item.html?id="));
         await Expect(inventoryDetails).ToBeVisibleAsync();
      }

      [Category("UI")]
      [Test]
      public async Task Product_VerifyAddingProductsToCart_ShouldSucceed()
      {
         var testCase = CustomDataSource.GetThreeTestCases().ToList();

         int count = 0;

         foreach (var data in testCase)
         {
            ReportManager.Log(ReportInfo, $"Adding {data.ItemName} product to cart");
            await _product.ClickAddProductToCart(ProductPageConstants.PRODUCT_ITEM, data.ItemName);
            count++;
         }
         ReportManager.Log(ReportInfo, $"Verifying that {testCase.Count} product/s are added to cart.");
         var badgeCounter = await _product._header.GetTextAsync(HeaderComponentConstants.HEADER_CART_BADGE);
         Assert.That(badgeCounter, Is.EqualTo(count.ToString()));
      }

      [Category("UI")]
      [Test]
      public async Task Product_VerifyRemovingProductsToCart_ShouldSucceed()
      {
         var addThreeCases = CustomDataSource.GetThreeTestCases().ToList();
         var removeTwoCases = CustomDataSource.GetTwoTestCases().ToList();

         // Add three test case first
         foreach (var data in addThreeCases)
         {
            ReportManager.Log(ReportInfo, $"Adding {data.ItemName} product to cart");
            await _product.ClickAddProductToCart(ProductPageConstants.PRODUCT_ITEM, data.ItemName);
         }

         var oldCounter = await _product._header.GetTextAsync(HeaderComponentConstants.HEADER_CART_BADGE);
         int oldCount = Convert.ToInt32(oldCounter);

         foreach (var data in removeTwoCases)
         {
            ReportManager.Log(ReportInfo, $"Removing {data.ItemName} product to cart");
            await _product.ClickRemoveProductFromCart(ProductPageConstants.PRODUCT_ITEM, data.ItemName);
            oldCount--;
         }

         ReportManager.Log(ReportInfo, $"Verifying that {removeTwoCases.Count} product/s are removed from cart.");

         var newCounter = await _product._header.GetTextAsync(HeaderComponentConstants.HEADER_CART_BADGE);
         var newCount = Convert.ToInt32(newCounter);

         Assert.That(newCount, Is.EqualTo(oldCount));
      }

      // Filtered test cases.
      private static class CustomDataSource
      {
         public static IEnumerable<ProductTestCase> GetSingleTestCase()
         {
            var product = ProductProvider.GetAllProducts().FirstOrDefault();
            if (product != null)
               yield return product;
         }

         public static IEnumerable<ProductTestCase> GetTwoTestCases() => ProductProvider.GetAllProducts().Take(2);
         public static IEnumerable<ProductTestCase> GetThreeTestCases() => ProductProvider.GetAllProducts().Take(3);
      }
   }
}
