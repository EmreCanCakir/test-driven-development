﻿using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDevelopmentApp.Core.Cache;
using TestDrivenDevelopmentApp.Core.DataAccess;
using TestDrivenDevelopmentApp.DataAccess;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Model.Dtos;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopment.Tests.Services
{
    public class BookServiceTest
    {
        [Fact]
        public async Task GetBooks_InvokeBookDalTimesOnce()
        {
            var mockBookDal = new Mock<IBookDal>();
            var mockMapper = new Mock<IMapper>();
            var mockCacheService = new Mock<ICacheService>();
            var books = new List<Book>()
                {
                    new Book { Title = "Book1", Author = "Author1", Year = 2020 },
                };

            mockBookDal.Setup(x => x.GetAll(null)).Returns(books);
            mockCacheService.Setup(x => x.GetAsync<List<Book>>("key", new CancellationToken()))
                .ReturnsAsync(books);

            var underTest = new BookService(mockBookDal.Object, mockMapper.Object, mockCacheService.Object);

            var result = await underTest.GetAll();

            mockBookDal.Verify(x => x.GetAll(null), Times.Once);
        }
    }
}
