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
    internal static class Buscarclave {

        
        public static string BuscarClaves (string UsrName)
        {

            string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;

            string clave = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();
                SqlCommand comando = new SqlCommand("SELECT Clave FROM usuarios WHERE UserName = '" + UsrName + "'", conector);
                clave = comando.ExecuteScalar().ToString();
                //idusr = Convert.ToInt32(dt.Rows[0]["ID_usuario"]);

            }

            return clave;

        }



        public static string BuscarUsuario(string UsrName)
        {

            string cadena = ConfigurationManager.ConnectionStrings["MiCadena"].ConnectionString;



            string usr = "";
            using (SqlConnection conector = new SqlConnection(cadena))
            {
                conector.Open();

                SqlCommand comando = new SqlCommand("SELECT count(*) FROM usuarios WHERE UserName = '" + UsrName + "'", conector);
                int count = (int)comando.ExecuteScalar();
                
                //string resultado = comando.ExecuteScalar().ToString();
                if (count == 0)
                {

                    usr = "usernotfound";

                }
                else
                {

                    usr = "userfound";

                }

            }

            return usr;

        }



    }

}