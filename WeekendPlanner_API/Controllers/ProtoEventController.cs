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

        public ProtoEventController(ProtoEventService protoEventService)
        {
            this.protoEventService = protoEventService;
        }

        [HttpGet("allProtoEvents")]
        public async Task<List<Event>> Get()
        {
            return await protoEventService.GetAsync();
        }

        [HttpGet("oneProtoEvent")]
        public async Task<Event> GetbyId(string id)
        {
            return await protoEventService.GetOneAsync(id);
        }

        [HttpPost("createProtoEvent")]
        public async Task<IActionResult> createProtoEvent(Event newProtoEvent)
        {
            await protoEventService.createProtoEvent(newProtoEvent);
            return CreatedAtAction(nameof(Get), new { id = newProtoEvent.EventId }, newProtoEvent);
        }

        [HttpPut("updateProtoEvent")]
        public async Task Put(string id, Event newProtoEvent)
        {
            await protoEventService.updateProtoEvent(id, newProtoEvent);
        }

        [HttpDelete("deleteProtoEvent")]
        public async Task Delete(string id)
        {
            await protoEventService.deleteProtoEvent(id);
        }

    }
}
