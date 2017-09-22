using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.DataModel
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Username { get; set; }
    }
}
