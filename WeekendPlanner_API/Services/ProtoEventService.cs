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
            var filter = Builders<Event>.Filter.Eq(e => e.EventId, protoEventId);
            var update = Builders<Event>.Update.Set(e => e.Name, newProtoEvent.Name)
                                               .Set(e => e.Description, newProtoEvent.Description)
                                               .Set(e => e.Start, newProtoEvent.Start)
                                               .Set(e => e.End, newProtoEvent.End)
                                               .Set(e => e.Location, newProtoEvent.Location);
            await protoEventCollection.UpdateOneAsync(filter, update);
        }
    }
}
