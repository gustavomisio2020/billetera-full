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

    public class AgendaController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Agenda
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Agenda", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/Agenda/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string comentario = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Comentario FROM Agenda WHERE Id_Agenda = " + id, conector);
                comentario = comando.ExecuteScalar().ToString();
            }
            return comentario;
        }

        // POST: api/Agenda
        public void Post([FromBody] Models.Agenda oAgenda)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Agenda (Cuenta_prop, Cuenta_agendada, Comentario) VALUES( "
                   + oAgenda.Cuenta_prop + " , " + oAgenda.Cuenta_agendada + " , '" + oAgenda.Comentario + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/Agenda/5
        public void Put(int id, [FromBody] Models.Agenda oAgenda)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Agenda SET Cuenta_prop = "
                   + oAgenda.Cuenta_prop + ", Cuenta_agendada = " + oAgenda.Cuenta_agendada + ", Comentario = '"
                    + oAgenda.Comentario + "' WHERE Id_Agenda = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Agenda/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Agenda WHERE Id_Agenda = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}
