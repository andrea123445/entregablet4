using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vistas.Models;

namespace Vistas.BD
{
    public class App : DbContext {
        public IDbSet<User> Users { get; set; }
        public IDbSet<Detalle> Detalles { get; set; }
        public IDbSet<Encargado> Encargados { get; set; }
        public IDbSet<Pago> Pagos { get; set; }
        public IDbSet<Servicio> Servicios { get; set; }
        public IDbSet<Reserva> Reservas { get; set; }
        public IDbSet<Horario> Horarios { get; set; }
        public IDbSet<Day> Dias { get; set; }

        //public App()
        //{
        //    Database.SetInitializer<App>(null);
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new DetalleMap());
            modelBuilder.Configurations.Add(new EncargadoMap());
            modelBuilder.Configurations.Add(new PagoMap());
            modelBuilder.Configurations.Add(new ServicioMap());
            modelBuilder.Configurations.Add(new ReservaMap());
            modelBuilder.Configurations.Add(new DayMap());
            modelBuilder.Configurations.Add(new HorarioMap());
        }
    }
}