using Playwright.SauceDemo.Constants.Components;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Pages.Product;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests.UI.Product
{
    internal class ProductDetailsTests : BaseTest
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
            ReportManager.Log(ReportInfo, "Clicking on item name");
            TestPreconditions.NavigateToProductDetails(_product).GetAwaiter().GetResult();
        }

        [Test]
        public async Task ProductDetails_AddItemToCart_ShouldSucceed()
        {
            ReportManager.Log(ReportInfo, "Clicking 'ADD TO CART' button.");
            await _productDetail.ClickElementAsync(ProductDetailsPageConstants.PRODUCT_DETAILS_ADD_TO_CART_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that an item is added to cart.");
            var badge = _productDetail._header.IsElementDisplayed(HeaderComponentConstants.HEADER_CART_BADGE);
            await Expect(badge).ToBeVisibleAsync();
        }

        [Test]
        public async Task ProductDetails_RemoveItemToCart_ShouldSucceed()
        {
            ReportManager.Log(ReportInfo, "Clicking 'ADD TO CART' button.");
            await _productDetail.ClickElementAsync(ProductDetailsPageConstants.PRODUCT_DETAILS_ADD_TO_CART_BUTTON);
            ReportManager.Log(ReportInfo, "Clicking 'REMOVE' button.");
            await _productDetail.ClickElementAsync(ProductDetailsPageConstants.PRODUCT_DETAILS_REMOVE_FROM_CART_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that an item is removed from cart.");
            var badge = _productDetail._header.IsElementDisplayed(HeaderComponentConstants.HEADER_CART_BADGE);
            await Expect(badge).ToBeHiddenAsync();
        }

        [Test]
        public async Task ProductDetails_RedirectUserToProductsPage()
        {
            ReportManager.Log(ReportInfo, "Clicking 'ADD TO CART' button.");
            await _productDetail.ClickElementAsync(ProductDetailsPageConstants.PRODUCT_DETAILS_ADD_TO_CART_BUTTON);
            ReportManager.Log(ReportInfo, "Clicking '<- Back' button.");
            await _productDetail.ClickElementAsync(ProductDetailsPageConstants.PRODUCT_DETAILS_BACK_BUTTON);
            ReportManager.Log(ReportInfo, "Verifying that the user is redireected back to products page.");

            var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
            await Expect(inventoryContainer).ToBeVisibleAsync();
        }
    }
}
