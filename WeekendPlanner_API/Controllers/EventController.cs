using Microsoft.AspNetCore.Mvc;
using WeekendPlanner_API.Models;
using WeekendPlanner_API.Services;

namespace WeekendPlanner_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly EventService eventService;

        public EventController(EventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet("allEvents")]
        public async Task<List<Event>> Get()
        {
            return await eventService.GetEventsAsync();
        }

        [HttpGet("oneEvent")]
        public async Task<Event> GetOne(string id)
        {
            return await eventService.GetOneAsync(id);
        }

        [HttpPost("createEvent")]
        public async Task<IActionResult> Post(Event newEvent)
        {
            await eventService.CreateEvent(newEvent);
            return CreatedAtAction(nameof(Get), new {id=newEvent.EventId}, newEvent);
        }
    }
}
