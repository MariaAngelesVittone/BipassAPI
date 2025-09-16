using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Application.Services;

namespace BipassAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetUser());
        }
    }
}
