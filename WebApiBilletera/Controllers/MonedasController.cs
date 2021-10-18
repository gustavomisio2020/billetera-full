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

    public class MonedasController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Monedas
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Monedas", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/Monedas/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string moneda = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Nombre_moneda FROM Monedas WHERE Id_Moneda = " + id, conector);
                moneda = comando.ExecuteScalar().ToString();
            }
            return moneda;
        }

        // POST: api/Monedas
        public void Post([FromBody] Models.Monedas oMoneda)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Monedas (Nombre_moneda) VALUES( '"
                   + oMoneda.Nombre_moneda + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/Monedas/5
        public void Put(int id, [FromBody] Models.Monedas oMoneda)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Monedas SET Nombre_moneda = '"
                   + oMoneda.Nombre_moneda + "' WHERE  Id_Moneda = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }


        // DELETE: api/Monedas/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Monedas WHERE Id_Moneda = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();

        }
    }
}
