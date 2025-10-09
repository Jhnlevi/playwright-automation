using System.Text.RegularExpressions;
using Playwright.Parabank.Constants.Components;
using Playwright.Parabank.Constants.Protected;
using Playwright.Parabank.Constants.Public;
using Playwright.Parabank.Models.Protected;
using Playwright.Parabank.Pages.Protected;
using Playwright.Parabank.Pages.Public;
using Playwright.Parabank.Utils;
using Playwright.Parabank.Utils.Providers;

namespace Playwright.Parabank.Tests.UI.Protected
{
   internal class OpenNewAccountTests : BaseTest
   {
      private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;
      private LoginPage _login;
      private OpenNewAccountPage _ona;

      [SetUp]
      public override void Setup()
      {
         base.Setup();

         _login = new LoginPage(Page);
         _ona = new OpenNewAccountPage(Page);

         var URL = _config.Environments.Qa.BaseUrl;

         ReportManager.Log(_info, "Navigating to Parabank Website.");
         Page.GotoAsync(URL + LoginPageConstants.URL_PATH);

         // Will need to refactor this later
         ReportManager.Log(_info, "Logging in to Parabank.");
         _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME_FIELD, "JohnnySeed12").GetAwaiter().GetResult();
         _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD_FIELD, "JohnnyPassword01").GetAwaiter().GetResult();
         _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON).GetAwaiter().GetResult();

         ReportManager.Log(_info, "Navigating to 'Open New Account' page.");
         _ona._menu.ClickElementAsync(MenuComponentConstants.MENU_LINK_OPEN_ACCOUNT).GetAwaiter().GetResult();
      }

      [Category("UI")]
      [TestCaseSource(typeof(ONAProvider), nameof(ONAProvider.GetPositiveCases))]
      public async Task ONA_OpenNewAccount_ShouldSucceed(ONATestCase testCase)
      {
         var data = testCase.Data;
         Assert.That(data, Is.Not.Null, "Data should not be null.");

         var account = data.Account;
         Assert.That(account, Is.Not.Null, "Account should not be null.");

         ReportManager.Log(_info, $"Selecting the account type: {account.AccountType}.");
         await _ona.SelectDropdownByLabelAsync(OpenNewAccountPageConstants.ONA_ACCOUNT_TYPE, account.AccountType);

         // Currently hardcoded existing account ID here to easily update it whenever Parabank changes the ID.
         ReportManager.Log(_info, "Selecting an existing account - 69066");
         await _ona.SelectDropdownByLabelAsync(OpenNewAccountPageConstants.ONA_ACCOUNT_EXISTING_ID, "69066");

         ReportManager.Log(_info, "Clicking 'OPEN NEW ACCOUNT' button.");
         await _ona.ClickElementAsync(OpenNewAccountPageConstants.ONA_BUTTON);

         var accountResult = _ona.IsElementDisplayed(OpenNewAccountPageConstants.ONA_ACCOUNT_RESULT);

         ReportManager.Log(_info, "Verifying that the account is successfully created");
         await Assert.MultipleAsync(async () =>
         {
            await Expect(accountResult).ToBeVisibleAsync();
            await Expect(accountResult).ToContainTextAsync("Congratulations, your account is now open.");
         });

         var newAccountId = await _ona.GetTextAsync(OpenNewAccountPageConstants.ONA_ACCOUNT_NEW_ID);
         var accountDetails = Page.Locator("#accountDetails");

         ReportManager.Log(_info, $"Clicking '{newAccountId}' to open account page.");
         await _ona.ClickElementAsync(OpenNewAccountPageConstants.ONA_ACCOUNT_NEW_ID);

         ReportManager.Log(_info, $"Verifying that the account '{newAccountId}' is accessible.");
         await Assert.MultipleAsync(async () =>
         {
            await Expect(Page).ToHaveURLAsync(new Regex($".*parabank/activity\\.htm\\?id={newAccountId}"));
            await Expect(accountDetails).ToBeVisibleAsync();
         });
      }
   }
}
