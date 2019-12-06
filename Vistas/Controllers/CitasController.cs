using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vistas.BD;
using Vistas.Models;

namespace Vistas.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        App context;

        public CitasController(){
            context = new App();
        }

        [HttpGet]
        public ActionResult Index(){
            ViewBag.Encargado = context.Encargados.ToList();
            ViewBag.Servicio = context.Servicios.ToList();
            ViewBag.Horarios = context.Horarios.Include(o => o.Encargado);
            List<String> Horarios = new List<string>();            
            return View();
        }

        [HttpPost]
        public ActionResult GuardarReserva(Reserva Reserva, string MetodoPago){
            ViewBag.Encargado = context.Encargados.ToList();
            ViewBag.Servicio = context.Servicios.ToList();
            ViewBag.Horarios = context.Horarios.Include(o => o.Encargado);

            Reserva.Detalle.IdServicio = Reserva.IdServicio;
            Reserva.Detalle.costo = Costo(Reserva.IdServicio);
            Reserva.Detalle.Duracion = Duracion(Reserva.IdServicio);
            var HorarioAfectado = context.Horarios.Where(o => o.EncargadoId == Reserva.IdEncargado && o.Horas == Reserva.HoraInicio && o.Fecha == Reserva.Fecha).FirstOrDefault();
            if (HorarioAfectado.Disponibilidad == false)
            {
                return View("Index");
            }
            HorarioAfectado.Disponibilidad = false;
            context.Reservas.Add(Reserva);  

            context.SaveChanges();
            return RedirectToAction("Index", "Panel");
        }

        public string Duracion(int Id) {
            var servicio = context.Servicios.Where(o => o.Id == Id).FirstOrDefault();
            return (servicio.Informacion);
        }

        public float Costo(int Id){
            var servicio = context.Servicios.Where(o => o.Id == Id).FirstOrDefault();
            return ((int)servicio.Precio);
        }

        public ActionResult Lista(){
            ViewBag.Encargado = context.Encargados.ToList();
            ViewBag.Servicio = context.Servicios.ToList();
            ViewBag.Horarios = context.Horarios.Include(o => o.Encargado);
            List<String> Horarios = new List<string>();
            return View();
        }
        public ViewResult Costo2(int id){
            var horario= context.Horarios.Where(o => o.EncargadoId == id).ToList();
            return View(horario);
        }

    }
}