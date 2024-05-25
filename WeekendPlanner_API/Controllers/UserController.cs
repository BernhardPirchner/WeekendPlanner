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
        public async Task<IActionResult> GetOne()
        {
            var userId = HttpContext.Session.GetString("sessionId");
            //Console.WriteLine(HttpContext.Session.GetString("sessionId"));
            //Console.WriteLine(userId);
            if (userId is not null)
            {
                return Ok(new { message = $"Hallo {userId}" });
            }
            else
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
        }

        [HttpGet("checkEmail")]
        public async Task<bool> CheckEmailExisting(string email)
        {
            return await userService.EmailExists(email);
        }

        [HttpGet("isAdmin")]
        public async Task<bool> IsAdmin()
        {
            var userId = HttpContext.Session.GetString("sessionId");
            if (userId is not null) 
            {
                return userService.GetOneAsync(userId).Result.IsAdmin;
            }
            else
            {
                return false;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            User tmp= await userService.Login(credentials);


            if(tmp is not null)
            {
                Console.WriteLine(tmp.UserId);
                HttpContext.Session.SetString("sessionId", tmp.UserId);
                Console.WriteLine(HttpContext.Session.GetString("sessionId"));
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
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }
    }
}
