using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Playwright.API.Utils
{
    internal static class ReportManager
    {
        private static ExtentTest? _test;
        private static ExtentReports? _extent;

        public enum LogLevel { Info, Pass, Fail, Warn };

        public static void CreateExtentReport(string name = "Default", string? path = null)
        {
            var directory = path ?? ProjectPathHelper.GetReportPath();
            Directory.CreateDirectory(directory);

            var fileName = $"{name}_Report_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.html";

            var report = Path.Combine(directory, fileName);

            var htmlReporter = new ExtentSparkReporter(report);
            htmlReporter.Config.DocumentTitle = $"{name} Test Report";
            htmlReporter.Config.ReportName = $"{name} - Playwright Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            htmlReporter.Config.TimelineEnabled = true;

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
            _extent.AddSystemInfo("MachineName", Environment.MachineName);
            _extent.AddSystemInfo("Framework", $".NET {Environment.Version}");

            var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chromium";
            _extent.AddSystemInfo("Browser", browser);
        }

        public static void QuitExtentReport()
        {
            if (_extent != null)
            {
                _extent.Flush();
                _extent = null;
            }
        }

        public static void CreateExtentTest(string name = "Test") => _test = GetExtent().CreateTest(name);

        public static void AttachScreenshot(string path) => GetTest().AddScreenCaptureFromPath(path);

        public static void Log(LogLevel level, string message)
        {
            var test = GetTest();

            switch (level)
            {
                case LogLevel.Info:
                    test.Info(message);
                    break;
                case LogLevel.Pass:
                    test.Pass(message);
                    break;
                case LogLevel.Fail:
                    test.Fail(message);
                    break;
                case LogLevel.Warn:
                    test.Warning(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }

        private static ExtentReports GetExtent()
        {
            if (_extent == null)
                throw new InvalidOperationException("Extent report has not been created. Call CreateExtentReport() first.");

            return _extent;
        }

        private static ExtentTest GetTest()
        {
            if (_test == null)
            {
                throw new InvalidOperationException("Extent test has not been created. Call CreateExtentTest() first.");
            }

            return _test;
        }
    }
}
