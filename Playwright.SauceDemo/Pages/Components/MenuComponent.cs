using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Components;

namespace Playwright.SauceDemo.Pages.Components
{
   internal class MenuComponent
   {
      private readonly IPage _page;

      // Dictionary field
      private readonly Dictionary<string, ILocator> _menuElements;

      // Constructor
      public MenuComponent(IPage page)
      {
         _page = page;

         _menuElements = new Dictionary<string, ILocator>
         {
            { MenuComponentConstants.MENU_ALL_ITEMS, _page.GetByRole(AriaRole.Link, new() { Name = "All Items" } ) },
            { MenuComponentConstants.MENU_ABOUT, _page.GetByRole(AriaRole.Link, new() { Name = "About" } ) },
            { MenuComponentConstants.MENU_LOGOUT, _page.GetByRole(AriaRole.Link, new() { Name = "Logout" } ) },
            { MenuComponentConstants.MENU_RESET_APP_STATE, _page.GetByRole(AriaRole.Link, new() { Name = "Reset App State" } ) },
            { MenuComponentConstants.MENU_CLOSE, _page.GetByRole(AriaRole.Button, new() { Name = "Close Menu" }) }
         };
      }

      // Actions
      public async Task ClickElementAsync(string field) => await _menuElements[field].ClickAsync();
      public async Task<string> GetTextAsync(string field) => await _menuElements[field].InnerTextAsync();
      public ILocator IsElementDisplayed(string field) => _menuElements[field];
   }
}
