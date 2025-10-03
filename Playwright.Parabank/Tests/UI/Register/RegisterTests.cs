using Playwright.Parabank.Constants.Public;
using Playwright.Parabank.Models.Register;
using Playwright.Parabank.Pages.Login;
using Playwright.Parabank.Pages.Register;
using Playwright.Parabank.Utils;
using Playwright.Parabank.Utils.Providers;

namespace Playwright.Parabank.Tests.UI.Register
{
   internal class RegisterTests : BaseTest
   {
      private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;
      private RegisterPage _register;
      private LoginPage _login;

      [SetUp]
      public override void Setup()
      {
         base.Setup();

         _register = new RegisterPage(Page);
         _login = new LoginPage(Page);

         ReportManager.Log(_info, "Navigating to Parabank Website.");
         Page.GotoAsync(_config.BaseUrl);
         ReportManager.Log(_info, "Clicking 'REGISTER' button.");
         _login.ClickElementAsync(LoginPageConstants.LOGIN_REGISTER_BUTTON).GetAwaiter().GetResult();
      }

      [Category("UI")]
      [TestCaseSource(typeof(RegisterProvider), nameof(RegisterProvider.GetPositiveCases))]
      public async Task Register_WithValidInputs_ShouldSucceed(RegisterTestCase testCase)
      {
         var data = testCase.Data;
         Assert.That(data, Is.Not.Null, "Data should not be null.");

         var user = data.User;
         Assert.That(user, Is.Not.Null, "User should not be null.");

         ReportManager.Log(_info, "Entering First Name");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_FIRST_NAME_FIELD, user.FirstName);
         ReportManager.Log(_info, "Entering Last Name");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_LAST_NAME_FIELD, user.LastName);
         ReportManager.Log(_info, "Entering Address");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_ADDRESS_FIELD, user.Address);
         ReportManager.Log(_info, "Entering City");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_CITY_FIELD, user.City);
         ReportManager.Log(_info, "Entering State");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_STATE_FIELD, user.State);
         ReportManager.Log(_info, "Entering Zip Code");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_ZIP_CODE_FIELD, user.ZipCode);
         ReportManager.Log(_info, "Entering Mobile Number");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_MOBILE_NUMBER_FIELD, user.MobileNumber!);
         ReportManager.Log(_info, "Entering SSN");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_SSN_FIELD, user.SSN);
         ReportManager.Log(_info, "Entering Username");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_USERNAME_FIELD, user.UserName);
         ReportManager.Log(_info, "Entering Password");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_PASSWORD_FIELD, user.Password);
         ReportManager.Log(_info, "Entering Confirm Password");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_CONFIRM_PASSWORD_FIELD, user.ConfirmPassword);
         ReportManager.Log(_info, "Clicking 'REGISTER' button.");
         await _register.ClickElementAsync(RegisterPageConstants.REGISTER_BUTTON);
         ReportManager.Log(_info, "Verifying that the account registration is successful.");

         var welcomeTitle = Page.Locator("#rightPanel").Locator(".title");
         var welcomeMessage = Page.Locator("#rightPanel p");

         await Expect(welcomeTitle).ToBeVisibleAsync();
         await Expect(welcomeMessage).ToBeVisibleAsync();
      }

      // Temporary tag for CI
      [Category("E2E")]
      [TestCaseSource(typeof(RegisterProvider), nameof(RegisterProvider.GetNegativeCases))]
      public async Task Register_WithInvalidInputs_ShouldSucceed(RegisterTestCase testCase)
      {
         var data = testCase.Data;
         Assert.That(data, Is.Not.Null, "Data should not be null.");

         var user = data.User;
         Assert.That(user, Is.Not.Null, "User should not be null.");

         ReportManager.Log(_info, "Entering First Name");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_FIRST_NAME_FIELD, user.FirstName);
         ReportManager.Log(_info, "Entering Last Name");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_LAST_NAME_FIELD, user.LastName);
         ReportManager.Log(_info, "Entering Address");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_ADDRESS_FIELD, user.Address);
         ReportManager.Log(_info, "Entering City");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_CITY_FIELD, user.City);
         ReportManager.Log(_info, "Entering State");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_STATE_FIELD, user.State);
         ReportManager.Log(_info, "Entering Zip Code");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_ZIP_CODE_FIELD, user.ZipCode);
         ReportManager.Log(_info, "Entering Mobile Number");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_MOBILE_NUMBER_FIELD, user.MobileNumber!);
         ReportManager.Log(_info, "Entering SSN");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_SSN_FIELD, user.SSN);
         ReportManager.Log(_info, "Entering Username");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_USERNAME_FIELD, user.UserName);
         ReportManager.Log(_info, "Entering Password");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_PASSWORD_FIELD, user.Password);
         ReportManager.Log(_info, "Entering Password");
         await _register.EnterTextAsync(RegisterPageConstants.REGISTER_CONFIRM_PASSWORD_FIELD, user.ConfirmPassword);
         ReportManager.Log(_info, "Clicking 'REGISTER' button.");
         await _register.ClickElementAsync(RegisterPageConstants.REGISTER_BUTTON);
         ReportManager.Log(_info, "Verifying that the account registration is unsuccessful.");

         var fieldErrors = testCase.ExpectedResult.FieldErrors;
         Assert.That(fieldErrors, Is.Not.Null, "Field errors should not be null.");

         foreach (var err in fieldErrors)
         {
            var field = $"#{err.Field}.errors";
            var escaped = field.Replace(".", "\\.");
            var error = await Page.Locator(escaped).InnerTextAsync();
            ReportManager.Log(_info, $"Error message: {err.Message}");
            Assert.That(error, Is.EqualTo($"{err.Message}"));
         }
      }
   }
}
