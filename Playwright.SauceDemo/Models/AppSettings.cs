using System.Text.Json.Serialization;

namespace Playwright.SauceDemo.Models
{
    internal class AppSettings
    {
        [JsonPropertyName("appName")]
        public string AppName { get; set; } = null!;

        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; set; } = null!;
    }
}
