using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Cuenta
    {
        public int Id_Cuenta { get; set; }

        public int Usuario { get; set; }

        public string CVU { get; set; }

        public string Alias_CVU { get; set; }

        public int Moneda { get; set; }

        public decimal Saldo { get; set; }



    }
}