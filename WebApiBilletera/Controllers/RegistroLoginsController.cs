using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiBilletera.Controllers
{
    [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]

    public class RegistroLoginsController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/RegistroLogins
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Registro_Logins", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }


        // GET: api/RegistroLogins/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string IP = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT IP FROM Registro_Logins WHERE Id_Registro = " + id, conector);
                IP = comando.ExecuteScalar().ToString();
            }
            return IP;
        }

        // POST: api/RegistroLogins
        public void Post([FromBody] Models.RegistroLogins oRegistro)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Registro_Logins (Usuario, fechayhora, Resultado, IP, Localizacion) VALUES( '"
                   + oRegistro.Usuario + "' , '" + oRegistro.FechayHora + "' , '" + oRegistro.Resultado + "' ,'" + oRegistro.IP + "' , '"
                    + oRegistro.Localizacion + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/RegistroLogins/5
        public void Put(int id, [FromBody] Models.RegistroLogins oRegistro)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Registro_Logins SET Usuario = "
                   + oRegistro.Usuario + ", fechayhora = '" + oRegistro.FechayHora + "', Resultado = "
                    + oRegistro.Resultado + " , IP = '" + oRegistro.IP + "', Localizacion = '" + oRegistro.Localizacion + "' WHERE Id_Registro = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }


        // DELETE: api/RegistroLogins/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Registro_Logins WHERE Id_Registro = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}
