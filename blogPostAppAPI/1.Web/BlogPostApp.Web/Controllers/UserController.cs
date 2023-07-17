using blogPostAppAPI.DataAccess.ContextDb;
using blogPostAppAPI.DataAccess.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogPostAppAPI.Entities.UsersDomain.AppServices;
using blogPostAppAPI.Entities.UsersDomain;
using blogPostAppAPI.Entities.UsersDomain.DTOs;
using BlogPostApp.Web.Models;
using Microsoft.Extensions.Configuration;

namespace BlogPostApp.Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserAppService userAppService;
        private IConfiguration config;
        public UserController(IUserAppService userAppService, IConfiguration config)
        {
            this.userAppService = userAppService;
            this.config = config;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await userAppService.Authenticate(loginDTO.Email, loginDTO.Password);
            
            if(result.IsSuccess == false)
                return Json(result);

            var token = new JwtToken(config).GenerateToken(result.item);
            result.item = null;
            result.message = token;
            return Json(result);
        }

        // api/user/register/
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var result = await userAppService.RegisterUser(userDTO);
            return Json(result);
        }

        
        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await userAppService.DeleteAccount(Id);
            return Json(result);
        }

        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int Id, UserUpdateDTO userUpdateDto)
        {
            var result = await userAppService.UpdateAccount(Id, userUpdateDto);
            return Json(result);
        }
    }
}
