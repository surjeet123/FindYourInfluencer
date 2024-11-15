using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class FeedbackQuestion
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int FeedbackQuestionID { get; set; }

        [BsonElement("question")]
        public string? Question { get; set; }

        [BsonElement("israting")]
        public bool IsRating { get; set; }

        [BsonElement("isyesno")]
        public bool IsYesNo { get; set; }

        [BsonElement("isinput")]
        public bool IsInput { get; set; }

        [BsonElement("isinfluencer")]
        public bool IsInfluencer { get; set; }
    }
}
