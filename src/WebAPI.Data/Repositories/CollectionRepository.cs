using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Data.Models;
using WebAPI.Data.Repositories.Interfaces;
using WebAPI.Data.Settings;
using WebAPI.Helpers.Attributes;
using WebAPI.Helpers;

namespace WebAPI.Data.Repositories
{
    public class CollectionRepository<T> : ICollectionRepository<T>
    {
        private IMongoDatabase Database;

        public CollectionRepository(IMongoClient client, IOptions<MongoSettings> settings)
        {
            Database = client.GetDatabase(settings.Value.DatabaseName);
        }

        private string GetCollectionName()
        {
            var attrib = Helpers.Helpers.GetAttribute<CollectionName, T>();
            return attrib.Name;
        }

        public IMongoCollection<T> GetCollection() => Database.GetCollection<T>(GetCollectionName());
    }
}
