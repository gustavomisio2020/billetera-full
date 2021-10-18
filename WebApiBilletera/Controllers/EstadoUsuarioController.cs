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

    public class EstadoUsuarioController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;


        // GET: api/EstadoUsuario
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Estados_Usuarios", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/EstadoUsuario/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string estado = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Estado FROM Estados_Usuarios WHERE Id_Estado = " + id, conector);
                estado = comando.ExecuteScalar().ToString();
            }
            return estado;
        }

        // POST: api/EstadoUsuario
        public void Post([FromBody] Models.EstadoUsuario oEstado)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Estados_Usuarios (Estado) VALUES( '"
                   + oEstado.Estado + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/EstadoUsuario/5
        public void Put(int id, [FromBody] Models.EstadoUsuario oEstado)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Estados_Usuarios SET Estado = '"
                   + oEstado.Estado + "' WHERE  Id_Estado = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/EstadoUsuario/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Estados_Usuarios WHERE Id_Estado = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();

        }
    }
}
