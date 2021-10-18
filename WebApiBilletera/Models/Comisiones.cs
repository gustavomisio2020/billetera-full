using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Comisiones
    {
        public int Id_Comision { get; set; }

        public int Operacion { get; set; }

        public DateTime fecha_comision { get; set; }

        public decimal Comision { get; set; }

    }
}