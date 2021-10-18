﻿
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApiBilletera.Models;


namespace WebApiBilletera.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// login controller class for authenticate users
        /// </summary>

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }
        [HttpGet]
        [Route("echouser")]

        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated:{ identity.IsAuthenticated}");
        }
    
            [HttpPost]
            
            public IHttpActionResult Authenticate(LoginRequest login)
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
           
               
                var isUserValid = (login.Username == "user" && login.Password == "123456");
                if (isUserValid)
                {
                    var rolename = "Developer";
                    var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
                    return Ok(token);
                }
              
              
                var isTesterValid = (login.Username == "test" && login.Password == "123456");
                if (isTesterValid)
                {
                    var rolename = "Tester";
                    var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
                    return Ok(token);
                }
          
             
                var isAdminValid = (login.Username == "admin" && login.Password == "123456");
                if (isAdminValid)
                {
                    var rolename = "Administrator";
                    var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
                    return Ok(token);
                }
                
                return Unauthorized();
            }
        

    }
}