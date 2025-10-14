using Microsoft.Playwright;
using Playwright.API.Models.Post;
using Playwright.API.Services.Interfaces;
using Playwright.API.Utils;

namespace Playwright.API.Services
{
   internal class PostService : IPostService
   {
      private readonly ApiHelper _apiHelper;

      // Constants
      private const string endpoint = "/posts";

      public PostService(ApiHelper apiHelper)
      {
         _apiHelper = apiHelper;
      }

      public async Task<IAPIResponse> CreatePostAsync(PostModel post) => await _apiHelper.CreateAsync(endpoint, post);

      public async Task<IAPIResponse> DeletePostAsync(int id) => await _apiHelper.DeleteAsync(endpoint, id);

      public async Task<IAPIResponse> GetPostAsync(int id) => await _apiHelper.GetByIdAsync(endpoint, id);

      public async Task<IAPIResponse> GetPostsAsync() => await _apiHelper.GetAsync(endpoint);

      public async Task<IAPIResponse> UpdatePostAsync(PostModel post, int id) => await _apiHelper.UpdateAsync(endpoint, post, id);
   }
}
