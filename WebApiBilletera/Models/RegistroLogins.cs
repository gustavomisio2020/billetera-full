using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class RegistroLogins
    {
        public int Id_Registro { get; set; }

        public int Usuario { get; set; }

        public DateTime FechayHora { get; set; }

        public int Resultado { get; set; }

        public string IP { get; set; }

        public string Localizacion { get; set; }
    }
}