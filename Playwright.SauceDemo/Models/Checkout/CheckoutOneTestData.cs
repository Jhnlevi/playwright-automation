using System.Text.Json.Serialization;
using Playwright.SauceDemo.Models.Login;

namespace Playwright.SauceDemo.Models.Checkout
{
   internal class CheckoutOneTestData
   {
      [JsonPropertyName("testCases")]
      public List<CheckoutTestCase>? TestCases { get; set; }
   }
   internal class CheckoutTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string? Type { get; set; } = null!;

      [JsonPropertyName("data")]
      public LoginData Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public ExpectedResult ExpectedResult { get; set; } = null!;

      public override string ToString()
      {
         return $"{Id} : {Description}";
      }
   }
   internal class CheckoutData
   {
      [JsonPropertyName("firstName")]
      public string FirstName { get; set; } = null!;

      [JsonPropertyName("lastName")]
      public string LastName { get; set; } = null!;

      [JsonPropertyName("postalCode")]
      public string PostalCode { get; set; } = null!;
   }

   // Expected results.
   internal class ExpectedResult
   {
      [JsonPropertyName("success")]
      public bool success { get; set; }

      [JsonPropertyName("message")]
      public string message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<FieldError>? FieldErrors { get; set; }
   }

   // Field errors (For missing input validations).
   internal class FieldError
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
