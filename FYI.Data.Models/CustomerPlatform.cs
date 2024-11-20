using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FYI.Data.Models.Master;

namespace FYI.Data.Models
{
    public class CustomerPlatform : BaseClass
    {
        [BsonElement("customerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerID { get; set; }

        [BsonElement("platformid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public int PlatformID { get; set; }

        [BsonElement("username")]
        public string? UserName { get; set; }

        [BsonElement("platformurl")]
        public string? PlatformURL { get; set; }
    }
}
