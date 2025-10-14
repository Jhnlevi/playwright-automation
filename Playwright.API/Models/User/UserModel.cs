using System.Text.Json.Serialization;

namespace Playwright.API.Models.User
{
   internal class UserModel
   {
      [JsonPropertyName("id")]
      public int Id { get; set; }

      [JsonPropertyName("name")]
      public string Name { get; set; } = null!;

      [JsonPropertyName("username")]
      public string UserName { get; set; } = null!;

      [JsonPropertyName("email")]
      public string Email { get; set; } = null!;

      [JsonPropertyName("address")]
      public Address Address { get; set; } = null!;

      [JsonPropertyName("phone")]
      public string Phone { get; set; } = null!;

      [JsonPropertyName("website")]
      public string Website { get; set; } = null!;

      [JsonPropertyName("company")]
      public Company Company { get; set; } = null!;
   }

   public class Address
   {
      [JsonPropertyName("street")]
      public string Street { get; set; } = null!;

      [JsonPropertyName("suite")]
      public string Suite { get; set; } = null!;

      [JsonPropertyName("city")]
      public string City { get; set; } = null!;

      [JsonPropertyName("zipcode")]
      public string Zipcode { get; set; } = null!;

      [JsonPropertyName("geo")]
      public Geo Geo { get; set; } = null!;
   }

   public class Geo
   {
      [JsonPropertyName("lat")]
      public string Lat { get; set; } = null!;

      [JsonPropertyName("lng")]
      public string Lng { get; set; } = null!;
   }
   public class Company
   {
      [JsonPropertyName("name")]
      public string Name { get; set; } = null!;

      [JsonPropertyName("catchPhrase")]
      public string CatchPhrase { get; set; } = null!;

      [JsonPropertyName("bs")]
      public string Bs { get; set; } = null!;
   }
}
