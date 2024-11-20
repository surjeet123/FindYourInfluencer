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
    public class CustomerBioDetail : BaseClass
    {
        [BsonElement("customerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerID { get; set; }

        [BsonElement("firstname")]
        public string? FirstName { get; set; }

        [BsonElement("lastname")]
        public string? LastName { get; set; }

        [BsonElement("emailaddress")]
        public string? EmailAddress { get; set; }

        [BsonElement("mobile")]
        public string? MobileNo { get; set; }

        [BsonElement("cityid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CityID { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        [BsonElement("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("biodetails")]
        public string? BioDetails { get; set; }

        [BsonElement("profileimageurl")]
        public string? ProfileImageURL { get; set; }

        [BsonElement("isbrand")]
        public bool IsBrand { get; set; }

        [BsonElement("brandname")]
        public string? BrandName { get; set; }
    }
}
