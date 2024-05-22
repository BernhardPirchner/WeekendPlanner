using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeekendPlanner_API.Services;
using WeekendPlanner_API.Models;

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

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await userService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await userService.CreateAsync(newUser);
            return CreatedAtAction(nameof(Get), new {id=newUser.UserId}, newUser);
        }
    }
}
