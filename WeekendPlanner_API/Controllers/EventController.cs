using Amazon.Runtime.Internal;
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

        [HttpGet]
        public async Task<List<Event>> Get()
        {
            return await eventService.GetEventsAsync();
        }

        public async Task<IActionResult> Post(Event newEvent)
        {
            await eventService.CreateEventAsync(newEvent);
            return CreatedAtAction(nameof(Get), new { id = newEvent.EventId }, newEvent);
        }
    }
}
