using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WeekendPlanner_API.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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

        public async Task<List<User>> GetAsync() //rein zu Testzwecken
        {
            return await userCollection.Find(_=>true).ToListAsync();
        }

        public async Task<User> GetOneAsync(string id)
        {
            return await userCollection.FindAsync(user=>user.UserId== id).Result.FirstAsync();
        }

        public async Task<bool> EmailExists(string email) //für Registrierung
        {
            bool result = await userCollection.Find(user=>user.UserEmail==email).AnyAsync();
            
            if(result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> Login(Credentials credentials)
        {
            return await userCollection.FindAsync(user => ((user.UserEmail == credentials.Email) && (user.UserPassword==credentials.Password))).Result.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User newUser)
        {
            await userCollection.InsertOneAsync(newUser);
        }
    }
}
