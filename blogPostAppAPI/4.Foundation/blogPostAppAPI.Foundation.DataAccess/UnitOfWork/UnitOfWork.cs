using blogPostAppAPI.Core.Domain;
using blogPostAppAPI.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Foundation.DataAccess.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        protected readonly DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
