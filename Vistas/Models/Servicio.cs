using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Servicio{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }
        public string Informacion { get; set; }
            
    }
}