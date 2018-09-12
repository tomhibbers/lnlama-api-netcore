using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace LNLamasAPI.Models
{
    //[BsonIgnoreExtraElements]
    //public class Series
    //{
    //    public string Title { get; private set; }
    //    public string Description { get; internal set; }
    //    public string[] TitlesAlternative { get; internal set; }
    //    [BsonIgnore]
    //    public Uri SeriesPageUri { get; internal set; }
    //    public Uri CoverImageUri { get; internal set; }
    //    public string Author { get; internal set; }
    //    public string Updated { get; internal set; }
    //    public string[] Tags { get; internal set; }
    //    public string[] Genres { get; internal set; }
    //    public Series(Uri seriesPageUri, string title)
    //    {
    //        SeriesPageUri = seriesPageUri;
    //        Title = title;
    //        Updated = string.Empty;
    //    }
    //}
    [BsonIgnoreExtraElements]
    public class Series : LNLamaScrape.Models.Series
    {
        [BsonIgnore]
        public Uri SeriesPageUri { get; internal set; }
        public Series(RepositoryBase parent, Uri seriesPageUri, string title) : base(parent, seriesPageUri, title)
        {
        }
    }
}
