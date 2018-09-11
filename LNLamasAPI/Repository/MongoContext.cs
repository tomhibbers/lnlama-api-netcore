using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace LNLamasAPI.Repository
{
    public class MongoContext
    {
        public readonly Hashtable _hashRepository;
        public IMongoDatabase Database { get; }
        internal string DatabaseName { get; }
        internal string ConnectionString { get; }

        public MongoContext()
        {
            ConnectionString = "mongodb://localhost:27017";
            DatabaseName = "LNLamaScrape";
            bool isSsl = false;

            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (isSsl)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(DatabaseName);

                _hashRepository = new Hashtable();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }
        public MongoContext(string connectionString, string databaseName, bool isSsl)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                if (isSsl)
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(databaseName);

                _hashRepository = new Hashtable();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }
        public IMongoCollection<TEntity> Set<TEntity>() where TEntity : class
        {
            var key = typeof(TEntity).Name;
            if (!_hashRepository.Contains(key))
                _hashRepository[key] = Database.GetCollection<TEntity>(key);

            return (IMongoCollection<TEntity>)_hashRepository[key];
        }

    }
}
