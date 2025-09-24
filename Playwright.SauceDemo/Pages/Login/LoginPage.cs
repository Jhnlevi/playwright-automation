using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Login;

namespace Playwright.SauceDemo.Pages.Login
{
   internal class LoginPage
   {
      private readonly IPage _page;
      private readonly Dictionary<string, ILocator> _loginElements;

      // Constructor
      public LoginPage(IPage page)
      {
         _page = page;

         _loginElements = new Dictionary<string, ILocator>
            {
                { LoginPageConstants.LOGIN_USERNAME, _page.GetByPlaceholder("Username") },
                { LoginPageConstants.LOGIN_PASSWORD, _page.GetByPlaceholder("Password") },
                { LoginPageConstants.LOGIN_BUTTON, _page.Locator("#login-button") },
                { LoginPageConstants.LOGIN_ERROR_MESSAGE, _page.Locator("[data-test=\"error\"]") }
            };
      }

      // Actions
      public async Task EnterTextAsync(string field, string text)
      {
         await _loginElements[field].ClearAsync();
         await _loginElements[field].FillAsync(text);
      }

      public async Task<string> GetTextAsync(string field) => await _loginElements[field].InnerTextAsync();

      public async Task ClickElementAsync(string field) => await _loginElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _loginElements[field];
   }
}
