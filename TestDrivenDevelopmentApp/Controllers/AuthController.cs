using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly AuthClient _authClient;

        public AuthController(AuthClient authClient)
        {
            _authClient = authClient;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] String userName, [FromQuery] String password)
        {
            var token = _authClient.Login(userName, password);
            return Ok(new { Token = token });
        }
    }
}
