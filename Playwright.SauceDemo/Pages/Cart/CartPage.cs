using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Cart;
using Playwright.SauceDemo.Pages.Components;

namespace Playwright.SauceDemo.Pages.Cart
{
    internal class CartPage
    {
        private readonly IPage _page;

        // Dictionary field
        private readonly Dictionary<string, ILocator> _cartElements;

        // Component fields
        public HeaderComponent _header { get; }
        public FooterComponent _footer { get; }
        public MenuComponent _menu { get; }

        // Constructor
        public CartPage(IPage page)
        {
            _page = page;

            // Components
            _header = new HeaderComponent(page);
            _footer = new FooterComponent(page);
            _menu = new MenuComponent(page);

            _cartElements = new Dictionary<string, ILocator>
         {
            { CartPageConstants.CART_ITEM, _page.Locator("div.cart_item") },
            { CartPageConstants.CART_ITEM_QUANTITY, _page.Locator("div.cart_quantity") },
            { CartPageConstants.CART_ITEM_REMOVE_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "REMOVE" }) },
            { CartPageConstants.CART_ITEM_CONTINUE_SHOPPING_BUTTON, _page.GetByRole(AriaRole.Link, new() { Name = "Continue Shopping" }) },
            { CartPageConstants.CART_ITEM_CHECKOUT_BUTTON, _page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" }) },
         };
        }

        // Actions
        public async Task ClickCartItemName(string field, string cartItem)
        {
            var item = _cartElements[field].Filter(new() { HasText = cartItem });
            await item.GetByRole(AriaRole.Link, new() { Name = cartItem }).ClickAsync();
        }

        public async Task ClickRemoveCartItem(string field, string cartItem)
        {
            var item = _cartElements[field].Filter(new() { HasText = cartItem });
            await item.GetByRole(AriaRole.Button, new() { Name = "REMOVE" }).ClickAsync();
        }

        public async Task<string> GetCartItemName(string field, string cartItem)
        {
            var item = _cartElements[field].Filter(new() { HasText = cartItem });
            return await item.InnerTextAsync();
        }

        public async Task ClickElementAsync(string field) => await _cartElements[field].ClickAsync();

        public ILocator IsElementDisplayed(string field) => _cartElements[field];
    }
}
