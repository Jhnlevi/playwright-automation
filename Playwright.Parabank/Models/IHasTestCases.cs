namespace Playwright.Parabank.Models
{
   internal interface IHasTestCases<TTestCase>
   {
      List<TTestCase>? TestCases { get; set; }
   }
}
