using System.Text.Json.Serialization;

namespace Playwright.Parabank.Models.Protected
{
   internal class BPModel
   {
      [JsonPropertyName("testCases")]
      public List<BPTestCase>? TestCases { get; set; }
   }

   public class BPTestCase
   {
      [JsonPropertyName("id")]
      public string Id { get; set; } = null!;

      [JsonPropertyName("description")]
      public string Description { get; set; } = null!;

      [JsonPropertyName("type")]
      public string Type { get; set; } = null!;

      [JsonPropertyName("data")]
      public BPData Data { get; set; } = null!;

      [JsonPropertyName("expectedResult")]
      public BPExpectedResult ExpectedResult { get; set; } = null!;

      public override string ToString()
      {
         return $"{Id} : {Description}";
      }
   }

   public class BPData
   {
      [JsonPropertyName("payeeInformation")]
      public BPPayeeInformation PayeeInformation { get; set; } = null!;
   }

   public class BPPayeeInformation
   {
      [JsonPropertyName("payeeName")]
      public string PayeeName { get; set; } = null!;

      [JsonPropertyName("payeeAddress")]
      public string PayeeAddress { get; set; } = null!;

      [JsonPropertyName("payeeCity")]
      public string PayeeCity { get; set; } = null!;

      [JsonPropertyName("payeeState")]
      public string PayeeState { get; set; } = null!;

      [JsonPropertyName("payeeZip")]
      public string PayeeZip { get; set; } = null!;

      [JsonPropertyName("payeeMobileNumber")]
      public string PayeeMobileNumber { get; set; } = null!;

      [JsonPropertyName("payeeAccountNumber")]
      public string PayeeAccountNumber { get; set; } = null!;

      [JsonPropertyName("payeeVerifyAccountNumber")]
      public string PayeeVerifyAccountNumber { get; set; } = null!;

      [JsonPropertyName("payeeAmount")]
      public string PayeeAmount { get; set; } = null!;

      [JsonPropertyName("payeeFromAccount")]
      public string PayeeFromAccount { get; set; } = null!;
   }

   public class BPExpectedResult
   {
      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;

      [JsonPropertyName("fieldErrors")]
      public List<BPFieldError>? FieldErrors { get; set; }
   }

   public class BPFieldError
   {
      [JsonPropertyName("field")]
      public string Field { get; set; } = null!;

      [JsonPropertyName("message")]
      public string Message { get; set; } = null!;
   }
}
