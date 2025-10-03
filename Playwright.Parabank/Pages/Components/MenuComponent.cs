using Microsoft.Playwright;
using Playwright.Parabank.Constants.Components;

namespace Playwright.Parabank.Pages.Components
{
   internal class MenuComponent
   {
      private readonly IPage _page;

      private readonly Dictionary<string, ILocator> _menuElements;

      public MenuComponent(IPage page)
      {
         _page = page;

         _menuElements = new Dictionary<string, ILocator>
         {
            { MenuComponentConstants.MENU_LINK_OPEN_ACCOUNT, _page.GetByRole(AriaRole.Link, new() { Name = "Open New Account" })},
            { MenuComponentConstants.MENU_LINK_OVERVIEW, _page.GetByRole(AriaRole.Link, new() { Name = "Accounts Overview" })},
            { MenuComponentConstants.MENU_LINK_TRANSFER_FUNDS, _page.GetByRole(AriaRole.Link, new() { Name = "Transfer Funds" })},
            { MenuComponentConstants.MENU_LINK_BILLS_PAY, _page.GetByRole(AriaRole.Link, new() { Name = "Bill Pay" })},
            { MenuComponentConstants.MENU_LINK_FIND_TRANSACTIONS, _page.GetByRole(AriaRole.Link, new() { Name = "Find Transactions" })},
            { MenuComponentConstants.MENU_LINK_UPDATE_CONTACT_INFO, _page.GetByRole(AriaRole.Link, new() { Name = "Update Contact Info" })},
            { MenuComponentConstants.MENU_LINK_REQUEST_LOAN, _page.GetByRole(AriaRole.Link, new() { Name = "Request Loan" })},
            { MenuComponentConstants.MENU_LINK_LOGOUT, _page.GetByRole(AriaRole.Link, new() { Name = "Log Out" })}
         };
      }

      public async Task ClickElementAsync(string field) => await _menuElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _menuElements[field];
   }
}
