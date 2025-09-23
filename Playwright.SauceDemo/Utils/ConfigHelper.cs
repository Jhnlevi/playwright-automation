using Microsoft.Extensions.Configuration;

namespace Playwright.SauceDemo.Utils
{
    internal static class ConfigHelper
    {
        /// <summary>
        /// Loads the entire config file
        /// </summary>
        public static T Load<T>(string fileName = "appsettings.json")
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(PathsHelper.GetConfigPath())
                .AddJsonFile(fileName, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return config.Get<T>()!;
        }

        /// <summary>
        /// Loads a section in config file.
        /// </summary>
        public static T Load<T>(string fileName = "appsettings.json", string sectionName = "")
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(PathsHelper.GetConfigPath())
                .AddJsonFile(fileName, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return config.GetSection(sectionName).Get<T>()!;
        }
    }
}
