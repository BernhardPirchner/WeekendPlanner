using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeekendPlanner_API.Models;

namespace WeekendPlanner_API.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> userCollection;

        public UserService(IOptions<UserDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase=mongoClient.GetDatabase(
                settings.Value.DatabaseName );

            userCollection=mongoDatabase.GetCollection<User>(
                settings.Value.UserCollectionName );
        }

        public async Task<List<User>> GetUserAsync()
        {
            return await userCollection.Find(_=>true).ToListAsync();
        }

        public async Task CreateUserAsync(User newUser)
        {
            await userCollection.InsertOneAsync(newUser);
        }
    }
}
