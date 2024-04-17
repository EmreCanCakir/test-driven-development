using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using TestDrivenDevelopmentApp.Controllers;
using TestDrivenDevelopmentApp.Core.Services;
using TestDrivenDevelopmentApp.Model.Dtos;

namespace TestDrivenDevelopment.Tests.Controllers
{
    public class AuthControllerTest
    {
        [Fact]
        public void Login_ShouldReturnOkResponseAndJwtToken_WhenUsernameAndPasswordValid()
        {
            var mockTokenService = new Mock<ITokenService>();
            mockTokenService.Setup(x => x.GenerateJwtToken())
                .Returns("token");

            var underTest = new AuthController(mockTokenService.Object);

            var result = underTest.Login(new UserLoginDto
            {
                UserName = "test",
                Password = "test"
            });

            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeEquivalentTo(new { Token = "token" });
        }

        [Fact]
        public void Login_ShouldReturnUnauthorizedResponse_WhenUsernameAndPasswordNotValid()
        {
            var mockTokenService = new Mock<ITokenService>();
            var underTest = new AuthController(mockTokenService.Object);

            var result = underTest.Login(new UserLoginDto
            {
                UserName = "invalid",
                Password = "invalid"
            });

            result.Should().BeOfType<UnauthorizedObjectResult>();
            result.As<UnauthorizedObjectResult>().Value.Should().BeEquivalentTo("Invalid credentials");
        }
    }
}
