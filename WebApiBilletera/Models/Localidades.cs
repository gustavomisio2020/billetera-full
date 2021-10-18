using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Localidades
    {
        public int Id_Localidad { get; set; }

        public string Localidad { get; set; }

        public int Provincia { get; set; }

    }
}