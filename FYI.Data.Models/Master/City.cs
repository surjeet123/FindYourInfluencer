﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYI.Data.Models.Master
{
    public class City : BaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int CityID { get; set; }

        [BsonElement("cityname")]
        public string? CityName { get; set; }
    }
}