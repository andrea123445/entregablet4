using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class Day
    {
        public int Id { get; set; }
        public int Dia { get; set; }        
        public int Horarioid { get; set; }
        public int EmpleadoId { get; set; }
    }
}