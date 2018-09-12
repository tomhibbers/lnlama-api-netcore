using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using LNLamaScrape.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using Microsoft.Extensions.Options;
using LNLamasAPI.Models;
namespace LNLamasAPI.Repository
{
    public class MongoContext
    {
        internal IMongoDatabase Database { get; private set; }

        public MongoContext(IOptions<LNLamasAPI.Models.Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            Database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoQueryable<LNLamasAPI.Models.Series> SeriesLinq => Database.GetCollection<LNLamasAPI.Models.Series>("Series").AsQueryable<LNLamasAPI.Models.Series>();
        public IMongoCollection<LNLamasAPI.Models.Series> SeriesItems => Database.GetCollection<LNLamasAPI.Models.Series>("Series");

        public IMongoQueryable<LNLamasAPI.Models.Chapter> ChaptersLinq => Database.GetCollection<LNLamasAPI.Models.Chapter>("Chapters").AsQueryable<LNLamasAPI.Models.Chapter>();
        public IMongoCollection<LNLamasAPI.Models.Chapter> ChaptersItems => Database.GetCollection<LNLamasAPI.Models.Chapter>("Chapters");

        public IMongoQueryable<LNLamasAPI.Models.Page> PagesLinq => Database.GetCollection<LNLamasAPI.Models.Page>("Pages").AsQueryable<LNLamasAPI.Models.Page>();
        public IMongoCollection<LNLamasAPI.Models.Page> PagesItems => Database.GetCollection<LNLamasAPI.Models.Page>("Pages");
    }

}