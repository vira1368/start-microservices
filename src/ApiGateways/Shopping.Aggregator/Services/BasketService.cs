using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<BasketModel> GetBasketByUsername(string username)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"/api/v1/Basket/{username}");
            return await httpResponseMessage.ReadContentAs<BasketModel>();
        }
    }
}