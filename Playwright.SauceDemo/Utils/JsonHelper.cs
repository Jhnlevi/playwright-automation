using System.Text.Json;

namespace Playwright.SauceDemo.Utils
{
    internal static class JsonHelper
    {
        /// <summary>
        /// Reads the .json file
        /// </summary>
        /// <returns>Deserialized json file.</returns>
        private static T ReadJson<T>(string path)
        {
            var data = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(data)!;
        }

        public static T LoadJson<T>(string module = "", string file = "")
        {
            var directory = string.IsNullOrWhiteSpace(module)
               ? PathsHelper.GetTestDataPath()
               : Path.Combine(PathsHelper.GetTestDataPath(), module);

            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException("Test data module folder not found.");

            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentException("File name must be provided to load test data.");

            var filePath = Path.Combine(directory, file);

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"{file} is not found at {directory}");

            return ReadJson<T>(filePath);
        }
    }
}
