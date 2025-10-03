using Microsoft.Playwright;
using Playwright.Parabank.Constants.Public;

namespace Playwright.Parabank.Pages.Login
{
   internal class LoginPage
   {
      private readonly IPage _page;

      private readonly Dictionary<string, ILocator> _loginElements;

      public LoginPage(IPage page)
      {
         _page = page;

         _loginElements = new Dictionary<string, ILocator>
         {
            { LoginPageConstants.LOGIN_USERNAME_FIELD, _page.Locator("input[name=\"username\"]") },
            { LoginPageConstants.LOGIN_PASSWORD_FIELD, _page.Locator("input[name=\"password\"]") },
            { LoginPageConstants.LOGIN_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Log In" }) },
            { LoginPageConstants.LOGIN_LEFT_PANEL, _page.Locator("#loginPanel") },
            { LoginPageConstants.LOGIN_RIGHT_PANEL, _page.Locator("#rightPanel") },
            { LoginPageConstants.LOGIN_FORGOT_LOGIN_INFO, _page.GetByRole(AriaRole.Link, new() { Name = "Forgot login info?" }) },
            { LoginPageConstants.LOGIN_REGISTER_BUTTON, _page.GetByRole(AriaRole.Link, new() { Name = "Register" }) }
         };
      }

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
