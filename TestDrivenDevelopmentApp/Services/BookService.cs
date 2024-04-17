using AutoMapper;
using TestDrivenDevelopmentApp.DataAccess;
using TestDrivenDevelopmentApp.Model;
using TestDrivenDevelopmentApp.Model.Dtos;

namespace TestDrivenDevelopmentApp.Services
{
    public class BookService: IBookService
    {
        private readonly IBookDal _bookDal;
        private readonly IMapper _autoMapper;
        public BookService(IBookDal bookDal, IMapper autoMapper)
        {
            _bookDal = bookDal;
            _autoMapper = autoMapper;
        }

        public List<BookDto> GetAll()
        {
            var books = _bookDal.GetAll();
            return _autoMapper.Map<List<BookDto>>(books);
        }
    }
}
