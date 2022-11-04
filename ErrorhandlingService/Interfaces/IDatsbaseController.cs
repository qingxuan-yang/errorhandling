using MongoDB.Driver;

namespace ErrorhandlingService.Interfaces
{
    public interface IDatsbaseController
    {
        IMongoDatabase GetDatabase();
        IMongoDatabase GetDatabase(string DatabaseName);

        IMongoCollection<CollectionType> GetDBCollection<CollectionType>(string CollectionName);

    }
}
