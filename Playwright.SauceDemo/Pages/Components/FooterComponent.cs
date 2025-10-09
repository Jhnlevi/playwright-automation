using Microsoft.Playwright;
using Playwright.SauceDemo.Constants.Components;

namespace Playwright.SauceDemo.Pages.Components
{
    internal class FooterComponent
    {
        private readonly IPage _page;

        // Dictionary field
        private readonly Dictionary<string, ILocator> _footerElements;

        // Constructor
        public FooterComponent(IPage page)
        {
            _page = page;

            _footerElements = new Dictionary<string, ILocator>
         {
            { FooterComponentConstants.FOOTER_SOCIAL_TWITTER, _page.GetByRole(AriaRole.Button, new() { Name = "Twitter" } ) },
            { FooterComponentConstants.FOOTER_SOCIAL_FACEBOOK, _page.GetByRole(AriaRole.Button, new() { Name = "Facebook" } ) },
            { FooterComponentConstants.FOOTER_SOCIAL_LINKEDIN, _page.GetByRole(AriaRole.Button, new() { Name = "LinkedIn" } ) }
         };
        }

        // Actions
        public async Task ClickElementAsync(string field) => await _footerElements[field].ClickAsync();
        public async Task<string> GetTextAsync(string field) => await _footerElements[field].InnerTextAsync();
        public ILocator IsElementDisplayed(string field) => _footerElements[field];
    }
}
