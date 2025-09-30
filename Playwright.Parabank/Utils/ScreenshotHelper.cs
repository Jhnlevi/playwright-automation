using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.Parabank.Utils
{
   internal class ScreenshotHelper
   {
      public static async Task<string> CaptureAsync(IPage page, string name = "")
      {
         var directory = PathsHelper.GetScreenshotPath();
         Directory.CreateDirectory(directory);

         var defaultName = String.IsNullOrWhiteSpace(name) ? "Screenshot" : name;
         var fileName = $"{defaultName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
         var filePath = Path.Combine(directory, fileName);

         await page.ScreenshotAsync(new PageScreenshotOptions
         {
            Path = filePath,
            FullPage = true
         });

         return filePath;
      }
   }
}
