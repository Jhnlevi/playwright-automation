using Microsoft.Playwright;
using Playwright.Parabank.Constants.Components;

namespace Playwright.Parabank.Pages.Components
{
   internal class FooterComponent
   {
      private readonly IPage _page;

      private readonly Dictionary<string, ILocator> _footerElements;

      public FooterComponent(IPage page)
      {
         _page = page;

         _footerElements = new Dictionary<string, ILocator>
         {
            { FooterComponentConstants.FOOTER_HOME, _page.GetByRole(AriaRole.Link, new() { Name = "Home" }) },
            { FooterComponentConstants.FOOTER_ABOUT, _page.GetByRole(AriaRole.Link, new() { Name = "About Us" }) },
            { FooterComponentConstants.FOOTER_SERVICES, _page.GetByRole(AriaRole.Link, new() { Name = "Services" }) },
            { FooterComponentConstants.FOOTER_PRODUCTS, _page.GetByRole(AriaRole.Link, new() { Name = "Products" }) },
            { FooterComponentConstants.FOOTER_LOCATIONS, _page.GetByRole(AriaRole.Link, new() { Name = "Locations" }) },
            { FooterComponentConstants.FOOTER_FORUM, _page.GetByRole(AriaRole.Link, new() { Name = "Forum" }) },
            { FooterComponentConstants.FOOTER_SITE_MAP, _page.GetByRole(AriaRole.Link, new() { Name = "Site Map" }) },
            { FooterComponentConstants.FOOTER_CONTACT_US, _page.GetByRole(AriaRole.Link, new() { Name = "Contact Us" }) },
         };
      }

      public async Task ClickElementAsync(string field) => await _footerElements[field].ClickAsync();

      public ILocator IsElementDisplayed(string field) => _footerElements[field];
   }
}
