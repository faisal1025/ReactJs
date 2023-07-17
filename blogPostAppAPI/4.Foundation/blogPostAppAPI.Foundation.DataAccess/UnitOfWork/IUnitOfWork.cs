using blogPostAppAPI.Core.Domain;
using blogPostAppAPI.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Foundation.DataAccess.UnitOfWork
{
    public interface IUnitOfWork 
    { 
        Task<bool> SaveAsync();
    }
}
