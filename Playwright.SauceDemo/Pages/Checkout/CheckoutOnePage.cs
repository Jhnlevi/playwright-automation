using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Pages.Components;

namespace Playwright.SauceDemo.Pages.Checkout
{
    internal class CheckoutOnePage
    {
        private readonly IPage _page;

        // Dictionary field
        private readonly Dictionary<string, ILocator> _checkoutOneElements;

        // Component fields
        public HeaderComponent _header { get; }
        public FooterComponent _footer { get; }
        public MenuComponent _menu { get; }

        // Constructor
        public CheckoutOnePage(IPage page)
        {
            _page = page;

            // Components
            _header = new HeaderComponent(page);
            _footer = new FooterComponent(page);
            _menu = new MenuComponent(page);

            _checkoutOneElements = new Dictionary<string, ILocator>
         {
            { CheckoutOnePageConstants.CHECKOUT_ONE_FIRSTNAME, _page.GetByPlaceholder("First Name") },
            { CheckoutOnePageConstants.CHECKOUT_ONE_LASTNAME, _page.GetByPlaceholder("Last Name") },
            { CheckoutOnePageConstants.CHECKOUT_ONE_POSTAL, _page.GetByPlaceholder("Zip/Postal Code") },
            { CheckoutOnePageConstants.CHECKOUT_ONE_CANCEL_BUTTON, _page.GetByRole(AriaRole.Link, new() { Name = "CANCEL" }) },
            { CheckoutOnePageConstants.CHECKOUT_ONE_CONTINUE_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "CONTINUE" }) },
            { CheckoutOnePageConstants.CHECKOUT_ONE_ERROR_MESSAGE, _page.Locator("[data-test=\"error\"]") }
         };
        }

        // Actions
        public async Task EnterTextAsync(string field, string text)
        {
            await _checkoutOneElements[field].ClearAsync();
            await _checkoutOneElements[field].FillAsync(text);
        }

        public async Task<string> GetTextAsync(string field) => await _checkoutOneElements[field].InnerTextAsync();

        public async Task ClickElementAsync(string field) => await _checkoutOneElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _checkoutOneElements[field];
    }
}
