using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDevelopmentApp.Controllers;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopment.Tests.Controllers
{
    public class BaseControllerTest
    {
        #region GetAll
        [Fact]
        public async Task GetAll_OnSuccess_ShouldReturns200()
        {
            // Arrange
            var mockService = new Mock<IBookService>();
            mockService.Setup(x => x.GetAll())
                .Returns(new List<Book>()
                {
                    new Book { Title = "Book1", Author = "Author1", Year = 2020 },
                });

            var underTest = new BaseController<Book, IBookService>(mockService.Object);

            // Act
            var result = (OkObjectResult)await underTest.GetAll();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_OnSuccess_InvokeServiceTimesOnce()
        {
            var mockService = new Mock<IBookService>();
            mockService.Setup(x => x.GetAll())
                .Returns(new List<Book>()
                {
                    new Book { Title = "Book1", Author = "Author1", Year = 2020 },
                });

            var underTest = new BaseController<Book, IBookService>(mockService.Object);

            var result = await underTest.GetAll();

            mockService.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetAll_OnSuccess_ShouldReturnListOfEntity()
        {
            var mockService = new Mock<IBookService>();
            mockService.Setup(x => x.GetAll())
                .Returns(new List<Book>()
                    { new Book { Title = "Book1", Author = "Author1", Year = 2020 }, }
                );

            var underTest = new BaseController<Book, IBookService>(mockService.Object);
            var result = await underTest.GetAll();
            var objectResult = (OkObjectResult)result;

            result.Should().BeOfType<OkObjectResult>();
            objectResult.Value.Should().BeOfType<List<Book>>();
        }

        [Fact]
        public async Task GetAll_OnNoEntitiesFound_ShouldReturn500()
        {
            var mockService = new Mock<IBookService>();
            mockService.Setup(x => x.GetAll())
                .Returns(new List<Book>());

            var underTest = new BaseController<Book, IBookService>(mockService.Object);
            var result = await underTest.GetAll();
            var objectResult = (BadRequestResult)result;

            result.Should().BeOfType<BadRequestResult>();
            objectResult.StatusCode.Should().Be(400);
        }
        #endregion

        #region Add
        [Fact]
        public async Task Add_OnSuccess_ShouldReturns201()
        {
            var mockService = new Mock<IBookService>();
            mockService.Setup(x => x.Add(It.IsAny<Book>()))
                .Returns(new CreatedResult());

            var underTest = new BaseController<Book, IBookService>(mockService.Object);
            var result = (CreatedAtActionResult)await underTest.Add(new Book { Title = "Book1", Author = "Author1", Year = 2020 });

            result.StatusCode.Should().Be(201);
        }

        #endregion
    }
}
