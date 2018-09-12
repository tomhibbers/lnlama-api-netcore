using LNLamasAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LNLamasAPI.Repository
{
    public class MongoContext
    {
        internal IMongoDatabase Database { get; private set; }

        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            Database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoQueryable<Series> SeriesLinq => Database.GetCollection<Series>("Series").AsQueryable();
        public IMongoCollection<Series> SeriesItems => Database.GetCollection<Series>("Series");

        public IMongoQueryable<Chapter> ChaptersLinq => Database.GetCollection<Chapter>("Chapters").AsQueryable();
        public IMongoCollection<Chapter> ChaptersItems => Database.GetCollection<Chapter>("Chapters");

        public IMongoQueryable<Page> PagesLinq => Database.GetCollection<Page>("Pages").AsQueryable();
        public IMongoCollection<Page> PagesItems => Database.GetCollection<Page>("Pages");
    }

}