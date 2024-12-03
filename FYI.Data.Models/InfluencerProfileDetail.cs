using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FYI.Data.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models
{
	 public class InfluencerProfileDetail : BaseClass
    {
        [BsonElement("influencerid")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InfluencerID { get; set; }

		[BsonElement("biodetails")]
		public string? BioDetails { get; set; }

		[BsonElement("headline")]
		public string? HeadLine { get; set; }

		[BsonElement("gender")]
		public string? Gender { get; set; }

	}
}
