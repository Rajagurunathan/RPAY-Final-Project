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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class WalletController : ControllerBase
    {

        SqlConnection con = new SqlConnection("Server=mssql.mrwhitehost.in;Database=rpay;Persist Security Info=True;User ID=rpaybase;Password=5$Z00gmb;MultipleActiveResultSets=True;");

        private UserManager<ApplicationUser> _userManager;
        public WalletController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        [EnableCors("AllowMyOrigin")]
        [Route("WalletTranaction")]
        //POST : /api/Wallet/WalletTranaction
        public async Task<IActionResult> WalletTranactionAsync()
        {
            con.Open();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var username = user.UserName;

            DataTable dt = new DataTable();

            //create username session

            String q = "select  * from TransacationHistory where UserName = '"+ username + "'and credit = 'true' order by transaction_time  desc"; 

            SqlDataAdapter ad = new SqlDataAdapter(q, con);


            ad.Fill(dt);


            return Ok(dt);

            /*OUTPUT 
             * 
             * [
    {
        "transactionid": "877994051",
        "username": "naveethzul",
        "transaction_time": "2020-11-05T00:56:51",
        "amount": 10000,
        "credit": "true",
        "debit": "false",
        "status": "success"
    }
            ]
    {
             */
        }


    }
}
