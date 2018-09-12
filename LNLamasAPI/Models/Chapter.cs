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
        public Chapter(LNLamaScrape.Models.Series parent, Uri firstPageUri, string title) : base(parent, firstPageUri, title)
        {
        }
    }
}
