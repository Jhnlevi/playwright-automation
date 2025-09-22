using System.Text.Json.Serialization;

namespace Playwright.SauceDemo.Models.Login
{
   // Test data root.
   internal class Model_Login_TestData
   {
      [JsonPropertyName("testCases")]
      public List<LoginTestCase>? TestCases { get; set; }
   }

   // Test case.
   internal class LoginTestCase
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

   // Test data.
   internal class LoginData
   {
      [JsonPropertyName("userName")]
      public string Username { get; set; } = null!;

      [JsonPropertyName("password")]
      public string Password { get; set; } = null!;
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
