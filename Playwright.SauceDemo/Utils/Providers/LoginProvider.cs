using Playwright.SauceDemo.Models.Login;

namespace Playwright.SauceDemo.Utils.Provider
{
    internal class LoginProvider
    {
        // Constants:
        private const string moduleName = "Login";
        private const string positiveFile = "LoginTestData_Positive.json";
        private const string negativeFile = "LoginTestData_Negative.json";

        /// <summary>
        /// Get single test case by Id or Type.
        /// </summary>
        /// <returns>The test case with matching Id or Type or both.</returns>
        public static LoginTestCase? GetRecord(string fileName, string id, string? type = null)
        {
            var data = JsonHelper.LoadJson<LoginTestData>(moduleName, fileName);

            return data?.TestCases?
               .FirstOrDefault(tc => tc.Id == id && (string.IsNullOrEmpty(type) || tc.Type == type));
        }

        /// <summary>
        /// Get all test case
        /// </summary>
        /// <returns>All test cases.</returns>
        public static IEnumerable<LoginTestCase> GetRecords(string fileName)
        {
            var data = JsonHelper.LoadJson<LoginTestData>(moduleName, fileName);
            return data?.TestCases ?? Enumerable.Empty<LoginTestCase>();
        }

        // Get single record.
        public static LoginTestCase? GetPositiveCaseById(string id) => GetRecord(fileName: positiveFile, id);
        public static LoginTestCase? GetPositiveCaseByIdAndType(string id, string type) => GetRecord(fileName: positiveFile, id, type);
        public static LoginTestCase? GetNegativeCaseById(string id) => GetRecord(fileName: negativeFile, id);
        public static LoginTestCase? GetNegativeCaseByIdAndType(string id, string type) => GetRecord(fileName: negativeFile, id, type);

        // Get multiple records.
        public static IEnumerable<LoginTestCase> GetPositiveCases() => GetRecords(fileName: positiveFile);
        public static IEnumerable<LoginTestCase> GetNegativeCases() => GetRecords(fileName: negativeFile);
    }
}
