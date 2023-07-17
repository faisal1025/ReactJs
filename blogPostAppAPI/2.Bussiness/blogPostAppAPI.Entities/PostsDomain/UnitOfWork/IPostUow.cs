using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.PostsDomain.Repository;
using blogPostAppAPI.Foundation.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Entities.PostsDomain.UOW
{
    public interface IPostUow:IUnitOfWork
    {
        IPostRepository postRepository { get; }
    }
}
