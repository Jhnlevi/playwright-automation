namespace Playwright.API.Utils
{
   internal static class ProjectPathHelper
   {
      public static string GetConfigPath() => GetProjectRoot();

      public static string GetReportPath() => Path.Combine(GetProjectRoot(), "Reports");

      private static string GetProjectRoot()
      {
         var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
         while (currentDirectory != null)
         {
            if (currentDirectory.GetFiles("*.csproj").Any())
               return currentDirectory.FullName;

            currentDirectory = currentDirectory.Parent;
         }
         return Directory.GetCurrentDirectory();
      }
   }
}
