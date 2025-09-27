using Playwright.SauceDemo.Models.Checkout;

namespace Playwright.SauceDemo.Utils.Providers
{
   internal class CheckoutOneProvider
   {
      // Constants:
      private const string moduleName = "Checkout";
      private const string checkoutOnePositive = "CheckoutOneTestData_Positive.json";
      private const string checkoutOneNegative = "CheckoutOneTestData_Negative.json";

      /// <summary>
      /// Get single test case by Id or Type.
      /// </summary>
      /// <returns>The test case with matching Id or Type or both.</returns>
      public static CheckoutOneTestCase? GetRecord(string fileName, string id, string? type = null)
      {
         var data = JsonHelper.LoadJson<CheckoutOneTestData>(moduleName, fileName);

         return data?.TestCases?
            .FirstOrDefault(tc => tc.Id == id && (string.IsNullOrEmpty(type) || tc.Type == type));
      }

      /// <summary>
      /// Get all test case
      /// </summary>
      /// <returns>All test cases.</returns>
      public static IEnumerable<CheckoutOneTestCase> GetRecords(string fileName)
      {
         var data = JsonHelper.LoadJson<CheckoutOneTestData>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<CheckoutOneTestCase>();
      }

      // Get single record.
      public static CheckoutOneTestCase? GetPositiveCaseById(string id) => GetRecord(fileName: checkoutOnePositive, id);
      public static CheckoutOneTestCase? GetPositiveCaseByIdAndType(string id, string type) => GetRecord(fileName: checkoutOnePositive, id, type);
      public static CheckoutOneTestCase? GetNegativeCaseById(string id) => GetRecord(fileName: checkoutOneNegative, id);
      public static CheckoutOneTestCase? GetNegativeCaseByIdAndType(string id, string type) => GetRecord(fileName: checkoutOneNegative, id, type);

      // Get multiple records.
      public static IEnumerable<CheckoutOneTestCase> GetPositiveCases() => GetRecords(fileName: checkoutOnePositive);
      public static IEnumerable<CheckoutOneTestCase> GetNegativeCases() => GetRecords(fileName: checkoutOneNegative);
   }
}
