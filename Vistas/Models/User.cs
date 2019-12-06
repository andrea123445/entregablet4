using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistas.Models
{
    public class User
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
    }
}