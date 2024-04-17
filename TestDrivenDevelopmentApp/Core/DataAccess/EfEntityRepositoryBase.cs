using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TestDrivenDevelopmentApp.Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }
    }
}
