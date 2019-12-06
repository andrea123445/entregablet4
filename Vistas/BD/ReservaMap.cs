using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Vistas.Models;

namespace Vistas.BD
{
    public class ReservaMap : EntityTypeConfiguration<Reserva>
    {
        public ReservaMap()
        {
            ToTable("Reserva");
            HasKey(o => o.Id);
            HasRequired(o => o.Servicio).WithMany().HasForeignKey(o => o.IdServicio);
            HasRequired(o => o.Encargado).WithMany().HasForeignKey(o => o.IdEncargado);
            HasRequired(o => o.User).WithMany().HasForeignKey(o => o.IdUser);
            HasRequired(o => o.Detalle).WithMany().HasForeignKey(o => o.DetalleId);

        }
    }
}