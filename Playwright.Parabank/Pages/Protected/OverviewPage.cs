using Microsoft.Playwright;
using Playwright.Parabank.Constants.Overview;
using Playwright.Parabank.Pages.Components;

namespace Playwright.Parabank.Pages.Protected
{
   internal class OverviewPage
   {
      private readonly IPage _page;

      public FooterComponent _footer;
      public HeaderComponent _header;
      public MenuComponent _menu;

      private Dictionary<string, ILocator> _overviewElements;

      public OverviewPage(IPage page)
      {
         _page = page;

         _footer = new FooterComponent(page);
         _header = new HeaderComponent(page);
         _menu = new MenuComponent(page);

         _overviewElements = new Dictionary<string, ILocator>
         {
            { OverviewPageConstants.OVERVIEW_SHOW, _page.Locator("#showOverview") },
            { OverviewPageConstants.OVERVIEW_ERROR, _page.Locator("#showError") },
            { OverviewPageConstants.OVERVIEW_TABLE, _page.Locator("#accountTable") }
         };
      }

      public async Task<string> GetTextAsync(string field) => await _overviewElements[field].InnerTextAsync();

      public ILocator IsElementDisplayed(string field) => _overviewElements[field];
   }
}
