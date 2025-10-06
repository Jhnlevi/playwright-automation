using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
   internal class TFModel
   {
      [JsonPropertyName("testCases")]
      public List<TFTestCase>? TestCases { get; set; }
   }

   public class TFTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string Type { get; set; } = null!;

      [JsonPropertyName("data")]
      public TFData Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public TFExpectedResult ExpectedResult { get; set; } = null!;
   }

   public class TFData
   {
      [JsonPropertyName("transaction")]
      public TFTransaction Transaction { get; set; } = null!;
   }

   public class TFTransaction
   {
      [JsonPropertyName("amount")]
      public string Amount { get; set; } = null!;

      [JsonPropertyName("fromAccount")]
      public string FromAccount { get; set; } = null!;

      [JsonPropertyName("toAccount")]
      public string ToAccount { get; set; } = null!;
   }

   public class TFExpectedResult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<TFFieldError>? FieldErrors { get; set; }
   }

   public class TFFieldError
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
