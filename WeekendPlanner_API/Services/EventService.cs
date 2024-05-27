using MongoDB.Driver;
using WeekendPlanner_API.Models;
using Microsoft.Extensions.Options;

namespace WeekendPlanner_API.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> eventCollection;

        public EventService(IOptions<EventDatabaseSettings> settings)
        { 
            var mongoClient=new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase=mongoClient.GetDatabase(settings.Value.DatabaseName);
            eventCollection=mongoDatabase.GetCollection<Event>(settings.Value.EventCollectionName);
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await eventCollection.Find(_=>true).ToListAsync();
        }

        public async Task<Event> GetOneAsync(string id)
        {
            return await eventCollection.FindAsync(e=>e.EventId== id).Result.FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetSomeAsync(string[] eventIds)
        {
            var filter = Builders<Event>.Filter.In(e => e.EventId, eventIds);
            List<Event> tmp= await eventCollection.Find(filter).ToListAsync();
            foreach (Event e in tmp)
            {
                Console.WriteLine(e.ToString());
            }
            return tmp;
        }

        public async Task CreateEvent(Event newEvent)
        {

            await eventCollection.InsertOneAsync(newEvent);
        }
    }
}
