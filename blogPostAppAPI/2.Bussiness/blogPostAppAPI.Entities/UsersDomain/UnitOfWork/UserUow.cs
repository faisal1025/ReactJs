using blogPostAppAPI.Core.Repository;
using blogPostAppAPI.DataAccess.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using blogPostAppAPI.Foundation.DataAccess.UnitOfWork;
using blogPostAppAPI.DataAccess.ContextDb;
using blogPostAppAPI.Entities.UsersDomain.Repository;

namespace blogPostAppAPI.Entities.UsersDomain.UOW
{
    public class UserUow : UnitOfWork, IUserUow
    {
        private readonly blogPostDb _context;
       public UserUow(blogPostDb context) : base(context)
       {
            _context = context;
       }

        public IUserRepository userRepository => new UserRepository(_context);
    }
}
