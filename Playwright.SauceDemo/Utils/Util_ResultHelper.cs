using Microsoft.Playwright;

namespace Playwright.SauceDemo.Utils
{
   internal static class Util_ResultHelper
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
               Util_ReportManager.Log(Util_ReportManager.LogLevel.Pass, "Test passed!");
               break;
            case "Failed":
               string path = await Util_ScreenshotHelper.CaptureAsync(page, name);
               Util_ReportManager.Log(Util_ReportManager.LogLevel.Fail, $"Test failed: {message}");
               Util_ReportManager.Log(Util_ReportManager.LogLevel.Info, $"Stack trace: {trace}");
               Util_ReportManager.AttachScreenshot(path);
               break;
            default:
               break;
         }
      }
   }
}
