using AutoMapper;
using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.PostsDomain.DTOs;
using blogPostAppAPI.Entities.PostsDomain.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Entities.PostsDomain.AppServices
{
    public class PostAppService : IPostAppService
    {
        private readonly IPostUow postUow;
        private readonly IMapper mapper;
        public PostAppService(IPostUow postUow, IMapper mapper)
        {
            this.mapper = mapper;
            this.postUow = postUow;
        }

        public async Task<bool> AddPost(PostDTO postDTO)
        {
            var post = mapper.Map<PostDTO, Post>(postDTO);
            postUow.postRepository.AddAsync(post);
            return await postUow.SaveAsync();
        }

        public async Task<bool> UpdatePost(int id, PostUpdateDTO postDto)
        {
            var post = await postUow.postRepository.GetByIdAsync(id);
            post.LastModifiedDate = DateTime.Now;
            mapper.Map(postDto, post);
            return await postUow.SaveAsync();
        }

        public async Task<bool> DeletePost(int id)
        {
            postUow.postRepository.DeleteAsync(id);
            return await postUow.SaveAsync();
        }

        public async Task<PostDTO> GetPostById(int Id)
        {
            var post = await postUow.postRepository.GetByIdAsync(Id);
            var postDTO = mapper.Map<Post, PostDTO>(post);
            return postDTO;
        }

        public IEnumerable<PostDTO> GetPosts(Expression<Func<Post, bool>> filter)
        {
            IEnumerable<Post> posts = postUow.postRepository.Filter(filter).ToList();
            var postsDTO = mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
            return postsDTO;
        }

    }
}
