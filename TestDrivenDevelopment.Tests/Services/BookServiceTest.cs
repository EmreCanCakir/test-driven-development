using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDevelopmentApp.DataAccess;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopment.Tests.Services
{
    public class BookServiceTest
    {
        [Fact]
        public async Task GetBooks_InvokeBookDalTimesOnce()
        {
            //var mockBookDal = new Mock<IBookDal>();
            //mockBookDal.Setup(x => x.GetAll())
            //    .ReturnsAsync(new List<Book>()
            //    {
            //        new Book { Title = "Book1", Author = "Author1", Year = 2020 },
            //    });

            //var underTest = new BookService(mockBookDal.Object);

            //var result = await underTest.GetBooks();

            //mockBookDal.Verify(x => x.GetAll(), Times.Once);
            //result.Should().BeAssignableTo<List<Book>>();
        }
    }
}
