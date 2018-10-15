using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Models
{
    public class Banner
    {
        [BsonElement("Id")]
        public int Id { get; set; }

        [BsonElement("Html")]
        public string Html { get; set; }

        [BsonElement("Created")]
        public DateTime Created { get; set; }

        [BsonElement("Modified")]
        public DateTime? Modified { get; set; }
    }
}