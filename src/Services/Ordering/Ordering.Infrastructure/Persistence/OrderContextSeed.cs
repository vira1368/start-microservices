using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(OrderContext).Name}");
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders() => new List<Order>
            {
                new Order
                {
                    Username = "vira",
                    FirstName = "Amin",
                    LastName = "Saffarnejad",
                    EmailAddress = "vira1368@gmail.com",
                    AddressLine = "Tehran",
                    Country = "Iran",
                    TotalPrice = 350
                }
            };
    }
}