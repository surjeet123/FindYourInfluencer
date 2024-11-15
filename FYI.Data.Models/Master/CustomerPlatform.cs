using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class CustomerPlatform : BaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int CustomerPlatformID { get; set; }

        [BsonElement("customerid")]
        public int CustomerID { get; set; }

        [BsonElement("platformid")]
        public int PlatformID { get; set; }

        [BsonElement("username")]
        public string? UserName { get; set; }

        [BsonElement("platformurl")]
        public string? PlatformURL { get; set; }
    }
}
