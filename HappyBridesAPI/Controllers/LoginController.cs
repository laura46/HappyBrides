using Microsoft.AspNetCore.Mvc;
using HappyBridesAPI.Models;
using HappyBridesAPI.Data;
using System.Collections.Generic;

namespace HappyBridesAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        public Couple Couple { get; set; }
        public LoginController(DBConfiguration config) 
        {
            new DBConfiguration(config);
            Couple = new Couple();
        }

        [HttpPost("create")]
        public ActionResult<string> CreateAccount([FromBody] AccountCreation creationRequest) 
        {
            return Couple.RegisterNewCouple(creationRequest);
        }
        [HttpPost("login")]
        public ActionResult<int> Login([FromBody] LoginRequest loginRequest) 
        {
            return Couple.LoginCouple(loginRequest);
        }
    }
}