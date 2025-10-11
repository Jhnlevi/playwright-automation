namespace Playwright.API.Utils
{
   internal static class TestResultHelper
   {
      public static void LogResultsAsync(
           string status,
           string message,
           string trace)
      {
         switch (status)
         {
            case "Passed":
               ReportManager.Log(ReportManager.LogLevel.Pass, "Test passed!");
               break;
            case "Failed":
               ReportManager.Log(ReportManager.LogLevel.Fail, $"Test failed: {message}");
               ReportManager.Log(ReportManager.LogLevel.Info, $"Stack trace: {trace}");
               break;
            default:
               throw new ArgumentOutOfRangeException("Out of option.");
         }
      }
   }
}
