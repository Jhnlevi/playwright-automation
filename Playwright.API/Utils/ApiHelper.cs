using Microsoft.Playwright;
using Playwright.API.Models;

namespace Playwright.API.Utils
{
   internal class ApiHelper
   {
      private IAPIRequestContext _context;

      public ApiHelper(IAPIRequestContext context) => _context = context;

      // Initialize API context
      public async Task InitializeAsync(AppSettings config, string environment)
      {
         var envSettings = config.Environments[environment];

         var headers = new Dictionary<string, string>();

         if (!string.IsNullOrEmpty(envSettings.DefaultHeaders.Accept))
            headers.Add("Accept", envSettings.DefaultHeaders.Accept);

         if (!string.IsNullOrEmpty(envSettings.DefaultHeaders.ContentType))
            headers.Add("Content-Type", envSettings.DefaultHeaders.ContentType);

         var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

         _context = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
         {
            BaseURL = envSettings.BaseUrl,
            ExtraHTTPHeaders = headers
         });
      }

      // Dispose API context
      public async Task DisposeAsync()
      {
         if (_context != null)
            await _context.DisposeAsync();
      }

      // Endpoint helpers
      public async Task<IAPIResponse> GetAsync(string endpoint) => await _context.GetAsync(endpoint);

      public async Task<IAPIResponse> GetByIdAsync(string endpoint, int id) => await _context.GetAsync($"{endpoint}/{id}");

      public async Task<IAPIResponse> CreateAsync(string endpoint, object data) => await _context.PostAsync(endpoint, new APIRequestContextOptions { DataObject = data });

      public async Task<IAPIResponse> UpdateAsync(string endpoint, object data, int id) => await _context.PutAsync($"{endpoint}/{id}", new APIRequestContextOptions { DataObject = data });

      public async Task<IAPIResponse> DeleteAsync(string endpoint, int id) => await _context.DeleteAsync($"{endpoint}/{id}");
   }
}
