using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using WebAPI.Data.Models.Interfaces;
using WebAPI.Helpers.Attributes;

namespace WebAPI.Data.Models
{
    [CollectionName("Users")]
    public class User : IMongoObject
    {
        public ObjectId _id { get; set; }

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime LastLoginTime { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public string  Token { get; set; }
    }
}
