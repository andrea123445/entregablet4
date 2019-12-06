using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vistas.Models;

namespace Vistas.BD
{
    public class EncargadoMap : EntityTypeConfiguration<Encargado>{
        public EncargadoMap(){
            ToTable("Encargado");
            HasKey(o => o.Id);


        }
    }
}