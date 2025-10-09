using Playwright.Parabank.Models.Register;

namespace Playwright.Parabank.Utils.Providers
{
    internal static class RegisterProvider
    {
        private const string moduleName = "Register";
        private const string positive = "RegisterTD_Positive.json";
        private const string negative = "RegisterTD_Negative.json";

        public static IEnumerable<RegisterTestCase> GetRecords(string fileName)
        {
            var data = JsonHelper.LoadJson<RegisterModel>(moduleName, fileName);
            return data?.TestCases ?? Enumerable.Empty<RegisterTestCase>();
        }

        public static IEnumerable<RegisterTestCase> GetPositiveCases() => GetRecords(fileName: positive);
        public static IEnumerable<RegisterTestCase> GetNegativeCases() => GetRecords(fileName: negative);
    }
}
