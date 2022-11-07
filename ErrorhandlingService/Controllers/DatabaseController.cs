using ErrorhandlingService.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ErrorhandlingService.Controllers
{
    public class DatabaseController : IDatabaseController
    {
        private readonly MongodbSetting _dbsetting;
        private readonly MongoClientBase _mongoclient;

        public DatabaseController(IOptions<MongodbSetting> dbSetting, MongoClientBase mongoClient)
        {
            _dbsetting = dbSetting.Value;
            _mongoclient = mongoClient;
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoclient.GetDatabase(_dbsetting.DatabaseName);
        }

        public IMongoDatabase GetDatabase(string DatabaseName)
        {
            return _mongoclient.GetDatabase(DatabaseName);
        }

        public IMongoCollection<CollectionType> GetDBCollection<CollectionType>(string CollectionName)
        {
            return GetDatabase().GetCollection<CollectionType>(CollectionName);
        }

    }
}
