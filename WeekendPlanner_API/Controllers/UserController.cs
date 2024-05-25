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

        [HttpGet("checkUser")]
        public async Task<bool> CheckEmailExisting(string email)
        {
            return await userService.EmailExists(email);
        }

        [HttpGet("login")]
        public async Task<User> Login(string email, string password)
        {
            return await userService.GetUser(email, password);
        }


        [HttpPost("createUser")]
        public async Task<IActionResult> Post(User newUser)
        {
            await userService.CreateAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }
    }
}
