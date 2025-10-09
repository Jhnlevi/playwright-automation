using Microsoft.Playwright;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
    internal class BillsPayPage
    {
        private readonly IPage _page;

        public FooterComponent _footer;
        public HeaderComponent _header;
        public MenuComponent _menu;

        private Dictionary<string, ILocator> _bpElements;

        public BillsPayPage(IPage page)
        {
            _page = page;

            _footer = new FooterComponent(page);
            _header = new HeaderComponent(page);
            _menu = new MenuComponent(page);

            _bpElements = new Dictionary<string, ILocator>
         {
            { BillsPayPageConstants.BP_FORM, _page.Locator("#billpayForm") },
            { BillsPayPageConstants.BP_RESULT, _page.Locator("#billpayResult") },
            { BillsPayPageConstants.BP_ERROR, _page.Locator("#billpayError") },
            { BillsPayPageConstants.BP_PAYEE_NAME, _page.Locator("input[name=\"payee\\.name\"]") },
            { BillsPayPageConstants.BP_ADDRESS, _page.Locator("input[name=\"payee\\.address\\.street\"]") },
            { BillsPayPageConstants.BP_CITY, _page.Locator("input[name=\"payee\\.address\\.city\"]") },
            { BillsPayPageConstants.BP_STATE, _page.Locator("input[name=\"payee\\.address\\.state\"]") },
            { BillsPayPageConstants.BP_ZIP_CODE, _page.Locator("input[name=\"payee\\.address\\.zipCode\"]") },
            { BillsPayPageConstants.BP_MOBILE_NUMBER, _page.Locator("input[name=\"payee\\.phoneNumber\"]") },
            { BillsPayPageConstants.BP_ACCOUNT_NUMBER, _page.Locator("input[name=\"payee\\.accountNumber\"]") },
            { BillsPayPageConstants.BP_VERIFY_ACCOUNT_NUMBER, _page.Locator("input[name=\"verifyAccount\"]") },
            { BillsPayPageConstants.BP_AMOUNT, _page.Locator("input[name=\"amount\"]") },
            { BillsPayPageConstants.BP_FROM_ACCOUNT, _page.Locator("select[name=\"fromAccountId\"]") },
            { BillsPayPageConstants.BP_SEND_PAYMENT_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Send Payment" }) }
         };
        }
        public async Task EnterTextAsync(string field, string text)
        {
            await _bpElements[field].ClearAsync();
            await _bpElements[field].FillAsync(text);
        }

        public async Task SelectDropdownByLabelAsync(string field, string label) => await _bpElements[field]
           .SelectOptionAsync(new SelectOptionValue { Label = label });

        public async Task ClickElementAsync(string field) => await _bpElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _bpElements[field];
    }
}
