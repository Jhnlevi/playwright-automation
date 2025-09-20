using Microsoft.Extensions.Configuration;

namespace Playwright.SauceDemo.Utils
{
    internal static class Util_ConfigLoader
    {
        public static T Get<T>(string fileName = "appsettings.json")
        {
            var config = new ConfigurationBuilder();
        }
    }
}
