using Microsoft.Playwright;
using Playwright.Parabank.Constants.Overview;

namespace Playwright.Parabank.Pages.Protected
{
   internal class OverviewPage
   {
      private readonly IPage _page;

      private Dictionary<string, ILocator> _overviewElements;

      public OverviewPage(IPage page)
      {
         _page = page;

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
