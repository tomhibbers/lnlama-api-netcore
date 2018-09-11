using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNLamasAPI.Models;
using MongoDB.Driver;

namespace LNLamasAPI.Repository
{
    public class MongoRepository
    {
        protected readonly MongoContext Context;
        internal IMongoCollection<ISeries> CollectionSeries;
        internal IMongoCollection<IChapter> CollectionChapters;
        internal IMongoCollection<IPage> CollectionPages;
        public MongoRepository(MongoContext context)
        {
            Context = context;
            CollectionSeries = Context.Set<ISeries>();
            CollectionChapters = Context.Set<IChapter>();
            CollectionPages = Context.Set<IPage>();
        }
    }
}
