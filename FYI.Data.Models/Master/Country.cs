using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class Country : BaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int CountryID { get; set; }

        [BsonElement("countryname")]
        public string? CountryName { get; set; }
    }
}
