namespace ErrorhandlingService.Controllers
{
    public class MongoDBSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ErrorCollectionName { get; set; } = null!;
    }
}