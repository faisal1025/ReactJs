using blogPostAppAPI.Core.Repository;
using blogPostAppAPI.DataAccess.ContextDb;
using blogPostAppAPI.DataAccess.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Entities.PostsDomain.Repository
{
    public class PostRepository:Repository<Post>, IPostRepository
    {
        public PostRepository(blogPostDb context) : base(context)
        {
        }

        public int getAllCount()
        {
            throw new NotImplementedException();
        }
    }
}
