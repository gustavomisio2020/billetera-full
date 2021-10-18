using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http.Cors;

namespace WebApiBilletera.Controllers
{
    [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]

    public class UsuariosController : ApiController
    {

        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;
        
        
        // GET: api/Usuarios
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM usuarios", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // GET: api/Usuarios/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string nombre = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {  
                conector.Open();
                SqlCommand comando = new SqlCommand ("SELECT Nombre FROM usuarios WHERE ID_usuario = " + id, conector);
                nombre = comando.ExecuteScalar().ToString();
            }
            return nombre;
        }

        //POST: api/Usuarios                             
        public void Post([FromBody] Models.Usuario oUsuario) 
                                                               
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Usuarios (Username, Email, Clave, Nombre, Apellido, DNI, Telefono, Localidad, Estado, TipoUsuario, Fecha_Nac) VALUES( '"
                   + oUsuario.UserName + "' , '" + oUsuario.Email + "' , '"
                    + oUsuario.Clave + "' , '" + oUsuario.Nombre + "' , '" + oUsuario.Apellido + "' , "
                    + oUsuario.DNI + " , '" + oUsuario.Telefono + "' , '" + oUsuario.Localidad + "' ,  " + oUsuario.Estado + " ,  " + oUsuario.TipoUsuario + " , '" + oUsuario.Fecha_Nac.ToShortDateString() + "')";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }
          
        }


        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody] Models.Usuario oUsuario)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Usuarios SET Username = '"
                   + oUsuario.UserName + "', Email = '" + oUsuario.Email + "', Clave = '"
                    + oUsuario.Clave + "', Nombre = '" + oUsuario.Nombre + "', Apellido = '" + oUsuario.Apellido + "', DNI = "
                    + oUsuario.DNI + ", Telefono = '" + oUsuario.Telefono + "', Localidad = '" + oUsuario.Localidad + "', Estado = "
                    + oUsuario.Estado + ", TipoUsuario = " + oUsuario.TipoUsuario + " , Fecha_Alta =  '" + oUsuario.Fecha_Alta + "', Fecha_Nac = '" + oUsuario.Fecha_Nac + "'  WHERE  ID_usuario = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }


        // DELETE: api/Usuarios/5

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
                using (SqlConnection conector = new SqlConnection(cadena))
                {
                    conector.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM Usuarios WHERE ID_usuario = " + id, conector);
                    comando.ExecuteNonQuery();
                }
                return Ok();
        }


    }
}
