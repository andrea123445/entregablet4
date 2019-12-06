using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vistas.Models;

namespace Vistas.BD
{
    public class ServicioMap : EntityTypeConfiguration<Servicio>{
        public ServicioMap(){
            ToTable("Servicio");
            HasKey(o => o.Id);
        }
    }
}