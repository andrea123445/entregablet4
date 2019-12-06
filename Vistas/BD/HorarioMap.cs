using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Vistas.Models;

namespace Vistas.BD
{
    public class HorarioMap : EntityTypeConfiguration<Horario>
    {
        public HorarioMap()
        {
            ToTable("Horario");
            HasKey(o => o.Id);
            HasRequired(o => o.Encargado).WithMany(o =>o.Horario).HasForeignKey(o => o.EncargadoId);
        }
    }
}