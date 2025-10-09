using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Pages.Components;

namespace Playwright.SauceDemo.Pages.Checkout
{
    internal class CheckoutCompletePage
    {
        private readonly IPage _page;

        // Dictionary field
        private readonly Dictionary<string, ILocator> _checkoutCompleteElements;

        // Component fields
        public HeaderComponent _header { get; }
        public FooterComponent _footer { get; }
        public MenuComponent _menu { get; }

        // Constructor
        public CheckoutCompletePage(IPage page)
        {
            _page = page;

            // Components
            _header = new HeaderComponent(page);
            _footer = new FooterComponent(page);
            _menu = new MenuComponent(page);

            _checkoutCompleteElements = new Dictionary<string, ILocator>
         {
            { CheckoutCompletePageConstants.CHECKOUT_COMPLETE_CONTAINER, _page.Locator("#checkout_complete_container") }
         };
        }

        // Actions
        public async Task<string> GetTextAsync(string field) => await _checkoutCompleteElements[field].InnerTextAsync();

        public async Task ClickElementAsync(string field) => await _checkoutCompleteElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _checkoutCompleteElements[field];
    }
}
