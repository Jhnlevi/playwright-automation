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
    internal class TransferFundTests : BaseTest
    {
        private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;
        private LoginPage _login;
        private OverviewPage _overview;
        private TransferFundPage _tf;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _login = new LoginPage(Page);
            _overview = new OverviewPage(Page);
            _tf = new TransferFundPage(Page);

            var URL = _config.Environments.Qa.BaseUrl;

            ReportManager.Log(_info, "Navigating to Parabank Website.");
            Page.GotoAsync(URL + LoginPageConstants.URL_PATH);

            // Will need to refactor this later
            ReportManager.Log(_info, "Logging in to Parabank.");
            _login.EnterTextAsync(LoginPageConstants.LOGIN_USERNAME_FIELD, "JohnnySeed12").GetAwaiter().GetResult();
            _login.EnterTextAsync(LoginPageConstants.LOGIN_PASSWORD_FIELD, "JohnnyPassword01").GetAwaiter().GetResult();
            _login.ClickElementAsync(LoginPageConstants.LOGIN_BUTTON).GetAwaiter().GetResult();
        }

        [Category("UI")]
        [TestCaseSource(typeof(TFProvider), nameof(TFProvider.GetPositiveCases))]
        public async Task TF_ValidFundTransfer_ShouldSucceed(TFTestCase testCase)
        {
            var data = testCase.Data;
            var transaction = data.Transaction;

            Assert.Multiple(() =>
            {
                Assert.That(data, Is.Not.Null, "Data should not be null.");
                Assert.That(transaction, Is.Not.Null, "Account should not be null.");
            });

            var fromAccount = await Page.Locator("tr td a").Nth(0).InnerTextAsync();
            var toAccount = await Page.Locator("tr td a").Nth(1).InnerTextAsync();

            ReportManager.Log(_info, "Navigating to 'Transfer Funds' page.");
            await _tf._menu.ClickElementAsync(MenuComponentConstants.MENU_LINK_TRANSFER_FUNDS);

            ReportManager.Log(_info, "Entering amount");
            await _tf.EnterTextAsync(TransferFundsPageConstants.TF_AMOUNT, transaction.Amount);

            ReportManager.Log(_info, "Selecting 'from account'.");
            await _tf.SelectDropdownByLabelAsync(TransferFundsPageConstants.TF_FROM_ACCOUNT, fromAccount);

            ReportManager.Log(_info, "Selecting 'to account'.");
            await _tf.SelectDropdownByLabelAsync(TransferFundsPageConstants.TF_TO_ACCOUNT, toAccount);

            ReportManager.Log(_info, "Clicking 'TRANSFER' button.");
            await _tf.ClickElementAsync(TransferFundsPageConstants.TF_TRANSFER_BUTTON);

            ReportManager.Log(_info, "Verifying the transaction is successful");

            var result = _tf.IsElementDisplayed(TransferFundsPageConstants.TF_RESULT);

            await Assert.MultipleAsync(async () =>
            {
                await Expect(result).ToBeVisibleAsync();
                await Expect(result).ToContainTextAsync("Transfer Complete!");
            });
        }

        [TestCaseSource(typeof(TFProvider), nameof(TFProvider.GetNegativeCases))]
        public async Task TF_InvalidFundTransfer_ShouldFail(TFTestCase testCase)
        {
            var data = testCase.Data;
            var transaction = data.Transaction;

            Assert.Multiple(() =>
            {
                Assert.That(data, Is.Not.Null, "Data should not be null.");
                Assert.That(transaction, Is.Not.Null, "Account should not be null.");
            });

            var fromAccount = await Page.Locator("tr td a").Nth(0).InnerTextAsync();
            var toAccount = await Page.Locator("tr td a").Nth(1).InnerTextAsync();

            ReportManager.Log(_info, "Navigating to 'Transfer Funds' page.");
            await _tf._menu.ClickElementAsync(MenuComponentConstants.MENU_LINK_TRANSFER_FUNDS);
            ReportManager.Log(_info, "Entering amount");
            await _tf.EnterTextAsync(TransferFundsPageConstants.TF_AMOUNT, transaction.Amount);
            ReportManager.Log(_info, "Selecting 'from account'.");
            await _tf.SelectDropdownByLabelAsync(TransferFundsPageConstants.TF_FROM_ACCOUNT, SharedTestData.AccountId);
            ReportManager.Log(_info, "Selecting 'to account'.");
            await _tf.SelectDropdownByLabelAsync(TransferFundsPageConstants.TF_TO_ACCOUNT, SharedTestData.OtherAccountId);
            ReportManager.Log(_info, "Clicking 'TRANSFER' button.");
            await _tf.ClickElementAsync(TransferFundsPageConstants.TF_TRANSFER_BUTTON);
            ReportManager.Log(_info, "Verifying the transaction is successful");

            var result = _tf.IsElementDisplayed(TransferFundsPageConstants.TF_ERROR);

            await Assert.MultipleAsync(async () =>
            {
                await Expect(result).ToBeVisibleAsync();
                await Expect(result).ToContainTextAsync("An internal error has occurred and has been logged.");
            });
        }
    }
}
