using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeekendPlanner_WPF
{
    class Event
    {
        [JsonPropertyName("eventId")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; } = null!;

        [JsonPropertyName("location")]
        public string? Location { get; set; } = null!;

        [JsonPropertyName("start")]
        public DateTime? Start { get; set; } = null!;

        [JsonPropertyName("end")]
        public DateTime? End { get; set; } = null!;
    }
}
