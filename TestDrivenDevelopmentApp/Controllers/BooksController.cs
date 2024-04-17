using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : BaseController<Book, IBookService>
    {
        private readonly IBookService _service;
        public BooksController(IBookService service) : base(service)
        {
            _service = service;
        }
    }
}
