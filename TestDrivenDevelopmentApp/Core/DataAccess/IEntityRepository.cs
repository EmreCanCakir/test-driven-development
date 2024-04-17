using System.Linq.Expressions;

namespace TestDrivenDevelopmentApp.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
