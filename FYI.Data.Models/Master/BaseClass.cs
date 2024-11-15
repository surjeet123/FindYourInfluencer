using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public abstract class BaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("published")]
        public bool Published { get; set; }

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
