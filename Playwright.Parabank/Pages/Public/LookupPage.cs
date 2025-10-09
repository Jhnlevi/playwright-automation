using Microsoft.Playwright;
using Playwright.Parabank.Constants.Public;

namespace Playwright.Parabank.Pages.Public
{
    internal class LookupPage
    {
        private readonly IPage _page;

        private readonly Dictionary<string, ILocator> _lookupElements;

        public LookupPage(IPage page)
        {
            _page = page;

            _lookupElements = new Dictionary<string, ILocator>
         {
            { LookupPageConstants.LOOKUP_FIRST_NAME_FIELD, _page.Locator("#firstName") },
            { LookupPageConstants.LOOKUP_LAST_NAME_FIELD, _page.Locator("#lastName") },
            { LookupPageConstants.LOOKUP_ADDRESS_FIELD, _page.Locator("#address.street") },
            { LookupPageConstants.LOOKUP_CITY_FIELD, _page.Locator("#address.city") },
            { LookupPageConstants.LOOKUP_STATE_FIELD, _page.Locator("#address.state") },
            { LookupPageConstants.LOOKUP_ZIP_CODE_FIELD, _page.Locator("#address.zipCode") },
            { LookupPageConstants.LOOKUP_SSN_FIELD, _page.Locator("#ssn") },
            { LookupPageConstants.LOOKUP_FIND_INFO_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Find My Login Info" }) },
            { LookupPageConstants.LOOKUP_LEFT_PANEL, _page.Locator("#leftPanel") },
            { LookupPageConstants.LOOKUP_RIGHT_PANEL, _page.Locator("#rightPanel") }
         };
        }

        public async Task EnterTextAsync(string field, string text)
        {
            await _lookupElements[field].ClearAsync();
            await _lookupElements[field].FillAsync(text);
        }

        public async Task<string> GetTextAsync(string field) => await _lookupElements[field].InnerTextAsync();

        public async Task ClickElementAsync(string field) => await _lookupElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _lookupElements[field];
    }
}
