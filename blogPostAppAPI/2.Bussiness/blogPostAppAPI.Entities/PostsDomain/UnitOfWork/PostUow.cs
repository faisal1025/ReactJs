using blogPostAppAPI.Core.Repository;
using blogPostAppAPI.DataAccess.ContextDb;
using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.PostsDomain.Repository;
using blogPostAppAPI.Foundation.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Entities.PostsDomain.UOW
{
    public class PostUow : UnitOfWork, IPostUow
    {
        private readonly blogPostDb _context;
        public PostUow(blogPostDb context):base(context)
        {
            _context = context;
        }
        public IPostRepository postRepository => new PostRepository(_context);
    }
}
