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

    public class ComisionesController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Comisiones
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Comisiones", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }
        //POST: api/Comisiones/5
        public void Post([FromBody] Models.Comisiones oComision)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Comisiones (Operacion, fecha_comision, Comision) VALUES( "
                   + oComision.Operacion + " , '" + oComision.fecha_comision + "' , "
                    + oComision.Comision.ToString().Replace(",", ".") + " )";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }



        // PUT: api/Comisiones/5
        public void Put(int id, [FromBody] Models.Comisiones oComision)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Comisiones SET fecha_comision = '" + oComision.fecha_comision + "', Comision = "
                    + oComision.Comision.ToString().Replace(",", ".") + "  WHERE Id_Comision = " + id;
                comando.Connection = conector;
                comando.ExecuteNonQuery();
            }
        }

        // DELETE: api/Comisiones/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Comisiones WHERE Id_Comision = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }




    }
}