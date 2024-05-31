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
            bool result = await userCollection.Find(user=>user.Email==email).AnyAsync();
            
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
            return await userCollection.FindAsync(user => ((user.Email == credentials.Email) && (user.Password==credentials.Password))).Result.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User newUser)
        {
            await userCollection.InsertOneAsync(newUser);
        }

        public async Task AddMyEvent(string userId, string eventId)
        {
            User tmp= await userCollection.FindAsync(user => user.UserId==userId).Result.FirstOrDefaultAsync();
            tmp.MyEvents.Add(eventId);
            await UpdateUser(userId, tmp);
            await AddSavedEvent(userId, eventId);
        }

        public async Task AddSavedEvent(string userId, string eventId)
        {
            User tmp = await userCollection.FindAsync(user => user.UserId == userId).Result.FirstOrDefaultAsync();
            tmp.SavedEvents.Add(eventId);
            await UpdateUser(userId, tmp);
        }

        public async Task RemoveMyEvent(string userId, string eventId)
        {
            User tmp = await userCollection.FindAsync(user => user.UserId == userId).Result.FirstOrDefaultAsync();
            tmp.MyEvents.Remove(eventId);
            await UpdateUser(userId, tmp);
        }

        public async Task RemoveSavedEvent(string userId, string eventId)
        {
            User tmp = await userCollection.FindAsync(user => user.UserId == userId).Result.FirstOrDefaultAsync();
            tmp.SavedEvents.Remove(eventId);
            await UpdateUser(userId, tmp);
        }

        public async Task<List<string>> GetMyEvents(string userId)
        {
            User tmp = await userCollection.FindAsync(user => user.UserId == userId).Result.FirstOrDefaultAsync();
            return tmp.MyEvents;
        }

        public async Task<List<string>> GetSavedEvents(string userId)
        {
            User tmp = await userCollection.FindAsync(user => user.UserId == userId).Result.FirstOrDefaultAsync();
            return tmp.SavedEvents;
        }

        public async Task UpdateUser(string userId, User newUser)
        {
            var filter = Builders<User>.Filter.Eq(user => user.UserId, userId);
            var update = Builders<User>.Update.Set(user => user.Username, newUser.Username)
                                            .Set(user => user.Email, newUser.Email)
                                            .Set(user => user.Password, newUser.Password)
                                            .Set(user => user.FirstName, newUser.FirstName)
                                            .Set(user => user.LastName, newUser.LastName)
                                            .Set(user=> user.MyEvents, newUser.MyEvents)
                                            .Set(user=> user.SavedEvents, newUser.SavedEvents);

            await userCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteUser(string userId)
        {
            await userCollection.DeleteOneAsync(userId);
        }

        public async Task RemoveSavedEventGlobally(string eventId)
        {
            List<User> tmp=await userCollection.Find(_=>true).ToListAsync();
            foreach(User user in tmp)
            {
                user.SavedEvents.Remove(eventId);
            }
        }
    }
}
