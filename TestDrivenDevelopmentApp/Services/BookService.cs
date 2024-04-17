using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.DataAccess;
using TestDrivenDevelopmentApp.Model;

namespace TestDrivenDevelopmentApp.Services
{
    public class BookService: IBookService
    {
        private readonly IBookDal _bookDal;
        public BookService(IBookDal bookDal)
        {

            _bookDal = bookDal;
        }

        public IActionResult Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            var books = _bookDal.GetAll();
            return books;
        }
    }
}
