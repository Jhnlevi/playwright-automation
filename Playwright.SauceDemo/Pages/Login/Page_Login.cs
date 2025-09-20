using Microsoft.Playwright;

namespace Playwright.SauceDemo.Pages.Login
{
    internal class Page_Login
    {
        private readonly IPage _page;

        public Page_Login(IPage page)
        {
            _page = page;
        }
    }
}
