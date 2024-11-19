using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Business.Models
{
    public abstract class BaseModel
    {
        public string? Id { get; set; }
        public bool Active { get; set; }
        public bool Published { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
    }

}
