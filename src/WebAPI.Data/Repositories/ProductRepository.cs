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

        private IMongoCollection<Product> Collection;


        public ProductRepository(ICollectionRepository collectionRepo)
        {
            Collection = collectionRepo.GetCollection<Product>(CollectionName);
        }

        public async Task<Product> Create(Product product)
        {
            await Collection.InsertOneAsync(product);
            return product;
        }

        public async Task Update(Product product)
        {
            await Collection.ReplaceOneAsync(x => x._id == product._id, product);
        }
    }
}
