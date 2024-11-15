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
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int CustomerPasswordID { get; set; }

        [BsonElement("customerid")]
        public int CustomerID { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("passwordsalt")]
        public string? PasswordSalt { get; set; }

        [BsonElement("createdon")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("loginproviderid")]
        public bool LoginProviderID { get; set; }

        [BsonElement("isverified")]
        public bool IsVerified { get; set; }

        [BsonElement("lastlogindate")]
        public DateTime LastLoginDate { get; set; }
    }
}
