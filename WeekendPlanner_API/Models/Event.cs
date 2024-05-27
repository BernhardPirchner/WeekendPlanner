using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace WeekendPlanner_API.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? EventId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; } = null!;

        [JsonPropertyName("start")]
        public DateTime? Start { get; set; } = null!;

        [JsonPropertyName ("end")]
        public DateTime? End { get; set; } =null!;

        [JsonPropertyName("location")]
        public string? Location { get; set; } = null!;

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        //pictures
        //"I'm there" - funtionality
        //location
    }
}
