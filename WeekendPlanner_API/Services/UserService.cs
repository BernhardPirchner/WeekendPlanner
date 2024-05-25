﻿using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<List<User>> GetAsync() //rein zu Testzwecken
        {
            return await userCollection.Find(_=>true).ToListAsync();
        }

        public async Task<bool> EmailExists(Credentials credentials) //für Registrierung
        {
            bool result = await userCollection.Find(user=>user.UserEmail==credentials.Email).AnyAsync();
            
            if(result)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<User> GetUser(Credentials credentials)
        {
            User tmp = await userCollection.FindAsync(user => ((user.UserEmail == credentials.Email) && (user.UserPassword==credentials.Password))).Result.FirstOrDefaultAsync();
            if(tmp is User)
            {
                return tmp;
            }
            else
            {
                return null;
            }


        }

        public async Task CreateAsync(User newUser)
        {
            await userCollection.InsertOneAsync(newUser);
        }
    }
}
