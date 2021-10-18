using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Operaciones
    {
        public int Usuario { get; set; }

        public int Tipo_operacion { get; set; }

        public DateTime FechayHora { get; set; }

        public int Origen_deposito { get; set; }

        public int Destino_extraccion { get; set; }

        public int Cta_origen { get; set; }

        public int Cta_destino { get; set; }

        public decimal Monto { get; set; }

        public int Comision { get; set; }

    }
}