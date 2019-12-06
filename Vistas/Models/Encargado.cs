using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Encargado{
        public int Id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string cargo { get; set; }
        public List<Horario> Horario { get; set; }
        
    }
}