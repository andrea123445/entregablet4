using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

        public User User { get; set; }
        public int IdUser { get; set; }

        public Encargado Encargado { get; set; }
        public int IdEncargado { get; set; }
        public DateTime Fecha { get; set; }
        public Servicio Servicio { get; set; }
        public int IdServicio { get; set; }
        public int Dia { get; set; }

        public int DetalleId { get; set; }
        public Detalle Detalle { get; set; }


    }
}