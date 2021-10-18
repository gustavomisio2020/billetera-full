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

    public class TipoUsuariosController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/TipoUsuarios
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Tipos_Usuarios", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }
        // GET: api/TipoUsuarios/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string estado = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Tipo_Usuario FROM Tipos_Usuarios WHERE Id_TipoUsuario = " + id, conector);
                estado = comando.ExecuteScalar().ToString();
            }
            return estado;
        }


        // POST: api/TipoUsuarios
        public void Post([FromBody] Models.TipoUsuarios oTipo)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Tipos_Usuarios (Tipo_Usuario) VALUES( '"
                   + oTipo.Tipo_Usuario + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/TipoUsuarios/5
        public void Put(int id, [FromBody] Models.TipoUsuarios oTipo)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Tipos_Usuarios SET Tipo_Usuario = '"
                   + oTipo.Tipo_Usuario + "' WHERE  Id_TipoUsuario = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }


        // DELETE: api/TipoUsuarios/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Tipos_Usuarios WHERE Id_TipoUsuario = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();

        }
    }
}
