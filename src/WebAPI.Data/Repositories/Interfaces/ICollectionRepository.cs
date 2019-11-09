using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Repositories.Interfaces
{
    public interface ICollectionRepository
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
