using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Login;

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
                { Field_Login.LOGIN_USERNAME, _page.GetByPlaceholder("Username") },
                { Field_Login.LOGIN_PASSWORD, _page.GetByPlaceholder("Password") },
                { Field_Login.LOGIN_BUTTON, _page.Locator("#login-button") },
                { Field_Login.LOGIN_ERROR_MESSAGE, _page.Locator("[data-test=\"error\"]") }
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
