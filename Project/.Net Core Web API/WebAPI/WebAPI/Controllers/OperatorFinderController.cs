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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class OperatorFinderController : ControllerBase
    {
        private string credentials1 = "userid=SARAVANA07&key=269628673204646";
        private string credentials = "userid=raja123&key=149763889314583";
        private UserManager<ApplicationUser> _userManager;
        public OperatorFinderController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        //Get : /api/OperatorFinder/Operator
        [HttpGet]
        [Route("Operator")]
        [EnableCors("AllowMyOrigin")]
        public async Task<ActionResult> OperatorAsync([FromQuery]string phonenumber)
        {
            string uri = "https://joloapi.com/api/v1/operatorfinder.php?"+credentials+"&mob=" + phonenumber;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());

            return Ok(result);

            /* OUTPUT
             * 
             * {
    "status": "SUCCESS",
    "error": "",
    "operator_code": "AT",
    "operator_name": "Airtel",
    "circle_code": "TN",
    "circle_name": "Tamil Nadu",
    "current_type": "PREPAID",
    "hits_left": "85"
}
             */
        }

    }
}
