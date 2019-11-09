using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Data.Models.Interfaces
{
   public interface IMongoObject
    {
        public ObjectId _id { get; set; }
    }
}
