using System.Text.Json.Serialization;

namespace Playwright.API.Models.Post
{
   internal class PostModel
   {
      [JsonPropertyName("postId")]
      public int? PostId { get; set; }

      [JsonPropertyName("userId")]
      public int? UserId { get; set; }

      [JsonPropertyName("id")]
      public int Id { get; set; }

      [JsonPropertyName("name")]
      public string? Name { get; set; }

      [JsonPropertyName("email")]
      public string? Email { get; set; }

      [JsonPropertyName("title")]
      public string Title { get; set; } = null!;

      [JsonPropertyName("body")]
      public string Body { get; set; } = null!;
   }
}
