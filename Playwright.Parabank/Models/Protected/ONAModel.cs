using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
   internal class ONAModel
   {
      [JsonPropertyName("testCases")]
      public List<ONATestCase>? TestCases { get; set; }
   }

   public class ONATestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string Type { get; set; } = null!;

      [JsonPropertyName("data")]
      public Data Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public Expectedresult ExpectedResult { get; set; } = null!;
   }

   public class Data
   {
      [JsonPropertyName("account")]
      public Account Account { get; set; } = null!;
   }

   public class Account
   {
      [JsonPropertyName("accountType")]
      public string AccountType { get; set; } = null!;

      [JsonPropertyName("existingAccount")]
      public string ExistingAccount { get; set; } = null!;
   }

   public class Expectedresult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<Fielderrors>? FieldErrors { get; set; } = null!;
   }
   public class Fielderrors
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
