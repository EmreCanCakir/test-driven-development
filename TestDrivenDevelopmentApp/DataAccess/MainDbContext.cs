using Microsoft.EntityFrameworkCore;
using TestDrivenDevelopmentApp.Model;

namespace TestDrivenDevelopmentApp.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
