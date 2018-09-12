using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamaScrape.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace LNLamasAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Series : LNLamaScrape.Models.Series
    {
        public Series(RepositoryBase parent, Uri seriesPageUri, string title) : base(parent, seriesPageUri, title)
        {
        }
    }
}
