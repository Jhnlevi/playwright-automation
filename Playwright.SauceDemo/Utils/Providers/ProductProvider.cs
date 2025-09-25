using Playwright.SauceDemo.Models.Product;

namespace Playwright.SauceDemo.Utils.Providers
{
   internal class ProductProvider
   {
      // Constants:
      private const string moduleName = "Product";
      private const string productsFile = "ProductTestData_Products.json";
      private const string sortersFile = "ProductTestData_Sorters.json";

      /// <summary>
      /// Get single test case by Id or Type.
      /// </summary>
      /// <returns>The test case with matching Id or Type or both.</returns>
      public static ProductTestCase? GetProductRecord(string fileName, string id)
      {
         var data = JsonHelper.LoadJson<ProductTestData_Products>(moduleName, fileName);

         return data?.TestCases?.FirstOrDefault(tc => tc.Id == id);
      }

      /// <summary>
      /// Get single test case by Id or Type.
      /// </summary>
      /// <returns>The test case with matching Id or Type or both.</returns>
      public static ProductSortersTestCase? GetSortRecord(string fileName, string id)
      {
         var data = JsonHelper.LoadJson<ProductTestData_Sorters>(moduleName, fileName);

         return data?.TestCases?.FirstOrDefault(tc => tc.Id == id);
      }

      /// <summary>
      /// Get all test case
      /// </summary>
      /// <returns>All test cases.</returns>
      public static IEnumerable<ProductTestCase> GetProducts(string fileName)
      {
         var data = JsonHelper.LoadJson<ProductTestData_Products>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<ProductTestCase>();
      }

      /// <summary>
      /// Get all test case
      /// </summary>
      /// <returns>All test cases.</returns>
      public static IEnumerable<ProductSortersTestCase> GetSorters(string fileName)
      {
         var data = JsonHelper.LoadJson<ProductTestData_Sorters>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<ProductSortersTestCase>();
      }

      // Get single record.
      public static ProductTestCase? GetProductById(string id) => GetProductRecord(fileName: productsFile, id);
      public static ProductSortersTestCase? GetSortById(string id) => GetSortRecord(fileName: sortersFile, id);

      // Get multiple records.
      public static IEnumerable<ProductTestCase> GetAllProducts() => GetProducts(fileName: productsFile);
      public static IEnumerable<ProductSortersTestCase> GetAllSorters() => GetSorters(fileName: sortersFile);
   }
}
