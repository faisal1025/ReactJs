using blogPostAppAPI.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Core.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DomainBase
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> entity;
        public Repository(DbContext context)
        {
            this.context = context;
            this.entity = context.Set<TEntity>();
        }
        public async void AddAsync(TEntity item)
        {
            await entity.AddAsync(item);
        }

        public async Task<bool> Contains(Expression<Func<TEntity, bool>> filter = null)
        {
            return await entity.AnyAsync(filter); 
        }

        public async Task<int> Count()
        {
            return await entity.CountAsync();
        }

        public async void DeleteAsync(int Id)
        {
            var item = await entity.FindAsync(Id);
            entity.Remove(item);
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter = null)
        {
            return entity.Where(filter).AsQueryable();
        }

        public Task<IQueryable<TEntity>> FilterForPaginationAsync(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllItems()
        {
            return entity.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await entity.FindAsync(Id);
        }

        public async Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await entity.FirstOrDefaultAsync(expression);
        }

    }
}
