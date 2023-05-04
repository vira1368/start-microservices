using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var mongoDatabase = mongoClient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            var mongoCollection = mongoDatabase.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<Product> Products { get; }
    }
}
