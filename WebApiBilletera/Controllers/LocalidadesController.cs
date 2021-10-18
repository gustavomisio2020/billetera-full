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

    public class LocalidadesController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Localidades
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Localidades", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/Localidades/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string localidad = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Localidad FROM Localidades WHERE Id_Cuenta = " + id, conector);
                localidad = comando.ExecuteScalar().ToString();
            }
            return localidad;
        }

        // POST: api/Localidades
        public void Post([FromBody] Models.Localidades oLocalidad)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Localidades (Localidad, Provincia) VALUES( '"
                   + oLocalidad.Localidad + "' , " + oLocalidad.Provincia + ")";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }
        // PUT: api/Localidades/5
        public void Put(int id, [FromBody] Models.Localidades oLocalidad)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Localidades SET Localidad = '"
                   + oLocalidad.Localidad + "', Provincia = " + oLocalidad.Provincia + " WHERE  Id_Localidad = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }


        // DELETE: api/Localidades/5

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

             using (SqlConnection conector = new SqlConnection(cadena))
             {
                 conector.Open();
                  SqlCommand comando = new SqlCommand("DELETE FROM Localidades WHERE Id_Localidad = " + id, conector);
                  comando.ExecuteNonQuery();
             }
             return Ok();
        
        }
    }
}
