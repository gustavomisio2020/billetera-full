
using System.Net;
using System.Threading;
using System.Web.Http;
using WebApiBilletera.Models;
using System.Web.Http.Cors;


namespace WebApiBilletera.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {



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
            var Usuarioalmacenado = Buscarclave.BuscarUsuario(login.Username);

            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
           
            var clavealmacenada = Buscarclave.BuscarClaves(login.Username);
               
            var isUserValid = (login.Password == clavealmacenada);
            //var isUserValid = (login.Username == "user" && login.Password == "123456");
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
