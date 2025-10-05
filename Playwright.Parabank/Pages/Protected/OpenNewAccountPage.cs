using Microsoft.Playwright;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
   internal class OpenNewAccountPage
   {
      private readonly IPage _page;

      private FooterComponent _footer;
      private HeaderComponent _header;
      private MenuComponent _menu;

      private Dictionary<string, ILocator> _onaPage;

      public OpenNewAccountPage(IPage page)
      {
         _page = page;

         _footer = new FooterComponent(page);
         _header = new HeaderComponent(page);
         _menu = new MenuComponent(page);

         _onaPage = new Dictionary<string, ILocator>
         {
            { OpenNewAccountPageConstants.ONA_ACCOUNT_FORM, _page.Locator("#openAccountForm") },
            { OpenNewAccountPageConstants.ONA_ACCOUNT_RESULT, _page.Locator("#openAccountResult")},
            { OpenNewAccountPageConstants.ONA_ACCOUNT_ERROR, _page.Locator("#openAccountError") },
            { OpenNewAccountPageConstants.ONA_ACCOUNT_TYPE, _page.Locator("#type") },
            { OpenNewAccountPageConstants.ONA_ACCOUNT_EXISTING_ID, _page.Locator("#fromAccountId") },
            { OpenNewAccountPageConstants.ONA_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Open New Account" }) },
            { OpenNewAccountPageConstants.ONA_ACCOUNT_NEW_ID, _page.Locator("#newAccountId") }
         };
      }

      public async Task SelectDropdownByLabelAsync(string field, string label) => await _onaPage[field]
         .SelectOptionAsync(new SelectOptionValue { Label = label });

      public async Task<string> GetTextAsync(string field) => await _onaPage[field].InnerTextAsync();

      public async Task ClickElementAsync(string field) => await _onaPage[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _onaPage[field];
   }
}
