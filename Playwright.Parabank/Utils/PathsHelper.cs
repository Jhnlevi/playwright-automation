namespace Playwright.Parabank.Utils
{
    internal class PathsHelper
    {
        /// <summary>
        /// Returns the appsettings path.
        /// </summary>
        public static string GetConfigPath() => GetProjectRoot();

        /// <summary>
        /// Returns the path of 'Reports' folder.
        /// </summary>
        public static string GetReportPath() => Path.Combine(GetProjectRoot(), "Reports");

        /// <summary>
        /// Returns the path of 'Screenshots' folder inside 'Reports'.
        /// </summary>
        /// <returns></returns>
        public static string GetScreenshotPath() => Path.Combine(GetProjectRoot(), "Reports", "Screenshots");

        public static string GetTestDataPath() => Path.Combine(GetProjectRoot(), "TestData");

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
