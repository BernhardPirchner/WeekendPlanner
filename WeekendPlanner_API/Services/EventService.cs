﻿using MongoDB.Driver;
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
    }
}
