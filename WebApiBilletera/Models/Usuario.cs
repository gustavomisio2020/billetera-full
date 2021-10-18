using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiBilletera.Models
{
    public class Usuario
    {
        public int ID_usuario { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
     
        public string Clave { get; set; }
     
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }

        public string Telefono { get; set; }

        public int Localidad { get; set; }

        public int TipoUsuario { get; set; }

        public int Estado { get; set; }

        public DateTime Fecha_Alta { get; set; }

        public DateTime Fecha_Nac { get; set; }

     












    }
}