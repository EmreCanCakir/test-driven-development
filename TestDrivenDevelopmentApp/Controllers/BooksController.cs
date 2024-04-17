using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Model.Dtos;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : BaseController<BookDto, IBookService>
    {
        private readonly IBookService _service;
        public BooksController(IBookService service) : base(service)
        {
            _service = service;
        }
    }
}
