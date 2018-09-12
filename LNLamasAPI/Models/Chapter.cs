using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace LNLamasAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Chapter : LNLamaScrape.Models.Chapter
    {
        [BsonIgnore]
        public Series ParentSeriesInternal { get; private set; }
        [BsonIgnore]
        public ISeries ParentSeries => ParentSeriesInternal;
        //[BsonRequired]
        //public string ParentRef { get; set; }

        //public Uri FirstPageUri { get; private set; }
        //public string ChapterRef { get; set; }
        //public string Title { get; private set; }
        //public string Updated { get; private set; }

        //public Chapter(Series parent, Uri firstPageUri, string title)
        //{
        //    ParentSeriesInternal = parent;
        //    if (ParentSeriesInternal != null)
        //        ParentRef = ParentSeries?.Title;
        //    FirstPageUri = firstPageUri;
        //    ChapterRef = string.Join('-', ParentRef, FirstPageUri.Segments.Last());
        //    Title = title;
        //    Updated = string.Empty;
        //}

        public Chapter(LNLamaScrape.Models.Series parent, Uri firstPageUri, string title) : base(parent, firstPageUri, title)
        {
        }
    }
}
