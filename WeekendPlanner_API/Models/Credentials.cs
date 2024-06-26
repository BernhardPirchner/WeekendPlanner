﻿

using System.Text.Json.Serialization;

namespace WeekendPlanner_API.Models
{
    public class Credentials
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("password")]
        public string Password { get; set; } = "";
    }
}
