using System.Text.Json.Serialization;

namespace Playwright.SauceDemo.Models.E2E
{
   internal class E2ETestData
   {
      [JsonPropertyName("testCases")]
      public List<E2ETestCase>? TestCases { get; set; }
   }
   internal class E2ETestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("data")]
      public E2EData Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public ExpectedResult ExpectedResult { get; set; } = null!;

      public override string ToString()
      {
         return $"{Id} : {Description}";
      }
   }
   internal class E2EData
   {
      [JsonPropertyName("user")]
      public E2EData_User User { get; set; } = null!;

      [JsonPropertyName("order")]
      public E2EData_Order? Order { get; set; } = null!;
   }
   internal class E2EData_User
   {
      [JsonPropertyName("userName")]
      public string UserName { get; set; } = null!;

      [JsonPropertyName("password")]
      public string Password { get; set; } = null!;

      // Optional fields
      [JsonPropertyName("firstName")]
      public string? FirstName { get; set; } = null!;

      [JsonPropertyName("lastName")]
      public string? LastName { get; set; } = null!;

      [JsonPropertyName("postalCode")]
      public string? PostalCode { get; set; } = null!;
   }
   internal class E2EData_Order
   {
      public List<E2EData_Order_Products>? Products { get; set; }
      public List<E2EData_Order_Sorters>? Sorters { get; set; }
   }
   internal class E2EData_Order_Products
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("itemName")]
      public string ItemName { get; set; } = null!;

      [JsonPropertyName("itemDescription")]
      public string ItemDescription { get; set; } = null!;

      [JsonPropertyName("itemPrice")]
      public string ItemPrice { get; set; } = null!;
   }
   internal class E2EData_Order_Sorters
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("sortName")]
      public string SortName { get; set; } = null!;

      [JsonPropertyName("sortValue")]
      public string SortValue { get; set; } = null!;
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
