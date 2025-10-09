using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
    internal class ONAModel
    {
        [JsonPropertyName("testCases")]
        public List<ONATestCase>? TestCases { get; set; }
    }

    public class ONATestCase
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("data")]
        public ONAData Data { get; set; } = null!;

        [JsonPropertyName("expectedResult")]
        public ONAExpectedresult ExpectedResult { get; set; } = null!;

        public override string ToString()
        {
            return $"{Id} : {Description}";
        }
    }

    public class ONAData
    {
        [JsonPropertyName("account")]
        public ONAAccount Account { get; set; } = null!;
    }

    public class ONAAccount
    {
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = null!;

        [JsonPropertyName("existingAccount")]
        public string ExistingAccount { get; set; } = null!;
    }

    public class ONAExpectedresult
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonPropertyName("fieldErrors")]
        public List<ONAFielderrors>? FieldErrors { get; set; } = null!;
    }
    public class ONAFielderrors
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;
    }
}
