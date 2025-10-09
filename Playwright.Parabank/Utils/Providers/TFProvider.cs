using Playwright.Parabank.Models.Protected;

namespace Playwright.Parabank.Utils.Providers
{
   internal class TFProvider
   {
      private const string moduleName = "TransferFund";
      private const string positive = "TFTD_Positive.json";
      private const string negative = "TFTD_Negative.json";

      public static IEnumerable<TFTestCase> GetRecords(string fileName)
      {
         var data = JsonHelper.LoadJson<TFModel>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<TFTestCase>();
      }

      public static IEnumerable<TFTestCase> GetPositiveCases() => GetRecords(fileName: positive);
      public static IEnumerable<TFTestCase> GetNegativeCases() => GetRecords(fileName: negative);
   }
}
