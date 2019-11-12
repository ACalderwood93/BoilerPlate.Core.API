using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Models.Interfaces;
using WebAPI.Helpers.Attributes;


namespace WebAPI.Data.Models
{
    [CollectionName("Products")]
    public class Product : IMongoObject
    {
        public ObjectId _id { get; set; }
        public string ProductName { get; set; }
       
    }
}
