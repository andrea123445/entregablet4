using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vistas.Models;

namespace Vistas.BD
{
    public class PagoMap : EntityTypeConfiguration<Pago>{
        public PagoMap(){
            ToTable("Pago");
            HasKey(o => o.Id);
            HasRequired(o => o.Usuario).WithMany().HasForeignKey(o => o.IdUsuario);           
        }
    }
}