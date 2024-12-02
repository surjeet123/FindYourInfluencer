using FYI.Data.Models.Master;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models
{
    public class Influencer : BaseClass
    {
        [BsonElement("firstname")]
        public string? FirstName { get; set; }

        [BsonElement("lastname")]
        public string? LastName { get; set; }

        [BsonElement("emailaddress")]
        public string? EmailAddress { get; set; }

        [BsonElement("mobileno")]
        public string? MobileNo { get; set; }

        [BsonElement("isemailverified")]
        public bool IsEmailVerified { get; set; }

        [BsonElement("ismobileverified")]
        public bool IsMobileVerified { get; set; }

        [BsonElement("isprofileverified")]
        public bool IsProfileVerified { get; set; }

	}
}
