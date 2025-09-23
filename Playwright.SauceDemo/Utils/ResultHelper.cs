using Microsoft.Playwright;

namespace Playwright.SauceDemo.Utils
{
   internal static class ResultHelper
   {
      //Path = $"Report/Screenshots/{name}.png"
      public static async Task LogResultsAsync(
         IPage page,
         string status,
         string message,
         string trace,
         string name)
      {
         switch (status)
         {
            case "Passed":
               ReportManager.Log(ReportManager.LogLevel.Pass, "Test passed!");
               break;
            case "Failed":
               string path = await ScreenshotHelper.CaptureAsync(page, name);
               ReportManager.Log(ReportManager.LogLevel.Fail, $"Test failed: {message}");
               ReportManager.Log(ReportManager.LogLevel.Info, $"Stack trace: {trace}");
               ReportManager.AttachScreenshot(path);
               break;
            default:
               break;
         }
      }
   }
}
