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
        public string? FirstName { get; set; } = null!;

        [JsonPropertyName("lastname")]
        public string? LastName { get; set; } = null!;

        [JsonPropertyName("username")]
        public string? Username { get; set; } = null!;

        [JsonPropertyName("email")]
        public string? Email { get; set; } = null!;

        [JsonPropertyName("password")]
        public string? Password { get; set; } = null!;

        [JsonIgnore]
        public bool IsAdmin { get; set; } = false;

        [JsonIgnore]
        public List<string> SavedEvents { get; set; } = new List<string>();

        [JsonIgnore]
        public List<string> MyEvents { get; set; }=new List<string>();



        //saved events
    }
}
