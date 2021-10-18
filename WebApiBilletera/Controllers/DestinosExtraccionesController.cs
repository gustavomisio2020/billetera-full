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

    public class DestinosExtraccionesController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/DestinosExtracciones
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Destinos_extracciones", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/DestinosExtracciones/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string destino = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Destino FROM Destinos_extracciones WHERE ID_Destino = " + id, conector);
                destino = comando.ExecuteScalar().ToString();
            }
            return destino;
        }

        // POST: api/DestinosExtracciones
        public void Post([FromBody] Models.DestinosExtracciones oDestino)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Destinos_extracciones (Destino) VALUES( '"
                   + oDestino.Destino + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/DestinosExtracciones/5
        public void Put(int id, [FromBody] Models.DestinosExtracciones oDestino)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Destinos_extracciones SET Destino = '" + oDestino.Destino + "' WHERE  ID_Destino = " + id;

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }


        }

        // DELETE: api/DestinosExtracciones/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Destinos_extracciones WHERE ID_Destino = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}
