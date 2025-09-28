using Playwright.SauceDemo.Models.E2E;

namespace Playwright.SauceDemo.Utils.Providers
{
   internal class E2EProvider
   {
      // Constants:
      private const string moduleName = "E2E";
      private const string loginLogout = "E2E_LoginLogout.json";
      private const string singleItem = "E2E_SingleItemCartCheckout.json";
      private const string multipleItem = "E2E_MultipleItemsCartCheckout.json";
      private const string sortProducts = "E2E_SortProducts.json";

      /// <summary>
      /// Get all test case
      /// </summary>
      /// <returns>All test cases.</returns>
      public static IEnumerable<E2ETestCase> GetRecords(string fileName)
      {
         var data = JsonHelper.LoadJson<E2ETestData>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<E2ETestCase>();
      }

      // Get multiple records.
      public static IEnumerable<E2ETestCase> GetLoginLogout() => GetRecords(fileName: loginLogout);
      public static IEnumerable<E2ETestCase> GetSingleItem() => GetRecords(fileName: singleItem);
      public static IEnumerable<E2ETestCase> GetMultipleItem() => GetRecords(fileName: multipleItem);
      public static IEnumerable<E2ETestCase> GetSortProduct() => GetRecords(fileName: sortProducts);

   }
}
