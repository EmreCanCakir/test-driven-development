using TestDrivenDevelopmentApp.Core.DataAccess;
using TestDrivenDevelopmentApp.Model;

namespace TestDrivenDevelopmentApp.DataAccess
{
    public interface IBookDal: IEntityRepository<Book>
    {
    }
}
