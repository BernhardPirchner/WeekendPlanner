using MongoDB.Driver;
using WeekendPlanner_API.Models;
using Microsoft.Extensions.Options;

namespace WeekendPlanner_API.Services
{
    public class ProtoEventService
    {
        private readonly IMongoCollection<Event> protoEventCollection;

        public ProtoEventService(IOptions<ProtoEventDatabaseSettings> settings)
        {
            var mongoClient=new MongoClient(settings.Value.ConnectionString);
            var mongoDatabse=mongoClient.GetDatabase(settings.Value.DatabaseName);
            protoEventCollection = mongoDatabse.GetCollection<Event>(settings.Value.ProtoEventCollectionName);
        }

        public async Task<List<Event>> GetAsync()
        {
            return await protoEventCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Event> GetOneAsync(string id)
        {
            return await protoEventCollection.FindAsync(e=>e.EventId==id).Result.FirstOrDefaultAsync();
        }

        public async Task createProtoEvent(Event newProtoEvent)
        {
            await protoEventCollection.InsertOneAsync(newProtoEvent);
        }

        public async Task deleteProtoEvent(string protoEventId)
        {
            await protoEventCollection.DeleteOneAsync(e=> e.EventId==protoEventId);
        }

        public async Task updateProtoEvent(string protoEventId, Event newProtoEvent)
        {
            await protoEventCollection.FindOneAndReplaceAsync(e => e.EventId == protoEventId, newProtoEvent);
        }
    }
}
