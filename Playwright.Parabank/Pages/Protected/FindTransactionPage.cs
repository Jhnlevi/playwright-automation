using Microsoft.Playwright;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
   internal class FindTransactionPage
   {
      private readonly IPage _page;

      public FooterComponent _footer;
      public HeaderComponent _header;
      public MenuComponent _menu;

      private Dictionary<string, ILocator> _ftElements;

      public FindTransactionPage(IPage page)
      {
         _page = page;

         _footer = new FooterComponent(page);
         _header = new HeaderComponent(page);
         _menu = new MenuComponent(page);

         _ftElements = new Dictionary<string, ILocator>
         {
            { FindTransactionPageConstants.FT_FORM, _page.Locator("#transactionForm") },
            { FindTransactionPageConstants.FT_RESULT, _page.Locator("#resultContainer") },
            { FindTransactionPageConstants.FT_ERROR, _page.Locator("#errorContainer") },
            { FindTransactionPageConstants.FT_ACCOUNT_ID, _page.Locator("#accountId") },
            { FindTransactionPageConstants.FT_TRANSACTION_ID, _page.Locator("#transactionId") },
            { FindTransactionPageConstants.FT_TRANSACTION_DATE, _page.Locator("#transactionDate") },
            { FindTransactionPageConstants.FT_FROM_DATE, _page.Locator("#fromDate") },
            { FindTransactionPageConstants.FT_TO_DATE, _page.Locator("#toDate") },
            { FindTransactionPageConstants.FT_AMOUNT, _page.Locator("#amount") },
            { FindTransactionPageConstants.FT_FIND_BY_ID_BUTTON, _page.GetByRole(AriaRole.Button).Locator("#findById") },
            { FindTransactionPageConstants.FT_FIND_BY_DATE_BUTTON, _page.GetByRole(AriaRole.Button).Locator("#findByDate") },
            { FindTransactionPageConstants.FT_FIND_BY_DATE_RANGE_BUTTON, _page.GetByRole(AriaRole.Button).Locator("#findByDateRange") },
            { FindTransactionPageConstants.FT_FIND_BY_AMOUNT_BUTTON, _page.GetByRole(AriaRole.Button).Locator("#findByAmount") },
         };
      }

      public async Task SelectDropdownByLabelAsync(string field, string label) => await _ftElements[field]
   .SelectOptionAsync(new SelectOptionValue { Label = label });

      public async Task<string> GetTextAsync(string field) => await _ftElements[field].InnerTextAsync();

      public async Task ClickElementAsync(string field) => await _ftElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _ftElements[field];
   }
}
