using Microsoft.Extensions.Configuration;

namespace Playwright.API.Utils
{
   internal static class ConfigHelper
   {
      public static T Load<T>(string? fileName = "appsettings.json")
      {
         var config = new ConfigurationBuilder()
             .SetBasePath(ProjectPathHelper.GetConfigPath())
             .AddJsonFile(fileName!, optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

         return config.Get<T>()!;
      }

      public static T Load<T>(string? fileName = "appsettings.json", string? sectionName = "")
      {
         var config = new ConfigurationBuilder()
             .SetBasePath(ProjectPathHelper.GetConfigPath())
             .AddJsonFile(fileName!, optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();

         return config.GetSection(sectionName!).Get<T>()!;
      }
   }
}
