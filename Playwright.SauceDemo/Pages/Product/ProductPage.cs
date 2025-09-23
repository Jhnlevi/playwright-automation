using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Product;

namespace Playwright.SauceDemo.Pages.Product
{
   internal class ProductPage
   {
      private readonly IPage _page;
      private readonly Dictionary<string, ILocator> _elements;

      // Constructor
      public ProductPage(IPage page)
      {
         _page = page;
         _elements = new Dictionary<string, ILocator>
         {
            { ProductPageConstants.PRODUCT_SORT_DROPDOWN, _page.Locator(".product_sort_container") },
            { ProductPageConstants.PRODUCT_ITEM_LABEL, _page.Locator(".inventory_item_label") },
            { ProductPageConstants.PRODUCT_ITEM_CARD, _page.Locator(".inventory_item") },
            { ProductPageConstants.PRODUCT_ITEM_NAME, _page.Locator(".inventory_item_name")},
            { ProductPageConstants.PRODUCT_ITEM_DESCRIPTION, _page.Locator(".inventory_item_desc")},
         };
      }

      // Actions
      public async Task ClickItemByName(string field, string productName)
      {
         var item = _elements[field].Filter(new() { HasText = productName });
         await item.GetByRole(AriaRole.Link).ClickAsync();
      }

      public async Task ClickItemAddRemove(string field, string buttonName, string productName)
      {
         var item = _elements[field].Filter(new() { HasText = productName });
         var button = item.GetByRole(AriaRole.Button, new() { Name = buttonName });
         await button.ClickAsync();
      }

      public async Task<string> GetItemName(string field, string productName)
      {
         var item = _elements[field].Filter(new() { HasText = productName });

         return await item.InnerTextAsync();
      }

      public ILocator IsElementDisplayed(string field) => _elements[field];
   }
}
