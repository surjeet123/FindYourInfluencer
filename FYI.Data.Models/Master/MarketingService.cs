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
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int MarketingServiceID { get; set; }

        [BsonElement("servicename")]
        public string? ServiceName { get; set; }

        [BsonElement("platformid")]
        public int PlatformID { get; set; }

        [BsonElement("servicetypeid")]
        public int ServiceTypeID { get; set; }
    }
}
