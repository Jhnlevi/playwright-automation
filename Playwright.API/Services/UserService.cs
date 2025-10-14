using Microsoft.Playwright;
using Playwright.API.Models.User;
using Playwright.API.Services.Interfaces;
using Playwright.API.Utils;

namespace Playwright.API.Services
{
   internal class UserService : IUserService
   {
      private readonly ApiHelper _apiHelper;

      // Constants
      private const string endpoint = "/users";

      public UserService(ApiHelper apiHelper)
      {
         _apiHelper = apiHelper;
      }

      public async Task<IAPIResponse> CreateUserAsync(UserModel user) => await _apiHelper.CreateAsync(endpoint, user);

      public async Task<IAPIResponse> DeleteUserAsync(int id) => await _apiHelper.DeleteAsync(endpoint, id);

      public async Task<IAPIResponse> GetUserAsync(int id) => await _apiHelper.GetByIdAsync(endpoint, id);

      public async Task<IAPIResponse> GetUsersAsync() => await _apiHelper.GetAsync(endpoint);

      public async Task<IAPIResponse> UpdateUserAsync(UserModel user, int id) => await _apiHelper.UpdateAsync(endpoint, user, id);
   }
}
