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

    public class OperacionesController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Operaciones
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Operaciones", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

        // POST: api/Operaciones
        public void Post([FromBody] Models.Operaciones oOperacion)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Operaciones (Usuario, Tipo_operacion, FechayHora, Origen_deposito, Destino_extraccion, Cta_origen, Cta_destino, Monto, Comision) VALUES( "
                   + oOperacion.Usuario +" , " + oOperacion.Tipo_operacion + " , '" + oOperacion.FechayHora + "', " + oOperacion.Origen_deposito + " , "
                   + oOperacion.Destino_extraccion + ", " + oOperacion.Cta_origen + ", " + oOperacion.Cta_destino + " , " + oOperacion.Monto.ToString().Replace(",", ".") + " , " + oOperacion.Comision + ")";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }
        }

        // PUT: api/Operaciones/5
        public void Put(int id, [FromBody] Models.Operaciones oOperacion)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Operaciones SET Usuario = "
                   + oOperacion.Usuario + ", Tipo_operacion = " + oOperacion.Tipo_operacion + ", FechayHora = '"
                    + oOperacion.FechayHora + "', Origen_deposito = " + oOperacion.Origen_deposito + ", Destino_extraccion = " + oOperacion.Destino_extraccion + ", Cta_origen = "
                    + oOperacion.Cta_origen + ", Cta_destino = " + oOperacion.Cta_destino + ", Monto = " + oOperacion.Monto.ToString().Replace(",", ".") + ", Comision = "
                    + oOperacion.Comision + "  WHERE  Id_Operacion = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Operaciones/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Operaciones WHERE Id_Operacion = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}
