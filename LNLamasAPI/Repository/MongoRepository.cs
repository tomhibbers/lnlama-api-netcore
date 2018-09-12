using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LNLamasAPI.Tools;
using LNLamaScrape.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using LNLamasAPI.Models;
using Chapter = LNLamasAPI.Models.Chapter;
using Page = LNLamasAPI.Models.Page;
using Series = LNLamasAPI.Models.Series;

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
        public async Task<ISeries> GetSeriesAsync(string title)
        {
            return Context.SeriesLinq.FirstOrDefault(d => d.Title == title);
        }
        public async Task PutSeriesAsync(List<Series> series)
        {
            var collection = Context.Database.GetCollection<Series>("Series");
            //var models = new WriteModel<Series>[series.Count];
            //for (var i = 0; i < series.Count; i++)
            //{
            //    var item = series[i];
            //    models[i] = new ReplaceOneModel<Series>(
            //            Builders<Series>.Filter.Where(x => x.Title == item.Title),
            //            item
            //        )
            //    { IsUpsert = true };
            //};
            //await collection.BulkWriteAsync(models);
            await collection.BulkWriteAsync(
                series.Select(d => new ReplaceOneModel<Series>(
                    Builders<Series>.Filter.Where(x => x.Title == d.Title), d)));

        }
        public async Task DeleteSeriesAsync(string title)
        {
            var collection = Context.Database.GetCollection<Series>("Series");
            await collection.DeleteOneAsync(
                Builders<Series>.Filter.Where(d => d.Title == title));
        }
        #endregion

        #region Chapters

        public async Task<IEnumerable<IChapter>> GetChaptersAsync()
        {
            return await Context.ChaptersLinq.ToListAsyncSafe();
        }
        public async Task<IChapter> GetChaptersAsync(string chapterRef)
        {
            return Context.ChaptersLinq.FirstOrDefault(d => d.ChapterRef == chapterRef);
        }
        public async Task<IEnumerable<IChapter>> GetChaptersBySeriesAsync(string title)
        {
            return await Context.ChaptersLinq.Where(d => d.ParentRef == title).ToListAsyncSafe();
        }
        public async Task PutChaptersAsync(List<Chapter> chapters)
        {
            if (!Context.Database.ListCollectionNames().ToList().Any(x => x.Contains("Chapters")))
            {
                Context.Database.CreateCollection("Chapters");
            }
            var collection = Context.Database.GetCollection<Chapter>("Chapters");
            var models = new WriteModel<Chapter>[chapters.Count];
            for (var i = 0; i < chapters.Count; i++)
            {
                var item = chapters[i];
                models[i] = new ReplaceOneModel<Chapter>(
                        Builders<Chapter>.Filter.Where(x => x.FirstPageUri == item.FirstPageUri),
                        item
                    )
                { IsUpsert = true };
            };
            await collection.BulkWriteAsync(models);

        }
        public async Task DeleteChapterAsync(string chapterRef)
        {
            var collection = Context.Database.GetCollection<Chapter>("Chapters");
            await collection.DeleteOneAsync(
                Builders<Chapter>.Filter.Where(d => d.ChapterRef == chapterRef));
        }
        #endregion

        #region Pages
        public async Task<IEnumerable<IPage>> GetPagesAsync()
        {
            return await Context.PagesLinq.ToListAsyncSafe();
        }
        public async Task<IPage> GetPagesAsync(string pageRef)
        {
            return Context.PagesLinq.FirstOrDefault(d => d.PageRef == pageRef);
        }
        public async Task<IEnumerable<IPage>> GetPagesByChapterUri(string chapterUri)
        {
            return await Context.PagesLinq.Where(d => d.ParentRef == chapterUri)
                .ToListAsyncSafe();
        }

        public async Task PutPagesAsync(List<Page> pages)
        {
            var collection = Context.Database.GetCollection<Page>("Pages");
            var models = new WriteModel<Page>[pages.Count];
            for (var i = 0; i < pages.Count; i++)
            {
                var item = pages[i];
                models[i] = new ReplaceOneModel<Page>(
                        Builders<Page>.Filter.Where(x => x.PageUri == item.PageUri),
                        item
                    )
                { IsUpsert = true };
            };
            await collection.BulkWriteAsync(models);
        }
        public async Task DeletePageAsync(string pageRef)
        {
            var collection = Context.Database.GetCollection<Page>("Pages");
            await collection.DeleteOneAsync(
                Builders<Page>.Filter.Where(d => d.PageRef == pageRef));
        }
        #endregion
    }
}
