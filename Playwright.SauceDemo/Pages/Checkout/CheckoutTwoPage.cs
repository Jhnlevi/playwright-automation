using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Checkout;
using Playwright.SauceDemo.Pages.Components;

namespace Playwright.SauceDemo.Pages.Checkout
{
    internal class CheckoutTwoPage
    {
        private readonly IPage _page;

        // Dictionary field
        private readonly Dictionary<string, ILocator> _checkoutTwoElements;

        // Component fields
        public HeaderComponent _header { get; }
        public FooterComponent _footer { get; }
        public MenuComponent _menu { get; }

        // Constructor
        public CheckoutTwoPage(IPage page)
        {
            _page = page;

            // Components
            _header = new HeaderComponent(page);
            _footer = new FooterComponent(page);
            _menu = new MenuComponent(page);

            _checkoutTwoElements = new Dictionary<string, ILocator>
         {
            { CheckoutTwoPageConstants.CHECKOUT_TWO_CANCEL_BUTTON, _page.GetByRole(AriaRole.Link, new() { Name = "CANCEL" }) },
            { CheckoutTwoPageConstants.CHECKOUT_TWO_FINISH_BUTTON, _page.GetByRole(AriaRole.Link, new() { Name = "FINISH" }) },
            { CheckoutTwoPageConstants.CHECKOUT_TWO_CART_LIST, _page.Locator(".cart_list") },
            { CheckoutTwoPageConstants.CHECKOUT_TWO_SUMMARY_INFO, _page.Locator(".summary_info") }
         };
        }

        // Actions
        public async Task ClickElementAsync(string field) => await _checkoutTwoElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _checkoutTwoElements[field];
    }
}
