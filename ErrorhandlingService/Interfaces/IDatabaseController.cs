using MongoDB.Driver;

namespace ErrorhandlingService.Interfaces
{
    public interface IDatabaseController
    {
        IMongoDatabase GetDatabase();
        IMongoDatabase GetDatabase(string DatabaseName);

        IMongoCollection<CollectionType> GetDBCollection<CollectionType>(string CollectionName);

    }
}
