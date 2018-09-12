using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace LNLamasAPI.Models
{
    //[BsonIgnoreExtraElements]
    public class Page : LNLamaScrape.Models.Page
    {
        [BsonIgnore]
        public Chapter ParentChapterInternal { get; private set; }
        [BsonIgnore]
        public IChapter ParentChapter => ParentChapterInternal;
        //[BsonRequired]
        //public string ParentRef { get; set; }
        //public string PageRef { get; set; }
        //public Uri PageUri { get; private set; }
        //public int PageNo { get; private set; }
        //public Uri ImageUri { get; internal set; }
        //public string PageContent { get; internal set; }

        //public Page(Chapter parent, Uri pageUri, int pageNo)
        //{
        //    ParentChapterInternal = parent;
        //    if (ParentChapterInternal != null)
        //        ParentRef = ParentChapterInternal?.ChapterRef;
        //    PageUri = pageUri;
        //    PageNo = pageNo;
        //    if (PageNo != 1)
        //        PageRef = string.Join('-', ParentRef, PageUri.Segments.Last());
        //    PageRef = ParentRef;
        //}
        public Page(LNLamaScrape.Models.Chapter parent, Uri pageUri, int pageNo) : base(parent, pageUri, pageNo)
        {
        }
    }
}
