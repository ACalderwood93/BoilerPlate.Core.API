using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;
using WebAPI.Data.QueryClasses;
using WebAPI.Data.Repositories.Interfaces;
using WebAPI.Data.Settings;

namespace WebAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        const string CollectionName = "Products";
        private IMongoClient Client { get; }

        private IMongoDatabase Database;

        private IMongoCollection<Product> ProductCollection;


        public ProductRepository(IMongoClient client, IOptions<MongoSettings> settings)
        {
            Client = client;
            Database = client.GetDatabase(settings.Value.DatabaseName);
            ProductCollection = Database.GetCollection<Product>(CollectionName);
        }

        public async Task<Product> Create(Product product)
        {
            await ProductCollection.InsertOneAsync(product);
            return product;
        }

        public async Task Update(Product product)
        {
            await ProductCollection.ReplaceOneAsync(x => x._id == product._id, product);
        }
    }
}
