using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ZeroDefects.Domain.Entities
{
    public class Instructions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }
        public bool Isactive { get; set; }
        public string CreatedDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Image { get; set; }


    }
}