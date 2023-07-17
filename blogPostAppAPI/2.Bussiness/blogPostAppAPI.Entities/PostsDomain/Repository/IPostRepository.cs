using blogPostAppAPI.Core.Repository;
using blogPostAppAPI.DataAccess.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Entities.PostsDomain.Repository
{
    public interface IPostRepository:IRepository<Post>
    {
        int getAllCount();
    }
}
