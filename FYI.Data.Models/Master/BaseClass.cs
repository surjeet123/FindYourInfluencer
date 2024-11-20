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
        // Constructor to set default values
        public BaseClass()
        {
            Active = true; // Default value for Active
            CreatedOn = DateTime.UtcNow; // Default CreatedOn to current time
            LastUpdated = DateTime.UtcNow; // Default LastUpdated to current time
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }

        [BsonElement("createdon")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("updatedby")]
        public string? UpdatedBy { get; set; }

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
