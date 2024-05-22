namespace WeekendPlanner_API.Models
{
    public class EventDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string EventCollectionName { get; set; } = null!;
    }
}
