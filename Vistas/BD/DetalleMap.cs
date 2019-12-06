using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vistas.Models;

namespace Vistas.BD
{
    public class DetalleMap : EntityTypeConfiguration<Detalle>{
        public DetalleMap()
        {
            ToTable("Detalle");
            HasKey(o => o.Id);
            HasRequired(o => o.Servicio).WithMany().HasForeignKey(o => o.IdServicio);           
            HasRequired(o => o.Pago).WithMany().HasForeignKey(o => o.Pago_Id);

        }
        }

}
