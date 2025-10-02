using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Login
{
   public class LoginModel
   {
      [JsonPropertyName("testCases")]
      public List<LoginTestCase>? TestCases { get; set; }
   }

   public class LoginTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string? Type { get; set; }

      [JsonPropertyName("data")]
      public Data Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public Expectedresult ExpectedResult { get; set; } = null!;

      public override string ToString()
      {
         return $"{Id} : {Description}";
      }
   }

   public class Data
   {
      [JsonPropertyName("user")]
      public User User { get; set; } = null!;
   }

   public class User
   {
      [JsonPropertyName("userName")]
      public string UserName { get; set; } = null!;

      [JsonPropertyName("password")]
      public string Password { get; set; } = null!;
   }

   public class Expectedresult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<Fielderrors>? FieldErrors { get; set; }
   }

   public class Fielderrors
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
