using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CatalogModel> GetCatalogById(string id)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"/api/v1/Catalog/{id}");
            return await httpResponseMessage.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogs()
        {
            var httpResponseMessage = await _httpClient.GetAsync("/api/v1/Catalog");
            return await httpResponseMessage.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogsByCategory(string category)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"/api/v1/Catalog/GetProductByCategory/{category}");
            return await httpResponseMessage.ReadContentAs<List<CatalogModel>>();
        }
    }
}