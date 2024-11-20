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
    public class CustomerPassword : BaseClass
    {
        [BsonElement("customerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerID { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("passwordsalt")]
        public string? PasswordSalt { get; set; }     
    }
}
