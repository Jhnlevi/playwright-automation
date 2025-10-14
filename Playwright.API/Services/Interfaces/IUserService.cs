using Microsoft.Playwright;
using Playwright.API.Models.User;

namespace Playwright.API.Services.Interfaces
{
   internal interface IUserService
   {
      Task<IAPIResponse> GetUsersAsync();
      Task<IAPIResponse> GetUserAsync(int id);
      Task<IAPIResponse> CreateUserAsync(UserModel user);
      Task<IAPIResponse> UpdateUserAsync(UserModel user, int id);
      Task<IAPIResponse> DeleteUserAsync(int id);
   }
}
