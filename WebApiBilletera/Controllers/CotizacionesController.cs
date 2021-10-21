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

    public class CotizacionesController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Cotizaciones
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Cotizaciones", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }

     

        // POST: api/Cotizaciones
        public void Post([FromBody] Models.Cotizaciones oCotizacion)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Cotizaciones (Moneda, Cotizacion) VALUES( "
                   + oCotizacion.Moneda + " , " + oCotizacion.Cotizacion.ToString().Replace("," , ".") + " )";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }

        // PUT: api/Cotizaciones/5
        public void Put(int id, [FromBody] Models.Cotizaciones oCotizacion)
        {

            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "UPDATE Cotizaciones SET Moneda = " + oCotizacion.Moneda + ", Fecha_cotizacion = '" 
                    + oCotizacion.Fecha_cotizacion + "', Cotizacion = "
                   + oCotizacion.Cotizacion.ToString().Replace(",", ".") + " WHERE  Id_Cotizacion = " + id;

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }


        }

        // DELETE: api/Cotizaciones/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Cotizaciones WHERE Id_Cotizacion = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }

    }
}
