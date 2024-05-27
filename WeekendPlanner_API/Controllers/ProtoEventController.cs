using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeekendPlanner_API.Services;
using WeekendPlanner_API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WeekendPlanner_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProtoEventController : Controller
    {
        private readonly ProtoEventService protoEventService;
        private const string sessionId = "sessionId";

        public ProtoEventController(ProtoEventService protoEventService)
        {
            this.protoEventService = protoEventService;
        }

        [HttpGet("allProtoEvents")]
        public async Task<List<Event>> Get()
        {
            return await protoEventService.GetAllAsync();
        }

        [HttpGet("oneProtoEvent")]
        public async Task<Event> GetbyId(string id)
        {
            return await protoEventService.GetOneAsync(id);
        }

        [HttpPost("createProtoEvent")]
        public async Task<IActionResult> createProtoEvent(Event newProtoEvent)
        {
            //Console.WriteLine(newProtoEvent.Time);
            var userId = HttpContext.Session.GetString(sessionId);
            Console.WriteLine(HttpContext.Session.GetString(sessionId));
            Console.WriteLine(userId);
            if (userId is not null)
            {
                if (newProtoEvent.CreatedBy == string.Empty)
                {
                    newProtoEvent.CreatedBy = userId;
                }
                await protoEventService.createProtoEvent(newProtoEvent);
                return CreatedAtAction(nameof(Get), new { id = newProtoEvent.EventId }, newProtoEvent);
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpPut("updateProtoEvent")]
        public async Task<IActionResult> Put(string id, Event newProtoEvent)
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null) 
            {
                await protoEventService.updateProtoEvent(id, newProtoEvent);
                return Ok(new { message = $"Event {id} was updated" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

        }

        [HttpDelete("deleteProtoEvent")]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = HttpContext.Session.GetString(sessionId);

            if (userId is not null) 
            {
                await protoEventService.deleteProtoEvent(id);
                return Ok(new { message = $"Deleted Event {id}" });
            }
            else
            {
                return Unauthorized(new {message="Unauthorized"});
            }

        }

    }
}
