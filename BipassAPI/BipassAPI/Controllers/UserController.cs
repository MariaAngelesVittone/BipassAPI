using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;

namespace BipassAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var users = await _userRepository.GetAllAsync();
        //    return Ok(users);
        //}
    }
}

