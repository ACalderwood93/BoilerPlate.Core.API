using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Models;

namespace WebAPI.Data.QueryClasses.Interfaces
{
    public interface IProductQueries
    {
        IEnumerable<Product> GetAll();

        Product GetByName(string name);

        Product GetById(ObjectId id);
    }
}
