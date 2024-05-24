using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WeekendPlannerServer.Models;

namespace WeekendPlannerServer.Services
{
    public class FestivalService
    {
        private readonly IMongoCollection<Festival> festivalCollection;

        public FestivalService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient=new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            this.festivalCollection = mongoDatabase.GetCollection<Festival>(databaseSettings.Value.FestivalCollectionName);
        }

        public async Task<List<Festival>> GetAsync()
        {
            return await festivalCollection.Find(_ => true).ToListAsync();
        }
    }
}
