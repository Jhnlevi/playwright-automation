namespace Playwright.SauceDemo.Utils
{
    internal static class Util_ProjectPaths
    {
        /// <summary>
        /// Returns the appsettings path
        /// </summary>
        public static string GetConfigPath() => GetProjectRoot();

        private static string GetProjectRoot()
        {
            // First check: walk up the directories until csproj is found.
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (currentDirectory != null)
            {
                if (currentDirectory.GetFiles("*.csproj").Any())
                    return currentDirectory.FullName;

                currentDirectory = currentDirectory.Parent;
            }

            // Second check: return current directory.
            return Directory.GetCurrentDirectory();
        }
    }
}
