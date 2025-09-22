using Playwright.SauceDemo.Constants.Login;
using Playwright.SauceDemo.Models.Login;
using Playwright.SauceDemo.Pages.Login;
using Playwright.SauceDemo.Utils;
using Playwright.SauceDemo.Utils.Provider;

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

      [TestCaseSource(typeof(Provider_Login), nameof(Provider_Login.GetPositiveCases))]
      public async Task Login_VerifyWithValidCredentials(LoginTestCase testCase)
      {
         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, testCase.Data!.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, testCase.Data!.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");

         var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

         await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
         await Expect(inventoryContainer).ToBeVisibleAsync();
      }

      [TestCaseSource(typeof(Provider_Login), nameof(Provider_Login.GetNegativeCases))]
      public async Task Login_VerifyWithInvalidCredentials(LoginTestCase testCase)
      {
         // Skipping a test case with type of "Locked Out User".
         if (testCase.Type == "locked_out_user")
         {
            Util_ReportManager.Log(ReportInfo, $"Skipping test case {testCase.Id} of type {testCase.Type}");
            Assert.Ignore($"Skipping test case {testCase.Id} of type {testCase.Type}");
         }

         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, testCase.Data!.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, testCase.Data!.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user cannot login with invalid/missing credentials.");
         await Expect(_login.IsElementDisplayed(Field_Login.LOGIN_ERROR_MESSAGE)).ToBeVisibleAsync();
      }

      [TestCaseSource(typeof(Provider_Login), nameof(Provider_Login.GetNegativeCases))]
      public async Task Login_VerifyLockedUserAccount(LoginTestCase testCase)
      {
         // Skipping a test cases that are not with type of "Locked Out User".
         if (testCase.Type != "locked_out_user")
         {
            Util_ReportManager.Log(ReportInfo, $"Skipping test case {testCase.Id} of type {testCase.Type}");
            Assert.Ignore($"Skipping test case {testCase.Id} of type {testCase.Type}");
         }

         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, testCase.Data!.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, testCase.Data!.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user cannot login with invalid/missing credentials.");
         await Expect(_login.IsElementDisplayed(Field_Login.LOGIN_ERROR_MESSAGE)).ToBeVisibleAsync();
      }
   }
}
