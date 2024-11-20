using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class MarketingService : BaseClass
    {
        [BsonElement("servicename")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ServiceName { get; set; }

        [BsonElement("platformid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public int PlatformID { get; set; }

        [BsonElement("servicetypeid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public int ServiceTypeID { get; set; }
    }
}
