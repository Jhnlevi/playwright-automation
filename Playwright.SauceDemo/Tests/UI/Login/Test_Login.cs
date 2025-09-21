using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Utils;

namespace Playwright.SauceDemo.Tests.UI.Login
{
   internal class Test_Login : BaseTest
   {
      private Page_Login _login;
      private readonly Util_ReportManager.LogLevel ReportInfo = Util_ReportManager.LogLevel.Info;

      [SetUp]
      public override void Setup()
      {
         base.Setup();

         _login = new Page_Login(Page);

         // Navigate to SauceDemo website
         Util_ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
         Page.GotoAsync(_config.BaseUrl);
      }

      [Test]
      public async Task Login_VerifyWithValidCredentials()
      {
         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, "standard_user");
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, "secret_sauce");
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");

         var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

         await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
         await Expect(inventoryContainer).ToBeVisibleAsync();
      }
   }
}
