using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WeekendPlanner_API.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? EventId { get; set; }

        [JsonPropertyName("time")]
        public DateTime? Time { get; set; } = null!;

        [JsonPropertyName("name")]
        public string? Name { get; set; } = null!;

        [JsonPropertyName("desc")]
        public string? Description { get; set; } = null!;
        
        //pictures
        //"I'm there" - funtionality
        //location


    }
}
