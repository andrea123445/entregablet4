using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vistas.BD;
using Vistas.Models;

namespace Vistas.Controllers
{
    public class ServicioCRUDController : Controller
    {
        public App context;
        public ServicioCRUDController(){
            context = new App();
        }
        public ActionResult Lista(){
            var datos = new List<Servicio>();
            datos = context.Servicios.ToList();
            return View(datos);
        }
        [HttpGet]
        public ActionResult Agregar(){
            return View(new Servicio());
        }
        [HttpPost]
        public ActionResult Agregar(Servicio servicio)
        {
            Validar(servicio);
            if (ModelState.IsValid)
            {
                context.Servicios.Add(servicio);
                context.SaveChanges();
                return RedirectToAction("Lista");
            }
            return View(servicio);
        }

        public void Validar(Servicio servicio)
        {
            if (string.IsNullOrEmpty(servicio.Nombre))
                ModelState.AddModelError("nombres", "El campo es obligatorio");
            if (servicio.Precio== null|| servicio.Precio<=0)
                ModelState.AddModelError("Precio", "campo invalido");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var servicio = context.Servicios.Where(o => o.Id == id).First();
            return View(servicio);
        }
        [HttpPost]
        public ActionResult Editar(int id, Servicio ser)
        {
            var personaDb = context.Servicios.Where(o => o.Id == id).First();
            Validar(ser);
            if (ModelState.IsValid)
            {
                personaDb.Id = ser.Id;
                personaDb.Nombre = ser.Nombre;
                personaDb.Precio = ser.Precio;
                personaDb.Informacion = ser.Informacion;
                context.SaveChanges();
                return RedirectToAction("Lista");
            }
            return View(ser);
        }
        public ActionResult Eliminar(int id)
        {
            var servicio = context.Servicios.Where(o => o.Id == id).First();
            context.Servicios.Remove(servicio);
            context.SaveChanges();
            return RedirectToAction("Lista");
        }
    }
}