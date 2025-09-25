using Playwright.SauceDemo.Models.Product;

namespace Playwright.SauceDemo.Utils.Providers
{
   internal class ProductProvider
   {
      // Constants:
      private const string moduleName = "Product";
      private const string productsFile = "ProductTestData_Positive.json";

      /// <summary>
      /// Get single test case by Id or Type.
      /// </summary>
      /// <returns>The test case with matching Id or Type or both.</returns>
      public static ProductTestCase? GetRecord(string fileName, string id)
      {
         var data = JsonHelper.LoadJson<ProductTestData>(moduleName, fileName);

         return data?.TestCases?.FirstOrDefault(tc => tc.Id == id);
      }

      /// <summary>
      /// Get all test case
      /// </summary>
      /// <returns>All test cases.</returns>
      public static IEnumerable<ProductTestCase> GetRecords(string fileName)
      {
         var data = JsonHelper.LoadJson<ProductTestData>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<ProductTestCase>();
      }

      // Get single record.
      public static ProductTestCase? GetPositiveCaseById(string id) => GetRecord(fileName: productsFile, id);

      // Get multiple records.
      public static IEnumerable<ProductTestCase> GetPositiveCases() => GetRecords(fileName: productsFile);
   }
}
