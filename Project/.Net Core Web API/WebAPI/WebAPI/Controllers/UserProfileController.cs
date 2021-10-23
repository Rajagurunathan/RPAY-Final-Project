using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile() {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            HttpContext.Session.SetString("UserName",user.UserName);
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("FullName", user.FullName);
            var hero=user.FullName;

            return new
            {
               //user.FullName,
               //user.Email,
               //user.UserName
               FullName= HttpContext.Session.GetString("FullName"),
               Email=HttpContext.Session.GetString("Email"),
               UserName=HttpContext.Session.GetString("UserName")
        };
        }
    }
}