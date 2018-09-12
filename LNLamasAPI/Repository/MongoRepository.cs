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
        public async Task<IEnumerable<ISeries>> GetSeriesAsync()
        {
            return await Context.SeriesLinq.ToListAsyncSafe();
        }
        public async Task<IEnumerable<IChapter>> GetChaptersAsync()
        {
            return await Context.ChaptersLinq.ToListAsyncSafe();
        }
        public async Task<IEnumerable<IChapter>> GetChaptersBySeriesTitleAsync(string title)
        {
            //var q = from s in Context.SeriesItems.AsQueryable()
            //        join c in Context.ChaptersItems.AsQueryable()
            //            on s.Title equals c.ParentSeriesTitle
            //        select new
            //        {
            //            s = s,
            //            c = c
            //        };
            return await Context.ChaptersLinq.Where(d => d.ParentRef == title)
                .ToListAsyncSafe();
        }
        public async Task<IEnumerable<IPage>> GetPagesAsync()
        {
            return await Context.PagesLinq.ToListAsyncSafe();
        }

        public async Task<IEnumerable<IPage>> GetPagesByChapterUri(string chapterUri)
        {
            return await Context.PagesLinq.Where(d => d.ParentRef == chapterUri)
                .ToListAsyncSafe();
        }



        public async Task PutSeriesAsync(List<Series> series)
        {
            //var seriesDocuments = series.OrderBy(d => d.Title).Select(d => new BsonDocument()
            //{
            //    {"title", new BsonString(d.Title) },
            //    {"seriesPageUri", new BsonString(d.SeriesPageUri.AbsoluteUri) },
            //});



            //var options = new UpdateOptions { IsUpsert = true };
            //var filters = Builders<Series>.Filter.Where(x => x.Title == d.Title);
            //var a = await collection.UpdateManyAsync(filter, update, options);
            //var bw = await collection.BulkWriteAsync(
            //    series.Select(d => new UpdateOneModel<Series>(
            //            //x=>x.
            //            Builders<Series>.Filter.Where(x => x.Title == d.Title),
            //            Builders<Series>.Update.Set("", d)
            //            )
            //    { IsUpsert = true }
            //));




            //// create collection if doesn't exist
            //if (!mongoContext.Database.ListCollectionNames().ToList().Any(x => x.Contains("Series")))
            //{
            //    mongoContext.Database.CreateCollection("Series");
            //}

            //var collection = mongoContext.Database.GetCollection<BsonDocument>("Series");
            //// initialise write model to hold list of our upsert tasks
            //var models = new WriteModel<BsonDocument>[series.Count];

            //// use ReplaceOneModel with property IsUpsert set to true to upsert whole documents
            //for (var i = 0; i < series.Count; i++)
            //{
            //    var bsonDoc = series[i].ToBsonDocument();
            //    models[i] = new ReplaceOneModel<BsonDocument>(new BsonDocument("Title", series[i].Title), bsonDoc) { IsUpsert = true };
            //};

            //await collection.BulkWriteAsync(models);

            var collection = Context.Database.GetCollection<Series>("Series");
            var models = new WriteModel<Series>[series.Count];
            for (var i = 0; i < series.Count; i++)
            {
                var item = series[i];
                models[i] = new ReplaceOneModel<Series>(
                    Builders<Series>.Filter.Where(x => x.Title == item.Title),
                    item
                    )
                { IsUpsert = true };
            };
            await collection.BulkWriteAsync(models);
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
        //public async Task UpdateDbPagesWithContentAsync(IReadOnlyList<IPage> pages)
        //{
        //    // download content for pages
        //    var taskList = new List<Task>();
        //    foreach (var i in pages)
        //    {
        //        taskList.Add(DownloadPageContent((Page)i));
        //        taskList.Add(i.GetPageContentAsync());
        //    }
        //    Task.WaitAll(taskList.ToArray());
        //    await PutPagesAsync(pages);
        //}

        //internal async Task DownloadPageContent(Page page)
        //{
        //    var res = await page.GetPageContentAsync();
        //    page.PageContent = Encoding.UTF8.GetString(res);
        //}
    }
}
