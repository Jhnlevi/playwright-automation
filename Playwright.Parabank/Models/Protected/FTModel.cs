using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
   internal class FTModel
   {
      [JsonPropertyName("testCases")]
      public List<FTTestCase>? TestCases { get; set; }
   }

   public class FTTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string Type { get; set; } = null!;

      [JsonPropertyName("data")]
      public FTData Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public FTExpectedResult ExpectedResult { get; set; } = null!;

      public override string ToString()
      {
         return $"{Id} : {Description}";
      }
   }

   public class FTData
   {
      [JsonPropertyName("transaction")]
      public FTTransaction Transaction { get; set; } = null!;
   }

   public class FTTransaction
   {
      [JsonPropertyName("account")]
      public string Account { get; set; } = null!;

      [JsonPropertyName("byId")]
      public string? ById { get; set; }

      [JsonPropertyName("byDate")]
      public string? ByDate { get; set; }

      [JsonPropertyName("byFromDate")]
      public string? ByFromDate { get; set; }

      [JsonPropertyName("byToDate")]
      public string? ByToDate { get; set; }

      [JsonPropertyName("byAmount")]
      public string? ByAmount { get; set; }
   }

   public class FTExpectedResult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<FTFieldError>? FieldErrors { get; set; }
   }

   public class FTFieldError
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }

}
