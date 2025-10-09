using Playwright.Parabank.Models.Login;

namespace Playwright.Parabank.Utils.Providers
{
    internal static class LoginProvider
    {
        private const string moduleName = "Login";
        private const string positive = "LoginTD_Positive.json";
        private const string negative = "LoginTD_Negative.json";

        public static IEnumerable<LoginTestCase> GetRecords(string fileName)
        {
            var data = JsonHelper.LoadJson<LoginModel>(moduleName, fileName);
            return data?.TestCases ?? Enumerable.Empty<LoginTestCase>();
        }

        public static IEnumerable<LoginTestCase> GetPositiveCases() => GetRecords(fileName: positive);
        public static IEnumerable<LoginTestCase> GetNegativeCases() => GetRecords(fileName: negative);
    }
}
