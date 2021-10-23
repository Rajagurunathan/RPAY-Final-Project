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
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cors;

//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using WebAPI.Models;


namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class ForgotPasswordController : ControllerBase
    {

        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _singInManager;
        //private readonly ApplicationSettings _appSettings;

        //public ForgotPasswordController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        //{
        //    _userManager = userManager;
        //    _singInManager = signInManager;
        //    _appSettings = appSettings.Value;
        //}


        SqlConnection con = new SqlConnection("Server=mssql.mrwhitehost.in;Database=rpay;Persist Security Info=True;User ID=rpaybase;Password=5$Z00gmb;MultipleActiveResultSets=True;");

        [HttpPost]
        [Route("Forgot")]
        [EnableCors("AllowMyOrigin")]
        //POST : api/ForgotPassword/Forgot
        public ActionResult Forgot([FromBody] ApplicationUserModel obj)
        {
            con.Open();

            string yourpwd;

            string q = "select PasswordHash from aspnetusers " + obj.UserName;

            SqlCommand cmd = new SqlCommand(q, con);

            yourpwd = cmd.ExecuteScalar().ToString();

            //System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            //System.Text.Decoder utf8Decode = encoder.GetDecoder();
            //byte[] todecode_byte = Convert.FromBase64String(yourpwd);
            //int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            //char[] decoded_char = new char[charCount];
            //utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            //string result = new String(decoded_char);

            //string result = HttpContext.Session.GetString("Password");

            //return result;


            //byte[] mybyte = System.Convert.FromBase64String(yourpwd);
            //string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
            //return returntext;


            //_appSettings.Use(async (context, next) =>
            //    {
            //        // you could get from token or get from session. 
            //        string token = context.Request.Headers["Authorization"];
            //        if (!string.IsNullOrEmpty(token))
            //        {
            //            var tok = token.Replace("Bearer ", "");
            //            var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(tok);

            //            var jti = jwttoken.Claims.First(claim => claim.Type == ClaimTypes.Name);
            //        }
            //        await next();

            //    });


            return Ok("Forgot Password works, Your Password is : "+ yourpwd);
        }
    }
}
