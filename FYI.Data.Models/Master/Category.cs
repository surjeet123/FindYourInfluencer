using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class Category : BaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int CategoryID { get; set; }

        [BsonElement("categoryname")]
        public string? CategoryName { get; set; }
    }
}
