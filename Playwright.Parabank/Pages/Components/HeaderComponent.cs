using Microsoft.Playwright;
using Playwright.Parabank.Constants.Components;

namespace Playwright.Parabank.Pages.Components
{
   internal class HeaderComponent
   {
      private readonly IPage _page;

      private readonly Dictionary<string, ILocator> _headerElements;

      public HeaderComponent(IPage page)
      {
         _page = page;

         _headerElements = new Dictionary<string, ILocator>
         {
            { HeaderComponentConstants.HEADER_HOME, _page.GetByRole(AriaRole.Link, new() { Name = "home" }) },
            { HeaderComponentConstants.HEADER_ABOUT, _page.GetByRole(AriaRole.Link, new() { Name = "about" }) },
            { HeaderComponentConstants.HEADER_CONTACT, _page.GetByRole(AriaRole.Link, new() { Name = "contact" }) }
         };
      }

      public async Task ClickElementAsync(string field) => await _headerElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _headerElements[field];
   }
}
