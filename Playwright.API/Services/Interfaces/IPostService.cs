using Microsoft.Playwright;
using Playwright.API.Models.Post;

namespace Playwright.API.Services.Interfaces
{
   internal interface IPostService
   {
      Task<IAPIResponse> GetPostsAsync();
      Task<IAPIResponse> GetPostAsync(int id);
      Task<IAPIResponse> CreatePostAsync(PostModel post);
      Task<IAPIResponse> UpdatePostAsync(PostModel post, int id);
      Task<IAPIResponse> DeletePostAsync(int id);
   }
}
