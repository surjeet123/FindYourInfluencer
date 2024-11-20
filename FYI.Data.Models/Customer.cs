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
    public class Customer : BaseClass
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

        [BsonElement("loginproviderid")]
        public int LoginProviderID { get; set; }//1 for self registration, 2 for google, 3 for facebook

        [BsonElement("isverified")]
        public bool IsVerified { get; set; }

        [BsonElement("lastlogindate")]
        public DateTime LastLoginDate { get; set; }
    }
}
