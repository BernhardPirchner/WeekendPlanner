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

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; } = null!;

        [JsonPropertyName("lastname")]
        public string LastName { get; set; } = null!;

        [JsonPropertyName("username")]
        public string UserName { get; set; } = null!;

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string UserEmail { get; set; } = null!;

        [JsonPropertyName("password")]
        public string UserPassword { get; set; } = null!;

        [JsonPropertyName("admin")]
        public bool IsAdmin { get; set; } = false;

        //saved events
    }
}
