using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUITask.Models;
using WebUITask.Services.Abstracts;
using WebUITask.Services.Concrets;

namespace WebUITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return Ok(users ?? new List<User>());
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user is { })
            {
                await _userRepository.Add(user);
                return Ok(new
                {
                    message = "Succesfully registered !",   
                    user
                });
            }
            return BadRequest();
        }
    }
}
