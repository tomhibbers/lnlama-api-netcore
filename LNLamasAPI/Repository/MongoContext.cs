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
        public IMongoQueryable<SeriesDto> SeriesLinq => Database.GetCollection<SeriesDto>("Series").AsQueryable();
        public IMongoCollection<SeriesDto> SeriesItems => Database.GetCollection<SeriesDto>("Series");

        public IMongoQueryable<ChapterDto> ChaptersLinq => Database.GetCollection<ChapterDto>("Chapters").AsQueryable();
        public IMongoCollection<ChapterDto> ChaptersItems => Database.GetCollection<ChapterDto>("Chapters");

        public IMongoQueryable<PageDto> PagesLinq => Database.GetCollection<PageDto>("Pages").AsQueryable();
        public IMongoCollection<PageDto> PagesItems => Database.GetCollection<PageDto>("Pages");
    }

}