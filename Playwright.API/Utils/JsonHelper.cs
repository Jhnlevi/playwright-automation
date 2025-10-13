using System.Text.Json;

namespace Playwright.API.Utils
{
   internal static class JsonHelper
   {
      // Reading json
      public static T Read<T>(string data)
      {
         return JsonSerializer.Deserialize<T>(data)!;
      }

      // Writing json
      public static string Write<T>(T data)
      {
         return JsonSerializer.Serialize(data);
      }
   }
}
