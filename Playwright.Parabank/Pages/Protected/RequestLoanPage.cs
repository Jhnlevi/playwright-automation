using Microsoft.Playwright;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
   internal class RequestLoanPage
   {
      private readonly IPage _page;

      public FooterComponent _footer;
      public HeaderComponent _header;
      public MenuComponent _menu;

      private Dictionary<string, ILocator> _rlElements;

      public RequestLoanPage(IPage page)
      {
         _page = page;

         _footer = new FooterComponent(page);
         _header = new HeaderComponent(page);
         _menu = new MenuComponent(page);

         _rlElements = new Dictionary<string, ILocator>
         {
            { RequestLoanPageConstants.RL_FORM, _page.Locator("#requestLoanForm") },
            { RequestLoanPageConstants.RL_RESULT, _page.Locator("#requestLoanResult") },
            { RequestLoanPageConstants.RL_ERROR, _page.Locator("#requestLoanError") },
            { RequestLoanPageConstants.RL_LOAN_AMOUNT, _page.Locator("input[id=\"amount\"]") },
            { RequestLoanPageConstants.RL_DOWN_PAYMENT, _page.Locator("input[id=\"downPayment\"]") },
            { RequestLoanPageConstants.RL_FROM_ACCOUNT_ID, _page.Locator("select[id=\"fromAccountId\"]") },
            { RequestLoanPageConstants.RL_APPLY_NOW_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Apply Now" }) },
            { RequestLoanPageConstants.RL_REQUEST_APPROVED, _page.Locator("#loanRequestApproved") },
            { RequestLoanPageConstants.RL_REQUEST_DENIED, _page.Locator("#loanRequestDenied") }
         };
      }
      public async Task SelectDropdownByLabelAsync(string field, string label) => await _rlElements[field]
         .SelectOptionAsync(new SelectOptionValue { Label = label });

      public async Task<string> GetTextAsync(string field) => await _rlElements[field].InnerTextAsync();

      public async Task ClickElementAsync(string field) => await _rlElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _rlElements[field];
   }
}
