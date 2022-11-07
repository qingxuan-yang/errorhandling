namespace ErrorhandlingService.Controllers
{
    public class MongodbSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ErrorCollectionName { get; set; } = null!;
    }
}