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
    public class InfluencerPassword : BaseClass
    {
        [BsonElement("influencerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InfluencerID { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("passwordsalt")]
        public string? PasswordSalt { get; set; }
    }

    public class InfluencerVerificationCode : BaseClass
    {
        [BsonElement("influencerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InfluencerID { get; set; }

        [BsonElement("verificationcode")]
        public string VerificationCode { get; set; }

        [BsonElement("salt")]
        public string Salt { get; set; }

        [BsonElement("isused")]
        public string IsUsed { get; set; }

    }
}
