using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeekendPlannerServer.Models;

namespace WeekendPlannerServer.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> userCollection;

        public UserService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient=new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.UserCollectionName);
            this.userCollection=mongoDatabase.GetCollection<User>(databaseSettings.Value.UserCollectionName);
        }

        public async Task<List<User>> GetAsync()
        {
            return await userCollection.Find(_=> true).ToListAsync();
        }

        public async Task CreateAsync(User user)
        {
            await userCollection.InsertOneAsync(user);   
        }
    }
}
