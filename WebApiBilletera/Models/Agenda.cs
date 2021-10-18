using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Agenda
    {
        public int Id_Agenda { get; set; }

        public int Cuenta_prop { get; set; }

        public int Cuenta_agendada { get; set; }

        public string Comentario { get; set; }
    }
}