using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Models.Interfaces;

namespace WebAPI.Data.Models
{
    public class Product : IMongoObject
    {
        public ObjectId _id { get; set; }
        public string ProductName { get; set; }
       
    }
}
