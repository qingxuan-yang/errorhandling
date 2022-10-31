using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ErrorhandlingService.DataBase
{
    public class MongodbDatabase: IMongodbDatsbase
    {
        private readonly MongoDBSetting _dbsetting;
        private readonly MongoClientBase _mongoclient;

        public MongodbDatabase(IOptions<MongoDBSetting> dbSetting, MongoClientBase mongoClient) 
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
