using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LNLamasAPI.Models
{
    [BsonIgnoreExtraElements]
    public class PageDto : LNLamaScrape.Models.Page
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public PageDto()
        {
            _id = ObjectId.GenerateNewId().ToString();
        }
        public PageDto(LNLamaScrape.Models.Chapter parent, Uri pageUri, int pageNo) : base(parent, pageUri, pageNo)
        {
        }
    }
}
