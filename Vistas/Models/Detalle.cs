using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Detalle{
        public int Id { get; set; }

        public Servicio Servicio { get; set; }
        public int IdServicio { get; set; }

        public Pago Pago { get; set; }
        public int Pago_Id { get; set; }
        public float costo { get; set; }
        public string Duracion { get; set; }



    }
}