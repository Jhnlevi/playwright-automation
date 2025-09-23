using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Components;

namespace Playwright.SauceDemo.Pages.Components
{
   internal class MenuComponent
   {
      private readonly IPage _page;
      private readonly Dictionary<string, ILocator> _elements;

      // Constructor
      public MenuComponent(IPage page)
      {
         _page = page;

         _elements = new Dictionary<string, ILocator>
         {
            { MenuComponentConstants.MENU_ALL_ITEMS, _page.GetByRole(AriaRole.Link, new() { Name = "All Items" } ) },
            { MenuComponentConstants.MENU_ABOUT, _page.GetByRole(AriaRole.Link, new() { Name = "About" } ) },
            { MenuComponentConstants.MENU_LOGOUT, _page.GetByRole(AriaRole.Link, new() { Name = "Logout" } ) },
            { MenuComponentConstants.MENU_RESET_APP_STATE, _page.GetByRole(AriaRole.Link, new() { Name = "Reset App State" } ) },
            { MenuComponentConstants.MENU_CLOSE, _page.GetByRole(AriaRole.Button, new() { Name = "Close Menu" }) }
         };
      }
   }
}
