using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class ServiceType : BaseClass
    {
        [BsonElement("servicetypename")]
        public string? ServiceTypeName { get; set; }
    }
}
