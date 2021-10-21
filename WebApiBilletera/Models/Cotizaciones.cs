using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Cotizaciones
    {
        public int Id_Cotizacion { get; set; }

        public int Moneda { get; set; }

        public DateTime Fecha_cotizacion { get; set; }

        public decimal Cotizacion { get; set; }

    }


}