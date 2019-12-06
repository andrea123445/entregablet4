using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Pago {
        public int Id { get; set; }

        public User Usuario { get; set; }
        public int IdUsuario { get; set; } 
       
        public string metodoPago { get; set; }
    }
}