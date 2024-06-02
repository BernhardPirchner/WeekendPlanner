using MongoDB.Bson.Serialization.Attributes;

namespace WeekendPlannerServer.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id {  get; set; }

        [BsonElement("username")]
        public string UserName { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("password")]
        public string Password { get; set; } = null!;
    }
}
