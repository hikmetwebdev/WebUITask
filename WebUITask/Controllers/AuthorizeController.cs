using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUITask.Services.Abstracts;
using WebUITask.UserSecurity;

namespace WebUITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthorizeController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string email)
        {
            var users = await _userRepository.GetAll();

            foreach (var user in users)
            {
                if (email == user.Email)
                {
                    var token = TokenHandler.CreateToken(_config, email);
                    return Ok(new { Token = token });
                }
            }

            return Unauthorized(new { Message = "Invalid email or password." });
        }
    }
}
