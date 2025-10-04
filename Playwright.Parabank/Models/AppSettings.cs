using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models
{
   internal class AppSettings
   {
      [JsonPropertyName("appName")]
      public string AppName { get; set; } = null!;

      [JsonPropertyName("environments")]
      public Environments Environments { get; set; } = null!;
   }

   public class Environments
   {
      [JsonPropertyName("dev")]
      public Dev Dev { get; set; } = null!;

      [JsonPropertyName("qa")]
      public Qa Qa { get; set; } = null!;

      [JsonPropertyName("production")]
      public Production Production { get; set; } = null!;
   }

   public class Dev
   {
      [JsonPropertyName("baseUrl")]
      public string BaseUrl { get; set; } = null!;
   }

   public class Qa
   {
      [JsonPropertyName("baseUrl")]
      public string BaseUrl { get; set; } = null!;
   }

   public class Production
   {
      [JsonPropertyName("baseUrl")]
      public string BaseUrl { get; set; } = null!;
   }

}
