using Microsoft.Playwright;
using Playwright.API.Models.Post;
using Playwright.API.Services.Interfaces;
using Playwright.API.Utils;

namespace Playwright.API.Services
{
   internal class PostService : IPostService
   {
      private readonly ApiHelper _apiHelper;

      public PostService(ApiHelper apiHelper)
      {
         _apiHelper = apiHelper;
      }

      public async Task<IAPIResponse> CreatePostAsync(PostModel post) => await _apiHelper.PostAsync("/posts", post);

      public async Task<IAPIResponse> DeletePostAsync(int id) => await _apiHelper.DeleteAsync("/posts", id);

      public async Task<IAPIResponse> GetPostAsync(int id) => await _apiHelper.GetByIdAsync("/posts", id);

      public async Task<IAPIResponse> GetPostsAsync() => await _apiHelper.GetAsync("/posts");

      public async Task<IAPIResponse> UpdatePostAsync(PostModel post, int id) => await _apiHelper.UpdateAsync("/posts", post, id);
   }
}
