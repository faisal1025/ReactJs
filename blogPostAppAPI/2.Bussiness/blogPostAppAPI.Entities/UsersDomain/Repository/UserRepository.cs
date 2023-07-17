using blogPostAppAPI.DataAccess.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using blogPostAppAPI.Core.Repository;
using blogPostAppAPI.DataAccess.ContextDb;

namespace blogPostAppAPI.Entities.UsersDomain.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(blogPostDb context): base(context)
        {
        }
    }
}
