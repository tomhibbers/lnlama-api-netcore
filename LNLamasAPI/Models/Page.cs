using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace LNLamasAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Page : LNLamaScrape.Models.Page
    {
        public Page(LNLamaScrape.Models.Chapter parent, Uri pageUri, int pageNo) : base(parent, pageUri, pageNo)
        {
        }
    }
}
