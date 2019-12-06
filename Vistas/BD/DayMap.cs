using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Vistas.Models;

namespace Vistas.BD
{
    public class DayMap : EntityTypeConfiguration<Day>
    {
        public DayMap()
        {
            ToTable("Day");
            HasKey(o => o.Id);
        }
    }
}