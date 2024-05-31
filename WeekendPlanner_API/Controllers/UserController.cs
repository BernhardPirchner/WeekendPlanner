using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeekendPlanner_API.Services;
using WeekendPlanner_API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WeekendPlanner_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService userService;
        private const string sessionId = "sessionId";

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("allUsers")]
        public async Task<List<User>> Get()
        {
            return await userService.GetAsync();
        }

        [HttpGet("oneUser")]
        public async Task<bool> GetOne()
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("checkEmail")]
        public async Task<bool> CheckEmailExisting(string email)
        {
            Credentials credentials = new Credentials();
            credentials.Email=email;
            return await userService.EmailExists(credentials.Email);
        }

        [HttpGet("isAdmin")]
        public async Task<bool> IsAdmin()
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null) 
            {
                return userService.GetOneAsync(userId).Result.IsAdmin;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("myEvents")]
        public async Task<List<string>> GetMyEvents()
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                return await userService.GetMyEvents(userId);
            }
            else
            {
                return null;
            }
        }

        [HttpGet("savedEvents")]
        public async Task<List<string>> GetSavedEvents()
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                return await userService.GetSavedEvents(userId);

            }
            else
            {
                return null;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            User tmp= await userService.Login(credentials);

            if(tmp is not null)
            {
                //Console.WriteLine(tmp.UserId);
                HttpContext.Session.SetString(sessionId, tmp.UserId);
                //Console.WriteLine(HttpContext.Session.GetString(sessionId));
                return Ok(new {message="Logged in successfully"});
            }
            else
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
        }


        [HttpPost("createUser")]
        public async Task<IActionResult> Post(User newUser)
        {
            await userService.CreateAsync(newUser);
            HttpContext.Session.SetString(sessionId, newUser.UserId);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("addMyEvent")]
        public async Task<IActionResult> AddMyEvent(string eventId)
        {
            var userId = HttpContext.Session.GetString(sessionId);

            if(userId is not null)
            {
                Console.WriteLine("Hallo");
                await userService.AddMyEvent(userId, eventId);
                return Ok(new { message = "Authorized" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpPost("addSavedEvent")]
        public async Task<IActionResult> AddSavedEvent(string eventId)
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                await userService.AddSavedEvent(userId, eventId);
                return Ok(new { message = "Authorized" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> Update(User newUser)
        {
            var userId = HttpContext.Session.GetString(sessionId);

            if (userId is not null)
            {
                await userService.UpdateUser(userId, newUser);
                return Ok(new { message = $"User {userId} updated" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> Delete()
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                await userService.DeleteUser(userId);
                HttpContext.Session.Clear();
                return Ok(new { message = $"User {userId} was deleted" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpDelete("removeMyEvent")]
        public async Task<IActionResult> RemoveMyEvent(string createdById, string eventId)
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                await userService.RemoveMyEvent(createdById, eventId);
                return Ok(new { message = "Authorized" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpDelete("removeSavedEvent")]
        public async Task<IActionResult> RemoveSavedEvent(string eventId)
        {
            var userId = HttpContext.Session.GetString(sessionId);
            if (userId is not null)
            {
                await userService.RemoveSavedEvent(userId, eventId);
                return Ok(new { message = "Authorized" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpDelete("removeSavedGlobal")]
        public async Task<IActionResult> RemoveSavedEventGlobally(string eventId)
        {
            await userService.RemoveSavedEventGlobally(eventId);
            return Ok(new { message = $"Event {eventId} was removed on all Users" });
        }
    }
}
