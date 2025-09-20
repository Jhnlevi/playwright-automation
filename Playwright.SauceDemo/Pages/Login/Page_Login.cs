using Microsoft.Playwright;

namespace Playwright.SauceDemo.Pages.Login
{
    internal class Page_Login
    {
        private readonly IPage _page;
        private readonly Dictionary<string, ILocator> _elements;

        // Constructor
        public Page_Login(IPage page)
        {
            _page = page;

            _elements = new Dictionary<string, ILocator>
            {
                { "username", _page.GetByPlaceholder("Username") },
                { "password", _page.GetByPlaceholder("Password") },
                { "login_button", _page.Locator("#login-button") },
                { "login_error", _page.Locator("[data-test=\"error\"]") }
            };
        }

        // Actions
        public async Task EnterTextAsync(string field, string text)
        {
            await _elements[field].ClearAsync();
            await _elements[field].FillAsync(text);
        }

        public async Task<string> GetTextAsync(string field) => await _elements[field].InnerTextAsync();

        public async Task ClickElementAsync(string field) => await _elements[field].ClickAsync();
    }
}
