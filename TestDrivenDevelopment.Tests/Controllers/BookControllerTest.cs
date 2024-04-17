using FluentAssertions;
using Moq;
using TestDrivenDevelopmentApp.Services;
using TestDrivenDevelopmentApp.Controllers;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Model.Dtos;

namespace TestDrivenDevelopment.Tests.Controllers
{
    public class BookControllerTest
    {
        [Fact]
        public void BooksController_ShouldBeAssignableToBaseController()
        {
            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(x => x.GetAll());

            var underTest = new BooksController(mockBookService.Object);

            underTest.Should().BeAssignableTo<BaseController<BookDto, IBookService>>();
        }
    }
}