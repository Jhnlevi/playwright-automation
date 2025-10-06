using Microsoft.Playwright;
using Playwright.Parabank.Constants.Overview;
using Playwright.Parabank.Constants.Public;
using Playwright.Parabank.Pages.Protected;
using Playwright.Parabank.Pages.Public;
using Playwright.Parabank.Utils;

namespace Playwright.Parabank.Tests.UI.Protected
{
   internal class OverviewTests : BaseTest
   {
      private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;
      private LoginPage _login;
      private OverviewPage _overview;

      [SetUp]
      public override void Setup()
      {
         base.Setup();

         _login = new LoginPage(Page);
         _overview = new OverviewPage(Page);

         var URL = _config.Environments.Qa.BaseUrl;

         ReportManager.Log(_info, "Navigating to Parabank Website.");
         Page.GotoAsync(URL + LoginPageConstants.URL_PATH);

         // Will need to refactor this later
         ReportManager.Log(_info, "Logging in to Parabank.");
         _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME_FIELD, "JohnnySeed12").GetAwaiter().GetResult();
         _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD_FIELD, "JohnnyPassword01").GetAwaiter().GetResult();
         _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON).GetAwaiter().GetResult();
      }

      [Test]
      public async Task Overview_AccountTable_WithCorrectStructureAndFormat()
      {
         ReportManager.Log(_info, "Verifying that the account table is visible and has correct structure.");

         var table = _overview.IsElementDisplayed(OverviewPageConstants.OVERVIEW_TABLE);
         var headers = table.Locator("thead tr th");
         var rows = table.Locator("tbody tr").First;

         // Check if table is visible
         await Expect(table).ToBeVisibleAsync();

         // Check headers 
         await Expect(headers).ToHaveTextAsync(new[] { "Account", "Balance*", "Available Amount" });


         await rows.WaitForAsync(new()
         {
            State = WaitForSelectorState.Visible,
            Timeout = 5000
         });

         var rowCounts = await rows.CountAsync();

         // Check if there's at least a single data row
         Assert.That(rowCounts, Is.GreaterThan(0), "Table should have atleast one row of data present.");
      }
   }
}
