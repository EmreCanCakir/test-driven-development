using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Consumer;

namespace TestDrivenDevelopmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly AuthTokenGeneratedConsumer _tokenGeneratedConsumer;

        public AuthController(IPublishEndpoint publishEndpoint, AuthTokenGeneratedConsumer tokenGeneratedConsumer)
        {
            _publishEndpoint = publishEndpoint;
            _tokenGeneratedConsumer = tokenGeneratedConsumer;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] String userName, [FromQuery] String password)
        {
            await _publishEndpoint.Publish(
                new AuthTokenCreateEvent 
                { 
                    UserName = userName, Password = password 
                }, new CancellationToken());
            var token = await _tokenGeneratedConsumer.GetToken();

            return Ok(new { Token = token });
        }
    }
}
