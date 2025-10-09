using Playwright.Parabank.Models.Protected;

namespace Playwright.Parabank.Utils.Providers
{
   internal class ONAProvider
   {
      private const string moduleName = "OpenNewAccount";
      private const string positive = "ONATD_Positive.json";

      public static IEnumerable<ONATestCase> GetRecords(string fileName)
      {
         var data = JsonHelper.LoadJson<ONAModel>(moduleName, fileName);
         return data?.TestCases ?? Enumerable.Empty<ONATestCase>();
      }

      public static IEnumerable<ONATestCase> GetPositiveCases() => GetRecords(fileName: positive);
   }
}
