using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Register
{
   internal class RegisterModel
   {
      [JsonPropertyName("testCases")]
      public List<RegisterTestCase>? TestCases { get; set; }
   }

   public class RegisterTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string? Type { get; set; }

      [JsonPropertyName("data")]
      public Data Data { get; set; } = null!;

      [JsonPropertyName("ExpectedResult")]
      public Expectedresult ExpectedResult { get; set; } = null!;
   }

   public class Data
   {
      [JsonPropertyName("user")]
      public User User { get; set; } = null!;
   }

   public class User
   {
      [JsonPropertyName("firstName")]
      public string FirstName { get; set; } = null!;

      [JsonPropertyName("LastName")]
      public string LastName { get; set; } = null!;

      [JsonPropertyName("address")]
      public string Address { get; set; } = null!;

      [JsonPropertyName("city")]
      public string City { get; set; } = null!;

      [JsonPropertyName("state")]
      public string State { get; set; } = null!;

      [JsonPropertyName("zipCode")]
      public string ZipCode { get; set; } = null!;

      [JsonPropertyName("mobileNumber")]
      public string? MobileNumber { get; set; }

      [JsonPropertyName("ssn")]
      public string SSN { get; set; } = null!;

      [JsonPropertyName("userName")]
      public string UserName { get; set; } = null!;

      [JsonPropertyName("password")]
      public string Password { get; set; } = null!;

      [JsonPropertyName("confirmPassword")]
      public string ConfirmPassword { get; set; } = null!;
   }

   public class Expectedresult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<FieldErrors>? FieldErrors { get; set; }
   }

   public class FieldErrors
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
