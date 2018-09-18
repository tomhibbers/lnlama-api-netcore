using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LNLamasAPI.Models
{
    [BsonIgnoreExtraElements]
    public class SeriesDto : LNLamaScrape.Models.Series
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonIgnore]
        public List<ChapterDto> Chapters { get; set; }

        public SeriesDto()
        {
            _id = ObjectId.GenerateNewId().ToString();
        }
        public SeriesDto(RepositoryBase parent, Uri seriesPageUri, string title) : base(parent, seriesPageUri, title)
        {
        }
    }
}
