namespace WeekendPlanner_API.Models
{
    public class ProtoEventDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProtoEventCollectionName { get; set; } = null!;
    }
}
