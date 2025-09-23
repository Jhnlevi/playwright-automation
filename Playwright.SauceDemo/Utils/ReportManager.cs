using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Playwright.SauceDemo.Utils
{
   internal static class ReportManager
   {
      private static ExtentTest? _test;
      private static ExtentReports? _extent;

      // Enum for report logging.
      public enum LogLevel { Info, Pass, Fail, Warn };

      /// <summary>
      /// Creates and configure Extent reports.
      /// </summary>
      public static void CreateExtentReport(string name = "Default", string? path = null)
      {
         // Folder location.
         var directory = path ?? PathsHelper.GetReportPath();
         Directory.CreateDirectory(directory);

         // File name.
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
      }

      /// <summary>
      /// Flushes and disposes the current report instance, and resets it.
      /// </summary>
      public static void QuitExtentReport()
      {
         if (_extent != null)
         {
            _extent.Flush();
            _extent = null;
         }
      }

      /// <summary>
      /// Creates an instance to extent test
      /// </summary>
      /// <param name="name">Defaults to 'Test' if not name is specified.</param>
      public static void CreateExtentTest(string name = "Test") => _test = GetExtent().CreateTest(name);

      /// <summary>
      /// Attaches a screenshot to the current test in the report.
      /// </summary>
      public static void AttachScreenshot(string path) => GetTest().AddScreenCaptureFromPath(path);

      /// <summary>
      /// Logs a message to the current instance of GetTest with the specified log level.
      /// </summary>
      /// <param name="level">The log level that determines how the message should be recorded. 
      /// Supported values are <see cref="LogLevel.Info"/>, <see cref="LogLevel.Pass"/>, 
      /// <see cref="LogLevel.Fail"/>, and <see cref="LogLevel.Warn"/>.</param>
      /// <param name="message">The message to be logged in the report.</param>
      /// <exception cref="ArgumentOutOfRangeException">Thrown when an unsupported <paramref name="level"/> is provided.</exception>
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
