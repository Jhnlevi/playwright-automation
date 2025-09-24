using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Product;
using Playwright.SauceDemo.Pages.Components;

namespace Playwright.SauceDemo.Pages.Product
{
   internal class ProductDetailsPage
   {
      private readonly IPage _page;
      private readonly Dictionary<string, ILocator> _prodDetailsElements;
      public HeaderComponent _header { get; }
      public FooterComponent _footer { get; }
      public MenuComponent _menu { get; }

      // Constructor
      public ProductDetailsPage(IPage page)
      {
         _page = page;
         _header = new HeaderComponent(page);
         _footer = new FooterComponent(page);
         _menu = new MenuComponent(page);

         _prodDetailsElements = new Dictionary<string, ILocator>
         {
            { ProductDetailsPageConstants.PRODUCT_DETAILS_DESC_CONTAINER, _page.Locator("div.inventory_details_desc_container") },
            { ProductDetailsPageConstants.PRODUCT_DETAILS_DESC_NAME, _page.Locator("div.inventory_details_name") },
            { ProductDetailsPageConstants.PRODUCT_DETAILS_DESC_DESCRIPTION, _page.Locator("div.inventory_details_desc")},
            { ProductDetailsPageConstants.PRODUCT_DETAILS_ADD_TO_CART_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "ADD TO CART" }) },
            { ProductDetailsPageConstants.PRODUCT_DETAILS_REMOVE_FROM_CART_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "REMOVE" }) },
            { ProductDetailsPageConstants.PRODUCT_DETAILS_REMOVE_FROM_CART_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "<- Back" }) }
         };
      }

      //Actions
      public async Task ClickElementAsync(string field) => await _prodDetailsElements[field].ClickAsync();
      public async Task<string> GetTextAsync(string field) => await _prodDetailsElements[field].InnerTextAsync();
      public ILocator IsElementDisplayed(string field) => _prodDetailsElements[field];
   }
}
