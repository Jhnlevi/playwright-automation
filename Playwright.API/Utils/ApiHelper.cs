using Microsoft.Playwright;

namespace Playwright.API.Utils
{
    internal class ApiHelper
    {
        private readonly IAPIRequestContext _context;

        public ApiHelper(IAPIRequestContext context) => _context = context;

        // Endpoints
        public async Task<IAPIResponse> GetAsync(string endpoint) => await _context.GetAsync(endpoint);

        public async Task<IAPIResponse> GetByIdAsync(string endpoint, int id) => await _context.GetAsync($"{endpoint}/{id}");

        public async Task<IAPIResponse> PostAsync(string endpoint, object data) => await _context.PostAsync(endpoint, new APIRequestContextOptions { DataObject = data });

        public async Task<IAPIResponse> DeleteAsync(string endpoint, int id) => await _context.DeleteAsync($"{endpoint}/{id}");
    }
}
