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
        [BsonElement("customername")]
        public string? CustomerName { get; set; }

        [BsonElement("cityid")]
        public int CityID { get; set; }

        [BsonElement("emailaddress")]
        public string? EmailAddress { get; set; }

        [BsonElement("mobileno")]
        public string? MobileNo { get; set; }

        [BsonElement("isemailverified")]
        public bool IsEmailVerified { get; set; }

        [BsonElement("ismobileverified")]
        public bool IsMobileVerified { get; set; }

        [BsonElement("createdon")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        [BsonElement("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("biodetails")]
        public string? BioDetails { get; set; }

        [BsonElement("isbrand")]
        public bool IsBrand { get; set; }

        [BsonElement("profileimageurl")]
        public string? ProfileImageURL { get; set; }
    }
}
