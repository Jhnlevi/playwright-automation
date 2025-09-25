using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Pages.Login;

namespace Playwright.SauceDemo.Utils
{
   internal class TestPreconditions
   {
      private const string LoginUsername = "standard_user";
      private const string LoginPassword = "secret_sauce";
      public static async Task LoginAsStandardUser(LoginPage page)
      {
         await page.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME, LoginUsername);
         await page.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD, LoginPassword);
         await page.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
      }
   }
}
