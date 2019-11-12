using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;
using WebAPI.Data.Repositories.Interfaces;
using System.Linq;
using WebAPI.Data.QueryClasses.Interfaces;

namespace WebAPI.Data.QueryClasses
{
    public class UserQueries : IUserQueries
    {
        private readonly IMongoCollection<User> _collection;
        public UserQueries(ICollectionRepository<User> repo)
        {
            _collection = repo.GetCollection();
        }




        public User GetUser(string username) => _collection.AsQueryable().FirstOrDefault(x => x.Username == username);


    }
}
