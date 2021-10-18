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

    public class ResultadosLoginController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/ResultadosLogin
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Resultados_Login", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/ResultadosLogin/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string localidad = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Resultado FROM Resultados_Login WHERE Id_Resultado = " + id, conector);
                localidad = comando.ExecuteScalar().ToString();
            }
            return localidad;
        }

        // POST: api/ResultadosLogin
        public void Post([FromBody] Models.ResultadosLogin oResultado)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Resultados_Login (Resultado) VALUES( '"
                   + oResultado.Resultado + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/ResultadosLogin/5
        public void Put(int id, [FromBody] Models.ResultadosLogin oResultado)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Resultados_Login SET Resultado = '"
                   + oResultado.Resultado + "' WHERE  Id_Resultado = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/ResultadosLogin/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Resultados_Login  WHERE Id_Resultado = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();

        }
    }
}
