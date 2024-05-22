using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WeekendPlanner_API.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        [JsonPropertyName("name")]
        public string UserName { get; set; } = null!;

        [JsonPropertyName("email")]
        public string UserEmail { get; set; } = null!;

        [JsonPropertyName("password")]
        public string UserPassword { get; set; } = null!;

        //saved events
    }
}
