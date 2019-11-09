using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Models;
using WebAPI.Data.QueryClasses.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using WebAPI.Data.Settings;
using System.Linq;
using MongoDB.Bson;

namespace WebAPI.Data.QueryClasses
{
    public class ProductQueries : IProductQueries
    {
        const string CollectionName = "Products";
        private IMongoClient Client { get; }

        private IMongoDatabase Database;

        private IMongoCollection<Product> ProductCollection;


        public ProductQueries(IMongoClient client, IOptions<MongoSettings> settings)
        {
            Client = client;
            Database = client.GetDatabase(settings.Value.DatabaseName);
            ProductCollection = Database.GetCollection<Product>(CollectionName);
        }

        public IEnumerable<Product> GetAll() => ProductCollection.AsQueryable();

        public Product GetByName(string name) => GetAll().FirstOrDefault(x => x.ProductName == name);

        public Product GetById(ObjectId id) => GetAll().FirstOrDefault(x => x._id == id);
    }
}
