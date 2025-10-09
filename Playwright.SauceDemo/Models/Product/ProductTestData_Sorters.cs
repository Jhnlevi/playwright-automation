using System.Text.Json.Serialization;

namespace Playwright.SauceDemo.Models.Product
{
    internal class ProductTestData_Sorters
    {
        [JsonPropertyName("testCases")]
        public List<ProductSortTestCase>? TestCases { get; set; }
    }
    internal class ProductSortTestCase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("sortName")]
        public string SortName { get; set; } = null!;

        [JsonPropertyName("sortValue")]
        public string SortValue { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} : {SortName}";
        }
    }
}
