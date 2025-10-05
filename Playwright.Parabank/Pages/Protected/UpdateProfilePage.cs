using Microsoft.Playwright;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
   internal class UpdateProfilePage
   {
      private readonly IPage _page;

      public FooterComponent _footer;
      public HeaderComponent _header;
      public MenuComponent _menu;

      private Dictionary<string, ILocator> _upElements;

      public UpdateProfilePage(IPage page)
      {
         _page = page;

         _footer = new FooterComponent(page);
         _header = new HeaderComponent(page);
         _menu = new MenuComponent(page);

         _upElements = new Dictionary<string, ILocator>
         {
            { UpdateContantInfoPageConstants.UCI_FORM, _page.Locator("#updateProfileForm") },
            { UpdateContantInfoPageConstants.UCI_RESULT, _page.Locator("#updateProfileResult") },
            { UpdateContantInfoPageConstants.UCI_ERROR, _page.Locator("#updateProfileError") },
            { UpdateContantInfoPageConstants.UCI_FIRST_NAME, _page.Locator("input[id=\"customer\\.firstName\"]") },
            { UpdateContantInfoPageConstants.UCI_LAST_NAME, _page.Locator("input[id=\"customer\\.lastName\"]") },
            { UpdateContantInfoPageConstants.UCI_ADDRESS, _page.Locator("input[id=\"customer\\.address\\.street\"]") },
            { UpdateContantInfoPageConstants.UCI_CITY, _page.Locator("input[id=\"customer\\.address\\.city\"]") },
            { UpdateContantInfoPageConstants.UCI_STATE, _page.Locator("input[id=\"customer\\.address\\.state\"]") },
            { UpdateContantInfoPageConstants.UCI_ZIP_CODE, _page.Locator("input[id=\"customer\\.address\\.zipCode\"]") },
            { UpdateContantInfoPageConstants.UCI_MOBILE_NUMBER, _page.Locator("input[id=\"customer\\.phoneNumber\"]") },
            { UpdateContantInfoPageConstants.UCI_UPDATE_PROFILE_BUTTON, _page.GetByRole(AriaRole.Button, new() { Name = "Update Profile" }) }
         };
      }
      public async Task EnterTextAsync(string field, string text)
      {
         await _upElements[field].ClearAsync();
         await _upElements[field].FillAsync(text);
      }

      public async Task<string> GetTextAsync(string field) => await _upElements[field].InnerTextAsync();

      public async Task ClickElementAsync(string field) => await _upElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _upElements[field];
   }
}
