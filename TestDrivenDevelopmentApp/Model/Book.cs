using System.ComponentModel.DataAnnotations;
using TestDrivenDevelopmentApp.Core.Entities;

namespace TestDrivenDevelopmentApp.Model
{
    public class Book: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}
