using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.UsersDomain.Repository;
using blogPostAppAPI.Foundation.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Entities.UsersDomain.UOW
{
    public interface IUserUow:IUnitOfWork
    {
        IUserRepository userRepository { get; }
    }
}
