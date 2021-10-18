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

    public class CuentasController : ApiController
    {
        string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

        // GET: api/Cuentas
        [HttpGet]
        public IHttpActionResult Get()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Cuentas", conector);
                adaptador.Fill(dt);
            }
            return Ok(dt);
        }
        // GET: api/Cuentas/5
        public string Get(int id)
        {
            DataTable dt = new DataTable();
            string CVU = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT CVU FROM cuentas WHERE Id_Cuenta = " + id, conector);
                CVU = comando.ExecuteScalar().ToString();
            }
            return CVU;
        }
        //POST: api/Cuentas
        public void Post([FromBody] Models.Cuenta oCuenta)

        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "INSERT INTO Cuentas (Usuario, CVU, Alias_CVU, Moneda, Saldo) VALUES( "
                   + oCuenta.Usuario + " , '" + oCuenta.CVU + "' , '"
                    + oCuenta.Alias_CVU + "' , " + oCuenta.Moneda + " , " + oCuenta.Saldo + ")";

                comando.Connection = conector;

                comando.ExecuteNonQuery();
            }

        }





        //PUT: api/Cuentas/5
        public void Put(int id, [FromBody] Models.Cuenta oCuenta)
         {

            using (SqlConnection conector = new SqlConnection(cadena))
           {
              conector.Open();
               SqlCommand comando = new SqlCommand();
               comando.CommandText = "UPDATE cuentas SET CVU = '" + oCuenta.CVU + "', Usuario= " + oCuenta.Usuario + ", Alias_CVU = '"
                  + oCuenta.Alias_CVU + "', Moneda = " + oCuenta.Moneda + " , Saldo = " + oCuenta.Saldo + " WHERE  Id_Cuenta = " + id;

              comando.Connection = conector;

               comando.ExecuteNonQuery();
            }


         }

        //DELETE: api/Cuentas/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("DELETE FROM Cuentas WHERE Id_Cuenta = " + id, conector);
                comando.ExecuteNonQuery();
            }
            return Ok();
        }




    }
}
