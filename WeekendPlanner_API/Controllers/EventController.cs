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
        private const string sessionId = "sessionId";

        public EventController(EventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet("allEvents")]
        public async Task<List<Event>> Get()
        {
            return await eventService.GetAllAsync();
        }

        [HttpGet("oneEvent")]
        public async Task<Event> GetOne(string id)
        {
            return await eventService.GetOneAsync(id);
        }

        [HttpGet("someEvents")]
        public async Task<List<Event>> GetSome([FromQuery] string[] eventIds)
        {
            return await eventService.GetSomeAsync(eventIds);
        }

        [HttpPost("createEvent")]
        public async Task<IActionResult> Post(Event newEvent)
        {
            await eventService.CreateEvent(newEvent);
            return CreatedAtAction(nameof(Get), new { id = newEvent.EventId }, newEvent);
        }

        [HttpPut("updateEvent")]
        public async Task<IActionResult> Put(string id, Event newEvent)
        {
            var userId = HttpContext.Session.GetString(sessionId);
            Console.WriteLine("Hello");
            if (userId is not null)
            {
                await eventService.UpdateEvent(id, newEvent);
                return Ok(new { message = $"Event {id} successfully updated" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpDelete("deleteEvent")]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                await eventService.DeleteEvent(id);
                return Ok(new { message = $"Event {id} successfully deleted" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }
    }
}

