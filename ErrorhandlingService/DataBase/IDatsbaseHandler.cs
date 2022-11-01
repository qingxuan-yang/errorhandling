using MongoDB.Driver;

namespace ErrorhandlingService.DataBase
{
    public interface IDatsbaseHandler
    {
        IMongoDatabase GetDatabase();
        IMongoDatabase GetDatabase(string DatabaseName);
        IMongoCollection<CollectionType> GetDBCollection<CollectionType>(string CollectionName);

    }
}
