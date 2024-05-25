using Microsoft.AspNetCore.Mvc;
using WeekendPlannerServer.Services;
using WeekendPlannerServer.Models;

namespace WeekendPlannerServer.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
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
        public async Task<IActionResult> Post(User user)
        {
            await userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new {id=user.Id}, user);
        }
    }
}
