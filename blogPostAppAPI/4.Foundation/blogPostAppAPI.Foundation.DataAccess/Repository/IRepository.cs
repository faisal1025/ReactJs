using blogPostAppAPI.Core.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : DomainBase
    {
        IQueryable<TEntity> GetAllItems();

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetByIdAsync(int Id);

        Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> FilterForPaginationAsync(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);
        
        Task<bool> Contains(Expression<Func<TEntity, bool>> filter = null);

        void AddAsync(TEntity entity);

        void DeleteAsync(int Id);

        Task<int> Count();

    }
}
