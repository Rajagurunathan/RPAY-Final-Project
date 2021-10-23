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
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WebAPI.Controllers
{

    /*---------------------------PLANS SECTION------------------------------------*/
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class RechargeController : ControllerBase
    {
        private static string uname;
        private string credentials1 = "userid=SARAVANA07&key=269628673204646";
        private string credentials = "userid=raja123&key=149763889314583";
        SqlConnection con = new SqlConnection("Server=mssql.mrwhitehost.in;Database=rpay;Persist Security Info=True;User ID=rpaybase;Password=5$Z00gmb;MultipleActiveResultSets=True;");


        //Get : /api/Recharge/GetJioPlans
        private UserManager<ApplicationUser> _userManager;
        public RechargeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        [Route("GetJioPlans")]
        [EnableCors("AllowMyOrigin")]
        public async Task<ActionResult> GetJioPlansAsync()
        {
            
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=JO&circle_code=TN");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            
            return Ok(result);
        }


        //Get : /api/Recharge/GetAirtelPlans
        [Authorize]
        [HttpGet]
        [Route("GetAirtelPlans")]
        [EnableCors("AllowMyOrigin")]

        public async Task<ActionResult> GetAirtelPlansAsync()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=AT&circle_code=TN");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return Ok(result);
        }

        //Get : /api/Recharge/GetBsnlPlans
        [Authorize]
        [HttpGet]
        [Route("GetBsnlPlans")]
        [EnableCors("AllowMyOrigin")]
        public async Task<ActionResult> GetBsnlPlansAsync()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=BS&circle_code=TN");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return Ok(result);
        }


        //Get : /api/Recharge/GetVodafonePlans
        [Authorize]
        [HttpGet]
        [Route("GetVodafonePlans")]
        [EnableCors("AllowMyOrigin")]

        public async Task<ActionResult> GetVodafonePlansAsync()
        {

            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=VF&circle_code=TN");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return Ok(result);
        }
        
        [HttpGet]
        [EnableCors("AllowMyOrigin")]
        //Post : /api/Recharge/postmyname
        [Route("PostMyName")]
        public ActionResult PostMyName([FromQuery] string name)
        { uname = name;
            return Ok(uname);
        }
        //Get : /api/Recharge/GetAllPlans
        //[HttpGet]
        //[Route("GetAllPlans")]

        //public async Task<ActionResult> GetAllPlansAsync()
        //{
        //    var client1 = new HttpClient();
        //    HttpResponseMessage response1 = await client1.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=AT&circle_code=TN");
        //    response1.EnsureSuccessStatusCode();
        //    var result1 = JsonConvert.DeserializeObject<dynamic>(await response1.Content.ReadAsStringAsync());

        //    var client2 = new HttpClient();
        //    HttpResponseMessage response2 = await client2.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=JO&circle_code=TN");
        //    response2.EnsureSuccessStatusCode();
        //    var result2 = JsonConvert.DeserializeObject<dynamic>(await response2.Content.ReadAsStringAsync());

        //    var client3 = new HttpClient();
        //    HttpResponseMessage response3 = await client2.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=BS&circle_code=TN");
        //    response3.EnsureSuccessStatusCode();
        //    var result3 = JsonConvert.DeserializeObject<dynamic>(await response3.Content.ReadAsStringAsync());


        //    var client4 = new HttpClient();
        //    HttpResponseMessage response4 = await client2.GetAsync("https://joloapi.com/api/v1/operatorplanfinder.php?"+credentials+"&operator_code=VF&circle_code=TN");
        //    response4.EnsureSuccessStatusCode();
        //    var result4 = JsonConvert.DeserializeObject<dynamic>(await response4.Content.ReadAsStringAsync());



        //    //result1.Merge(result2);


        //    return Ok(new { items = new[] { result1,result2,result3,result4 }});
        //}


        /*---------------------------RECHARGE SECTION------------------------------------*/


        //Get : /api/Recharge/RechargeComplete
        [Authorize]
        [HttpPost]
        [EnableCors("AllowMyOrigin")]
        [Route("RechargeComplete")]
        public async Task<ActionResult> RechargeComplete([FromBody] RechargeModel obj)
        {

            // balance < amt  - add money
            //1.recharge 2.update transaction table & user balance 3.Notify pop up & Redirect
            //param: username , planamt,

            /*
             * userid(1702091),
            key(our key),
            operator = BS,AT,JO,VF
            service = our phone number
            amount,
            order id=our clientid (randomly generated)(also usedtransction id)*/

            //JObject jobject;
            //var jsonObject = new JObject();

            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var username = user.UserName;            //HttpContext.Session.GetString("UserName");
            int amount = Convert.ToInt32(obj.Amount);
            string phonenumber = obj.PhoneNumber;
            string myoperator = obj.Operator;

            string q_balance = "select balance from aspnetusers where UserName = '" + username+"'";

            con.Open();

            SqlCommand cmd = new SqlCommand(q_balance, con);

            int balance = Convert.ToInt32(cmd.ExecuteScalar());

            if(balance < amount)
            {
                //return RedirectToAction("RazorGateway","WalletMVC");
            }
            else
            {
                Random rdm = new Random();
                string randomnumber = Convert.ToString(rdm.Next());
                //randomnumber session

                string uri = "https://joloapi.com/api/v1/recharge.php?"+credentials1+"&operator=" + myoperator + "&service=" + phonenumber + "&amount=" + amount + "&orderid=" + randomnumber;

                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());


                DateTime dt = DateTime.Now;

                //string q_transact = "insert into TransacationHistory values('"+12345676799"','"+naveethzul+"','"+2020-01-01 12:45:56.000+',"+amount+"'false','true','success')"

                string q_transact = "insert into TransacationHistory values('DBT"+randomnumber+"','"+username+"','"+dt+"',"+amount+",'false','true','success')";

                SqlCommand cmd2 = new SqlCommand(q_transact, con);

                cmd2.ExecuteNonQuery();

                string q_update_balance = "update aspnetusers set balance = balance - "+amount+" where UserName = '"+username+"'";

                SqlCommand cmd3 = new SqlCommand(q_update_balance, con);

                cmd3.ExecuteNonQuery();

                con.Close();

                return Ok(result);


            }

            return Ok("Out of Recharge");

        }
 
     
        [Route("AddMoney")]
        [EnableCors("AllowMyOrigin")]
        //Get : /api/Recharge/AddMoney
        public async Task<ActionResult> AddMoney([FromQuery] int amount)
        {
            int walamt = amount;
            Random rdm = new Random();
            string randomnumber = Convert.ToString(rdm.Next());
            try
            {
                //string userId = User.Claims.First(c => c.Type == "UserID").Value;
                //var user = await _userManager.FindByIdAsync(userId);
                //var username = user.UserName;
                var username = uname;
                DateTime dt = DateTime.Now;

                con.Open();
                string q_transact = "insert into TransacationHistory values('CRD" + randomnumber + "','" + username + "','" + dt + "'," + amount + ",'true','false','success')";

                SqlCommand cmd2 = new SqlCommand(q_transact, con);

                cmd2.ExecuteNonQuery();

                string q_update_balance = "update aspnetusers set balance = balance + " + amount + " where UserName = '" + username + "'";

                SqlCommand cmd3 = new SqlCommand(q_update_balance, con);

                cmd3.ExecuteNonQuery();

                con.Close();
            }

            catch (Exception)
            {
                return Redirect("http://localhost:4200/home");
            }
               

                //randomnumber session
          
            //HttpContext.Session.SetString("paymentam", walamt);

            //random number transnumber
            //if (walamt != "0")
            //{

            //}
            //call add money api
            //update transaction table
            //update user balance using another mvc controller

            return Redirect("http://localhost:4200/home");
        }
        //update pay

      


}

}
