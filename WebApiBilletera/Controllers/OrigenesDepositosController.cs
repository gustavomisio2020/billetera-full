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

    public class OrigenesDepositosController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/OrigenesDepositos
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Origenes_depositos", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/OrigenesDepositos/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string origen = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Origen FROM Origenes_depositos WHERE ID_Origen = " + id, conector);
                origen = comando.ExecuteScalar().ToString();
            }
            return origen;
        }

        // POST: api/OrigenesDepositos
        public void Post([FromBody] Models.Origenesdepositos oOrigen)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Origenes_depositos (Origen) VALUES( '" 
                    + oOrigen.Origen + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }
        // PUT: api/OrigenesDepositos/5
        public void Put(int id, [FromBody] Models.Origenesdepositos oOrigen)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Origenes_depositos SET Origen = '" 
                   + oOrigen.Origen + "' WHERE  ID_Origen = " + id;

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }


        }

        // DELETE: api/OrigenesDepositos/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Origenes_depositos WHERE ID_Origen = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }

    }
}
