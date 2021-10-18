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

    public class TipoOperacionController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/TipoOperacion
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Tipo_Operacion", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/TipoOperacion/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string operacion = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Operacion FROM Tipo_Operacion WHERE Id_tipo_operacion = " + id, conector);
                operacion = comando.ExecuteScalar().ToString();
            }
            return operacion;
        }

        // POST: api/TipoOperacion
        public void Post([FromBody] Models.TipoOperacion Otipo)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Tipo_Operacion (Operacion) VALUES( '"
                   + Otipo.Operacion + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/TipoOperacion/5
        public void Put(int id, [FromBody] Models.TipoOperacion OTipo)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Tipo_Operacion SET Operacion = '"
                   + OTipo.Operacion + "' WHERE  Id_tipo_operacion = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/TipoOperacion/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Tipo_Operacion WHERE Id_tipo_operacion = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();

        }
    }
}
