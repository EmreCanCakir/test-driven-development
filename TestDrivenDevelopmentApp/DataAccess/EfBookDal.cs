using System.Linq.Expressions;
using TestDrivenDevelopmentApp.Core.DataAccess;
using TestDrivenDevelopmentApp.Model;

namespace TestDrivenDevelopmentApp.DataAccess
{
    public class EfBookDal : EfEntityRepositoryBase<Book, MainDbContext>, IBookDal
    {
        public EfBookDal(MainDbContext context) : base(context)
        {
        }
    }
}
