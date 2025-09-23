using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Components;

namespace Playwright.SauceDemo.Pages.Components
{
   internal class HeaderComponent
   {
      private readonly IPage _page;
      private readonly Dictionary<string, ILocator> _elements;

      // Constructor
      public HeaderComponent(IPage page)
      {
         _page = page;

         _elements = new Dictionary<string, ILocator>
         {
            { HeaderComponentConstants.HEADER_MENU_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" } ) },
            { HeaderComponentConstants.HEADER_CART_ICON, _page.Locator(".shopping_cart_link") },
            { HeaderComponentConstants.HEADER_CART_BADGE, _page.Locator(".shopping_cart_badge") }
         };
      }

      // Actions
      public async Task ClickElementAsync(string field) => await _elements[field].ClickAsync();
      public async Task<string> GetTextAsync(string field) => await _elements[field].InnerTextAsync();
      public ILocator IsElementDisplayed(string field) => _elements[field];
   }
}
