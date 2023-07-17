using blogPostAppAPI.Core.OperationalResult;
using blogPostAppAPI.Entities.PostsDomain;
using blogPostAppAPI.Entities.PostsDomain.AppServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using blogPostAppAPI.Entities.PostsDomain.DTOs;

namespace BlogPostApp.Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : Controller
    {

        IPostAppService postAppService;
        public PostController(IPostAppService postAppService)
        {
            this.postAppService = postAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        // api/post/insert
        [Authorize]
        [HttpPost("insert")]
        public async Task<IActionResult> InsertPost(PostDTO postDTO)
        {
            OperationalResult<PostDTO> res = new OperationalResult<PostDTO>();
            var Success = await postAppService.AddPost(postDTO);
            res.IsSuccess = Success;
            if (Success)
            {
                res.message = "Post added successfully";
            }
            else
            {
                res.message = "Some technical issue Occure";
            }
            return Json(res);
        }

        [Authorize]
        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewPost(int id)
        {
            OperationalResult<PostDTO> res = new OperationalResult<PostDTO>();
            var post = await postAppService.GetPostById(id);
            res.item = post;
            if(post == null)
            {
                res.IsSuccess = false;
                res.message = "post does not found";
            }
            else
            {
                res.IsSuccess = true;
                res.message = "post fetched successfully";
            }
            return Json(res);
        }

        // api/post/update/1(any post number)
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePost(int id, PostUpdateDTO postDTO)
        {
            OperationalResult<PostDTO> res = new OperationalResult<PostDTO>();
            var Success = await postAppService.UpdatePost(id, postDTO);
            res.IsSuccess = Success;
            if (Success)
            {
                res.message = "Post updated successfully";
            }
            else
            {
                res.message = "Some technical issue occure";
            }
            return Json(res);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            OperationalResult<PostDTO> res = new OperationalResult<PostDTO>();
            var Success = await postAppService.DeletePost(id);
            res.IsSuccess = Success;
            if (Success)
            {
                res.message = "Post deleted successfully";
            }
            else
            {
                res.message = "Some technical issue occured";
            }
            return Json(res);
        }
    }
}
