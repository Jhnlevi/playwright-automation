using Playwright.API.Models.Post;
using Playwright.API.Utils;

namespace Playwright.API.Tests.Post
{
   internal class PostTests : BaseTest
   {
      private readonly ReportManager.LogLevel _info = ReportManager.LogLevel.Info;

      [Test, Order(2)]
      public async Task Post_GetAllPosts_ShouldSucceed()
      {
         ReportManager.Log(_info, "Retrieving all posts");

         var response = await _postService.GetPostsAsync();
         var body = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that all posts are retrieved");
         ReportManager.Log(_info, $"<pre>{body}</pre>");

         Assert.That(response.Status, Is.EqualTo(200));
      }

      [Test, Order(3)]
      public async Task Post_GetSinglePost_ShouldSucceed()
      {
         ReportManager.Log(_info, "Retrieving single post");

         var response = await _postService.GetPostAsync(5);
         var body = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that a single post is retrieved");
         ReportManager.Log(_info, $"<pre>{body}</pre>");

         Assert.That(response.Status, Is.EqualTo(200));
      }

      [Test, Order(1)]
      public async Task Post_CreatePost_ShouldSucceed()
      {
         ReportManager.Log(_info, "Retrieving single post");

         var sendBody = new PostModel
         {
            UserId = 5,
            Title = "My own secret title",
            Body = "My own secret body"
         };

         var response = await _postService.CreatePostAsync(sendBody);
         var responseBody = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that a post is created");
         ReportManager.Log(_info, $"<pre>{responseBody}</pre>");

         Assert.That(response.Status, Is.EqualTo(201));
      }

      [Test, Order(4)]
      public async Task Post_UpdatePost_ShouldSucceed()
      {
         ReportManager.Log(_info, "Retrieving single post");

         var sendBody = new PostModel
         {
            UserId = 5,
            Title = "New own secret title",
            Body = "New own secret body"
         };

         var response = await _postService.UpdatePostAsync(sendBody, 2);
         var responseBody = await response.TextAsync();

         ReportManager.Log(_info, "Verifying that a post is updated");
         ReportManager.Log(_info, $"<pre>{responseBody}</pre>");

         Assert.That(response.Status, Is.EqualTo(200));
      }

      [Test, Order(5)]
      public async Task Post_DeletePost_ShouldSucceed()
      {
         ReportManager.Log(_info, "Deleting single post");

         var response = await _postService.DeletePostAsync(2);

         ReportManager.Log(_info, "Verifying that a post is deleted/removed.");
         ReportManager.Log(_info, "JsonPlaceholder doesn't actually delete anything, so for the mean time, I am going to use 200 instead of 204.");

         Assert.That(response.Status, Is.EqualTo(200));
      }
   }
}
