using System.Text.Json.Serialization;

namespace Playwright.SauceDemo.Models.Product
{
   internal class ProductTestData
   {
      [JsonPropertyName("testCases")]
      public List<ProductTestCase>? TestCases { get; set; }
   }
   internal class ProductTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("itemName")]
      public string ItemName { get; set; } = null!;

      [JsonPropertyName("itemDescription")]
      public string ItemDescription { get; set; } = null!;

      [JsonPropertyName("itemPrice")]
      public string ItemPrice { get; set; } = null!;

      public override string ToString()
      {
         return $"{Id} : {ItemName}";
      }
   }
}
