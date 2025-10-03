using Microsoft.Playwright;
using Playwright.Parabank.Constants.Public;

namespace Playwright.Parabank.Pages.Public
{
   internal class RegisterPage
   {
      private readonly IPage _page;

      private readonly Dictionary<string, ILocator> _registerElements;

      public RegisterPage(IPage page)
      {
         _page = page;

         _registerElements = new Dictionary<string, ILocator>
         {
            { RegisterPageConstants.REGISTER_FIRST_NAME_FIELD, _page.Locator("[name='customer.firstName']") },
            { RegisterPageConstants.REGISTER_LAST_NAME_FIELD, _page.Locator("[name='customer.lastName']") },
            { RegisterPageConstants.REGISTER_ADDRESS_FIELD, _page.Locator("[name='customer.address.street']") },
            { RegisterPageConstants.REGISTER_CITY_FIELD, _page.Locator("[name='customer.address.city']") },
            { RegisterPageConstants.REGISTER_STATE_FIELD, _page.Locator("[name='customer.address.state']") },
            { RegisterPageConstants.REGISTER_ZIP_CODE_FIELD, _page.Locator("[name='customer.address.zipCode']") },
            { RegisterPageConstants.REGISTER_MOBILE_NUMBER_FIELD, _page.Locator("[name='customer.phoneNumber']") },
            { RegisterPageConstants.REGISTER_SSN_FIELD, _page.Locator("[name='customer.ssn']") },
            { RegisterPageConstants.REGISTER_USERNAME_FIELD, _page.Locator("[name='customer.username']") },
            { RegisterPageConstants.REGISTER_PASSWORD_FIELD, _page.Locator("[name='customer.password']") },
            { RegisterPageConstants.REGISTER_CONFIRM_PASSWORD_FIELD, _page.Locator("[name='repeatedPassword']") },
            { RegisterPageConstants.REGISTER_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Register" }) },
            { RegisterPageConstants.REGISTER_LEFT_PANEL, _page.Locator("#leftPanel") },
            { RegisterPageConstants.REGISTER_RIGHT_PANEL, _page.Locator("#rightPanel") }
         };
      }
      public async Task EnterTextAsync(string field, string text)
      {
         await _registerElements[field].ClearAsync();
         await _registerElements[field].FillAsync(text);
      }

      public async Task<string> GetTextAsync(string field) => await _registerElements[field].InnerTextAsync();

      public async Task ClickElementAsync(string field) => await _registerElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _registerElements[field];
   }
}
