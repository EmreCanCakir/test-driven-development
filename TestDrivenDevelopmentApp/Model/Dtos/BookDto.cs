using TestDrivenDevelopmentApp.Core.Entities;

namespace TestDrivenDevelopmentApp.Model.Dtos
{
    public class BookDto: IDto
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int Year { get; set; }
    }
}
