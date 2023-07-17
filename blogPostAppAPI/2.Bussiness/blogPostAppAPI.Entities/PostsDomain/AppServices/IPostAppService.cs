using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.PostsDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Entities.PostsDomain.AppServices
{
    public interface IPostAppService
    {
        IEnumerable<PostDTO> GetPosts(Expression<Func<Post, bool>> filter);
        Task<PostDTO> GetPostById(int Id);
        Task<bool> AddPost(PostDTO postDTO);
        Task<bool> DeletePost(int id);
        Task<bool> UpdatePost(int id, PostUpdateDTO postDto);
    }
}
