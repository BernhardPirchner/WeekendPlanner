using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows;

namespace WeekendPlanner_WPF
{
    class API_Service
    {
        private static readonly API_Service instance = new API_Service();

        static API_Service() { }

        private API_Service() { }

        public static API_Service Instance { get { return instance; } }

        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<List<Event>> GetEvents()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7002/api/event/allEvents");
            
            List<Event>? events = JsonSerializer.Deserialize<List<Event>>(await response.Content.ReadAsStringAsync());

            return events;
        }

        public async Task<Event> GetOneEvent(string id)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7002/api/event/oneEvent?eventId={id}");
            Event? tmp=JsonSerializer.Deserialize<Event>(await response.Content.ReadAsStringAsync());
            return tmp;
        }
    }
}
