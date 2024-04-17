using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TestDrivenDevelopmentApp.Core.Services;
using TestDrivenDevelopmentApp.Model.Dtos;

namespace TestDrivenDevelopmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;   
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            if (userLogin.UserName == "test" && userLogin.Password == "test")
            {
                var token = _tokenService.GenerateJwtToken();
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid credentials");
        }
    }
}
