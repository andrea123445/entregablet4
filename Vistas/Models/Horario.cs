using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Horario
    {
        public int Id { get; set; }
        
        public Encargado Encargado { get; set; }
        public int EncargadoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Horas { get; set; }
        public bool Disponibilidad { get; set; }
    }
}