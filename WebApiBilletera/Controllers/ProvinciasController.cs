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

    public class ProvinciasController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Provincias
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Provincias", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }


        // GET: api/Provincias/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string provincia = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Provincia FROM Provincias WHERE Id_Provincia = " + id, conector);
                provincia = comando.ExecuteScalar().ToString();
            }
            return provincia;
        }

        // POST: api/Provincias
        public void Post([FromBody] Models.Provincias oProvincia)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Provincias (Provincia) VALUES( '"
                   + oProvincia.Provincia + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/Provincias/5
        public void Put(int id, [FromBody] Models.Provincias oProvincia)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Provincias SET Provincia = '"
                   + oProvincia.Provincia + "' WHERE  Id_Provincia = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Provincias/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Provincias WHERE Id_Provincia = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();

        }
    }
}
