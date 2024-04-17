using System.Linq.Expressions;
using TestDrivenDevelopmentApp.Core.Entities;

namespace TestDrivenDevelopmentApp.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
