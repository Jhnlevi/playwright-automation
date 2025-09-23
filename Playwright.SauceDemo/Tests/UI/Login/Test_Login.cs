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

         Util_ReportManager.Log(ReportInfo, "Navigating to SauceDemo Website.");
         Page.GotoAsync(_config.BaseUrl);
      }

      // Methods
      public static IEnumerable<LoginTestCase> GetStandardUser() => Provider_Login.GetPositiveCases().Where(tc => tc.Id == "TC_Login_0001_1");

      public static IEnumerable<LoginTestCase> GetLockedOutUsers() => Provider_Login.GetNegativeCases().Where(tc => tc.Type == "locked_out_user");

      public static IEnumerable<LoginTestCase> GetInvalidCases() => Provider_Login.GetNegativeCases().Where(tc => tc.Type != "locked_out_user");

      // Tests
      [Category("UI")]
      [TestCaseSource(nameof(GetStandardUser))]
      public async Task Login_VerifyStandardUserAccount_ShouldSucceed(LoginTestCase testCase)
      {
         var data = testCase.Data;

         if (data == null)
         {
            Assert.Fail("Test data is null.");
            return;
         }

         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, data.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, data.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");
         var inventoryContainer = Page.Locator("#inventory_container.inventory_container");
         await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
         await Expect(inventoryContainer).ToBeVisibleAsync();
      }

      [TestCaseSource(typeof(Provider_Login), nameof(Provider_Login.GetPositiveCases))]
      public async Task Login_VerifyWithValidCredentials_ShouldSucceed(LoginTestCase testCase)
      {
         var data = testCase.Data;

         if (data == null)
         {
            Assert.Fail("Test data is null.");
            return;
         }

         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, data.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, data.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user can login with valid credentials and reach 'Inventory' page.");

         var inventoryContainer = Page.Locator("#inventory_container.inventory_container");

         await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/v1/inventory.html");
         await Expect(inventoryContainer).ToBeVisibleAsync();
      }

      [TestCaseSource(nameof(GetInvalidCases))]
      public async Task Login_VerifyWithInvalidCredentials_ShouldFail(LoginTestCase testCase)
      {
         var data = testCase.Data;

         if (data == null)
         {
            Assert.Fail("Test data is null.");
            return;
         }

         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, data.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, data.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user cannot login with invalid/missing credentials.");
         await Expect(_login.IsElementDisplayed(Field_Login.LOGIN_ERROR_MESSAGE)).ToBeVisibleAsync();
      }

      [TestCaseSource(nameof(GetLockedOutUsers))]
      public async Task Login_VerifyLockedUserAccount_ShouldFail(LoginTestCase testCase)
      {
         var data = testCase.Data;

         if (data == null)
         {
            Assert.Fail("Test data is null.");
            return;
         }

         Util_ReportManager.Log(ReportInfo, "Entering Username.");
         await _login.EnterTextAsync(Field_Login.LOGIN_USERNAME, data.Username);
         Util_ReportManager.Log(ReportInfo, "Entering Password.");
         await _login.EnterTextAsync(Field_Login.LOGIN_PASSWORD, data.Password);
         Util_ReportManager.Log(ReportInfo, "Clicking 'Login' button.");
         await _login.ClickElementAsync(Field_Login.LOGIN_BUTTON);
         Util_ReportManager.Log(ReportInfo, "Verifying that the user cannot login with invalid/missing credentials.");
         await Expect(_login.IsElementDisplayed(Field_Login.LOGIN_ERROR_MESSAGE)).ToBeVisibleAsync();
      }
   }
}
