using FYI.Data.Models.Master;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models
{
    public class CustomerVerificationCode : BaseClass
    {
        [BsonElement("customerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerID { get; set; }

        [BsonElement("verificationcode")]
        public string VerificationCode { get; set; }

        [BsonElement("salt")]
        public string Salt { get; set; }
        [BsonElement("isused")]
        public string IsUsed { get; set; }

    }
}
