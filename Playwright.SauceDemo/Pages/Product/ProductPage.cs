using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Pages.Components;

namespace Playwright.SauceDemo.Pages.Product
{
   internal class ProductPage
   {
      private readonly IPage _page;

      // Dictionary field
      private readonly Dictionary<string, ILocator> _productElements;

      // Component fields
      public HeaderComponent _header { get; }
      public FooterComponent _footer { get; }
      public MenuComponent _menu { get; }

      // Constructor
      public ProductPage(IPage page)
      {
         _page = page;

         // Components
         _header = new HeaderComponent(page);
         _footer = new FooterComponent(page);
         _menu = new MenuComponent(page);

         _productElements = new Dictionary<string, ILocator>
         {
            { ProductPageConstants.PRODUCT_SORT_DROPDOWN, _page.Locator(".product_sort_container") },
            { ProductPageConstants.PRODUCT_ITEM, _page.Locator(".inventory_item") },
            { ProductPageConstants.PRODUCT_ITEM_LABEL, _page.Locator(".inventory_item_label") },
            { ProductPageConstants.PRODUCT_ITEM_NAME, _page.Locator(".inventory_item_name")},
            { ProductPageConstants.PRODUCT_ITEM_DESCRIPTION, _page.Locator(".inventory_item_desc")},
         };
      }

      // Actions
      public async Task ClickProductByName(string field, string productItem)
      {
         var item = _productElements[field].Filter(new() { HasText = productItem });
         await item.GetByRole(AriaRole.Link, new() { Name = productItem }).ClickAsync();
      }

      public async Task ClickRemoveProductFromCart(string field, string productItem)
      {
         var item = _productElements[field].Filter(new() { HasText = productItem });
         await item.GetByRole(AriaRole.Button, new() { Name = "REMOVE" }).ClickAsync();
      }

      public async Task ClickAddProductToCart(string field, string productItem)
      {
         var item = _productElements[field].Filter(new() { HasText = productItem });
         await item.GetByRole(AriaRole.Button, new() { Name = "ADD TO CART" }).ClickAsync();
      }

      public async Task<string> GetItemName(string field, string productName)
      {
         var item = _productElements[field].Filter(new() { HasText = productName });
         return await item.InnerTextAsync();
      }

      public async Task SelectDropdownByValue(string field, string value) => await _productElements[field].SelectOptionAsync(new SelectOptionValue { Value = value });

      public ILocator IsElementDisplayed(string field) => _productElements[field];
   }
}
