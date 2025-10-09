using Microsoft.Playwright;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
    internal class TransferFundPage
    {
        private readonly IPage _page;

        public FooterComponent _footer;
        public HeaderComponent _header;
        public MenuComponent _menu;

        private Dictionary<string, ILocator> _tfElements;

        public TransferFundPage(IPage page)
        {
            _page = page;

            _footer = new FooterComponent(page);
            _header = new HeaderComponent(page);
            _menu = new MenuComponent(page);

            _tfElements = new Dictionary<string, ILocator>
         {
            { TransferFundsPageConstants.TF_FORM, _page.Locator("#showForm") },
            { TransferFundsPageConstants.TF_RESULT, _page.Locator("#showResult") },
            { TransferFundsPageConstants.TF_ERROR, _page.Locator("#showError") },
            { TransferFundsPageConstants.TF_AMOUNT, _page.Locator("input[id=\"amount\"]") },
            { TransferFundsPageConstants.TF_FROM_ACCOUNT, _page.Locator("#fromAccountId") },
            { TransferFundsPageConstants.TF_TO_ACCOUNT, _page.Locator("#toAccountId") },
            { TransferFundsPageConstants.TF_TRANSFER_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Transfer" }) },
            { TransferFundsPageConstants.TF_AMOUNT_ERROR, _page.Locator("#error") }
         };
        }

        public async Task SelectDropdownByLabelAsync(string field, string label) => await _tfElements[field]
           .SelectOptionAsync(new SelectOptionValue { Label = label });

        public async Task<string> GetTextAsync(string field) => await _tfElements[field].InnerTextAsync();

        public async Task ClickElementAsync(string field) => await _tfElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _tfElements[field];
    }
}
