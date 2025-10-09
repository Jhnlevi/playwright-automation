using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
    internal class RLModel
    {
        [JsonPropertyName("testCases")]
        public List<RLTestCase>? TestCases { get; set; }
    }

    public class RLTestCase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("data")]
        public RLData Data { get; set; } = null!;

        [JsonPropertyName("expectedResult")]
        public RlExpectedresult ExpectedResult { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} : {Description}";
        }
    }

    public class RLData
    {
        [JsonPropertyName("loan")]
        public RLLoan Loan { get; set; } = null!;
    }

    public class RLLoan
    {
        [JsonPropertyName("loanAmount")]
        public string LoanAmount { get; set; } = null!;

        [JsonPropertyName("downPayment")]
        public string DownPayment { get; set; } = null!;

        [JsonPropertyName("fromAccount")]
        public string FromAccount { get; set; } = null!;
    }

    public class RlExpectedresult
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonPropertyName("fieldErrors")]
        public List<RLFielderror>? FieldErrors { get; set; }
    }

    public class RLFielderror
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;
    }

}
