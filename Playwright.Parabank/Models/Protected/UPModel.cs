using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
   internal class UPModel
   {
      [JsonPropertyName("testCases")]
      public List<UPTestCase>? TestCases { get; set; }
   }

   public class UPTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string Type { get; set; } = null!;

      [JsonPropertyName("data")]
      public UPData Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public UPExpectedresult ExpectedResult { get; set; } = null!;
   }

   public class UPData
   {
      [JsonPropertyName("profileData")]
      public UPProfiledata ProfileData { get; set; } = null!;
   }

   public class UPProfiledata
   {
      [JsonPropertyName("firstName")]
      public string FirstName { get; set; } = null!;

      [JsonPropertyName("lastName")]
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
      public string MobileNumber { get; set; } = null!;
   }

   public class UPExpectedresult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<UPFielderror>? FieldErrors { get; set; }
   }

   public class UPFielderror
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
