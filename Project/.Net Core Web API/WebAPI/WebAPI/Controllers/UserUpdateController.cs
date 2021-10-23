using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class UserUpdateController : ControllerBase
    {

        //static string strcon = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;

        SqlConnection con = new SqlConnection("Server=mssql.mrwhitehost.in;Database=rpay;Persist Security Info=True;User ID=rpaybase;Password=5$Z00gmb;MultipleActiveResultSets=True;");
        private UserManager<ApplicationUser> _userManager;
        public UserUpdateController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        [Route("UpdateProfile")]
        [EnableCors("AllowMyOrigin")]
        //POST : /api/UserUpdate/UpdateProfile
        public async Task<IActionResult> UpdateProfile([FromQuery] string fname, [FromQuery] string mail, [FromQuery] string phno)
        {
            con.Open();

            DataTable dt = new DataTable();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var uname = user.UserName;

            string fullname = fname;
            string email = mail;
            string phone = phno;

            string q_update = "update aspnetusers set FullName = '" + fullname + "' , email = '" + email + "', PhoneNumber = '" + phone + "' where UserName = '" + uname + "'";

            SqlCommand cmd = new SqlCommand(q_update, con);
            cmd.ExecuteNonQuery();

            String q = "select * from aspnetusers where UserName = '" + uname + "'";

            SqlDataAdapter ad = new SqlDataAdapter(q, con);


            ad.Fill(dt);
            con.Close();

            return Ok(dt);
        }
        [Authorize]
        [HttpGet]
        [Route("GetMyDetails")]
        [EnableCors("AllowMyOrigin")]
        //POST : /api/UserUpdate/GetMyDetails
        public async Task<IActionResult> GetMyDetails()
        {
            con.Open();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var uname = user.UserName;

            DataTable dt = new DataTable();
            String q = "select * from aspnetusers where UserName = '" + uname + "'";

            SqlDataAdapter ad = new SqlDataAdapter(q, con);


            ad.Fill(dt);
            con.Close();

            return Ok(dt);
        }

        //GET : /api/UserUpdate/GetMyBalance
        [Authorize]
        [HttpGet]
        [Route("GetMyBalance")]
        [EnableCors("AllowMyOrigin")]
        public async Task<IActionResult> GetMyBalanceAsync()
        {
            con.Open();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var username = user.UserName;

            //create session for username

            string q_balance = "select balance from aspnetusers where UserName ='"+ username+"'";

            SqlCommand cmd = new SqlCommand(q_balance, con);

            int balance = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return Ok(balance);
        }
    }
}
