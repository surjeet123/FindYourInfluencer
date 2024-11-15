using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class OrderStatus : BaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int OrderStatusID { get; set; }

        [BsonElement("statusname")]
        public string? StatusName { get; set; }
    }
}
