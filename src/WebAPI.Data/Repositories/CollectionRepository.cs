using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Repositories.Interfaces;
using WebAPI.Data.Settings;

namespace WebAPI.Data.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {

        private IMongoDatabase Database;


        public CollectionRepository(IMongoClient client, IOptions<MongoSettings> settings)
        {
            Database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) => Database.GetCollection<T>(collectionName);



    }
}
