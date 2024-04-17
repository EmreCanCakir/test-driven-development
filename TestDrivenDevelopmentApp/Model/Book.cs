using System.ComponentModel.DataAnnotations;

namespace TestDrivenDevelopmentApp.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}
