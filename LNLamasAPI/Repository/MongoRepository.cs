using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LNLamasAPI.Models;
using LNLamasAPI.Tools;
using LNLamaScrape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LNLamasAPI.Repository
{
    public class MongoRepository : IMongoRepository
    {
        public readonly MongoContext Context = null;
        public MongoRepository(IOptions<LNLamasAPI.Models.Settings> settings)
        {
            Context = new MongoContext(settings);
        }
        #region Series
        public async Task<IEnumerable<ISeries>> GetSeriesAsync()
        {
            return await Context.SeriesLinq.ToListAsyncSafe();
        }
        public async Task<ISeries> GetSeriesAsync(string id)
        {
            return Context.SeriesLinq.FirstOrDefault(d => d._id == id);
        }
        public async Task PutSeriesAsync(List<SeriesDto> series)
        {
            if (!Context.Database.ListCollectionNames().ToList().Any(x => x.Contains("Series")))
            {
                Context.Database.CreateCollection("Series");
            }
            var collection = Context.Database.GetCollection<SeriesDto>("Series");
            var models = new WriteModel<SeriesDto>[series.Count];
            for (var i = 0; i < series.Count; i++)
            {
                var item = series[i];
                models[i] = new ReplaceOneModel<SeriesDto>(
                        Builders<SeriesDto>.Filter.Where(x => x._id == item._id),
                        (SeriesDto)item
                    )
                    { IsUpsert = true };
            };
            await collection.BulkWriteAsync(models);

        }
        public async Task DeleteSeriesAsync(string id)
        {
            var collection = Context.Database.GetCollection<SeriesDto>("Series");
            await collection.DeleteOneAsync(
                Builders<SeriesDto>.Filter.Where(d => d._id == id));
        }
        #endregion

        #region Chapters

        public async Task<IEnumerable<IChapter>> GetChaptersAsync()
        {
            return await Context.ChaptersLinq.ToListAsyncSafe();
        }
        public async Task<IChapter> GetChaptersAsync(string id)
        {
            return Context.ChaptersLinq.FirstOrDefault(d => d._id == id);
        }
        public async Task<IEnumerable<IChapter>> GetChaptersBySeriesAsync(string id)
        {
            return await Context.ChaptersLinq.Where(d => d.ParentRef == id).ToListAsyncSafe();
        }
        public async Task PutChaptersAsync(List<ChapterDto> chapters)
        {
            if (!Context.Database.ListCollectionNames().ToList().Any(x => x.Contains("Chapters")))
            {
                Context.Database.CreateCollection("Chapters");
            }
            var collection = Context.Database.GetCollection<ChapterDto>("Chapters");
            var models = new WriteModel<ChapterDto>[chapters.Count];
            for (var i = 0; i < chapters.Count; i++)
            {
                var item = chapters[i];
                models[i] = new ReplaceOneModel<ChapterDto>(
                        Builders<ChapterDto>.Filter.Where(x => x._id == item._id),
                        (ChapterDto)item
                    )
                { IsUpsert = true };
            };
            await collection.BulkWriteAsync(models);

        }
        public async Task DeleteChapterAsync(string id)
        {
            var collection = Context.Database.GetCollection<ChapterDto>("Chapters");
            await collection.DeleteOneAsync(
                Builders<ChapterDto>.Filter.Where(d => d._id == id));
        }
        #endregion

        #region Pages
        public async Task<IEnumerable<IPage>> GetPagesAsync()
        {
            return await Context.PagesLinq.ToListAsyncSafe();
        }
        public async Task<IPage> GetPagesAsync(string id)
        {
            return Context.PagesLinq.FirstOrDefault(d => d._id == id);
        }
        public async Task<IEnumerable<IPage>> GetPagesByChapter(string id)
        {
            return await Context.PagesLinq.Where(d => d.ParentRef == id)
                .ToListAsyncSafe();
        }

        public async Task PutPagesAsync(List<PageDto> pages)
        {
            var collection = Context.Database.GetCollection<PageDto>("Pages");
            var models = new WriteModel<PageDto>[pages.Count];
            for (var i = 0; i < pages.Count; i++)
            {
                var item = pages[i];
                models[i] = new ReplaceOneModel<PageDto>(
                        Builders<PageDto>.Filter.Where(x => x._id == item._id),
                        (PageDto)item
                    )
                { IsUpsert = true };
            };
            await collection.BulkWriteAsync(models);
        }
        public async Task DeletePageAsync(string id)
        {
            var collection = Context.Database.GetCollection<PageDto>("Pages");
            await collection.DeleteOneAsync(
                Builders<PageDto>.Filter.Where(d => d._id == id));
        }
        #endregion
    }
}
