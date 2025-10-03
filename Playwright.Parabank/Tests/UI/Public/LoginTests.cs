using Playwright.Parabank.Constants.Public;
using Playwright.Parabank.Models.Login;
using Playwright.Parabank.Pages.Public;
using Playwright.Parabank.Utils;
using Playwright.Parabank.Utils.Providers;

namespace Playwright.Parabank.Tests.UI.Public
{
   internal class LoginTests : BaseTest
   {
      private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;
      private LoginPage _login;

      [SetUp]
      public override void Setup()
      {
         base.Setup();

         _login = new LoginPage(Page);

         ReportManager.Log(_info, "Navigating to Parabank Website.");
         Page.GotoAsync(_config.BaseUrl);
      }

      [Category("UI")]
      [TestCaseSource(typeof(LoginProvider), nameof(LoginProvider.GetPositiveCases))]
      public async Task Login_WtihValidCredentials_ShouldSucceed(LoginTestCase testCase)
      {
         var data = testCase.Data;
         Assert.That(data, Is.Not.Null, "Data should not be null.");

         var user = data.User;
         Assert.That(user, Is.Not.Null, "User should not be null.");

         ReportManager.Log(_info, "Entering username");
         await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME_FIELD, user.UserName);
         ReportManager.Log(_info, "Entering password");
         await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD_FIELD, user.Password);
         ReportManager.Log(_info, "Clicking 'Login' button.");
         await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
         ReportManager.Log(_info, "Verifying that the user reaches the dashboard overview after logging in.");

         var overview = Page.Locator("#showOverview");

         Assert.That(Page.Url, Does.Contain("parabank/overview"));
         await Expect(overview).ToBeVisibleAsync();
      }

      [TestCaseSource(typeof(CustomDataSource), nameof(CustomDataSource.RemoveTC05))]
      public async Task Login_WithInvalidCredentials_ShouldFail(LoginTestCase testCase)
      {
         var data = testCase.Data;
         Assert.That(data, Is.Not.Null, "Data should not be null.");

         var user = data.User;
         Assert.That(user, Is.Not.Null, "User should not be null.");

         ReportManager.Log(_info, "Entering username");
         await _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME_FIELD, user.UserName);
         ReportManager.Log(_info, "Entering password");
         await _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD_FIELD, user.Password);
         ReportManager.Log(_info, "Clicking 'Login' button.");
         await _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON);
         ReportManager.Log(_info, "Verifying that login process will not continue with invalid credentials.");

         var fieldErrors = testCase.ExpectedResult.FieldErrors;
         Assert.That(fieldErrors, Is.Not.Null, "Field errors should not be null.");

         foreach (var err in fieldErrors)
         {

            var error = await Page.Locator($".{err.Field}").InnerTextAsync();
            ReportManager.Log(_info, $"Error message: {error}");
            Assert.That(error, Is.EqualTo($"{err.Message}"));
         }
      }

      // Filtered test cases.
      private static class CustomDataSource
      {
         public static IEnumerable<LoginTestCase> RemoveTC05() => LoginProvider.GetNegativeCases().Where(tc => tc.Id != "TC_LOGIN_0005");
      }
   }
}
