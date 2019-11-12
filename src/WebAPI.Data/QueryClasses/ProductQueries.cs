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
using WebAPI.Data.Repositories.Interfaces;

namespace WebAPI.Data.QueryClasses
{
    public class ProductQueries : IProductQueries
    {
        private IMongoCollection<Product> Collection;

        public ProductQueries(ICollectionRepository<Product> collectionRepo)
        {
            Collection = collectionRepo.GetCollection();
        }

        public IEnumerable<Product> GetAll() => Collection.AsQueryable();

        public Product GetByName(string name) => GetAll().FirstOrDefault(x => x.ProductName == name);

        public Product GetById(ObjectId id) => GetAll().FirstOrDefault(x => x._id == id);
        public Product GetById(string id) => GetById(ObjectId.Parse(id));
    }
}
