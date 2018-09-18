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
    public class ChapterDto : LNLamaScrape.Models.Chapter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        [BsonIgnore]
        public List<PageDto> Pages { get; set; }

        public ChapterDto()
        {
            _id = ObjectId.GenerateNewId().ToString();
        }
        public ChapterDto(LNLamaScrape.Models.Series parent, Uri firstPageUri, string title) : base(parent, firstPageUri, title)
        {
        }
    }
}
