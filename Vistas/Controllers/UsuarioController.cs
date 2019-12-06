using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Vistas.BD;
using Vistas.Models;

namespace Vistas.Controllers
{
    public class UsuarioController : Controller
    {
        public App context;
        public UsuarioController()
        {
            context = new App();
        }
        public ActionResult Lista()
        {
            var datos = new List<Encargado>();
            datos = context.Encargados.ToList();
            return View(datos);
        }
        [HttpGet]
        public ActionResult Agregar()
        {
            return View(new Encargado());
        }
        [HttpPost]
        public ActionResult Agregar(Encargado encargado)
        {
            Validar(encargado);
            if (ModelState.IsValid)
            {
                context.Encargados.Add(encargado);
                context.SaveChanges();
                return RedirectToAction("Lista");
            }
            return View(encargado);
        }

        public void Validar(Encargado encargado)
        {
            if (string.IsNullOrEmpty(encargado.nombres))
                ModelState.AddModelError("nombres", "El campo es obligatorio");
            if (string.IsNullOrEmpty(encargado.apellidos))
                ModelState.AddModelError("apellidos", "El campo es obligatorio");
            if (encargado.celular == null)
                ModelState.AddModelError("celular", "El campo es obligatorio");
            if (string.IsNullOrEmpty(encargado.correo))
            {
                ModelState.AddModelError("Email vacio", "Email vacio");
            }
            else if (EmailIsValid(encargado.correo) == false)
                ModelState.AddModelError("Email", "Email no valido");

        }
        public static bool EmailIsValid(string email)
        {
            string expression = @"\A(\w+\.?\w*\@\w+\.)(com)\Z";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var encargado = context.Encargados.Where(o => o.Id == id).First();
            return View(encargado);
        }
        [HttpPost]
        public ActionResult Editar(int id, Encargado encar)
        {
            var personaDb = context.Encargados.Where(o => o.Id == id).First();
            Validar(encar);
            if (ModelState.IsValid)
            {
                personaDb.Id = encar.Id;
                personaDb.nombres = encar.nombres;
                personaDb.apellidos = encar.apellidos;
                personaDb.correo = encar.correo;
                personaDb.celular = encar.celular;
                personaDb.cargo = encar.cargo;
                context.SaveChanges();
                return RedirectToAction("Lista");
            }
            return View(encar);
        }
        public ActionResult Eliminar(int id)
        {
            var encargado = context.Encargados.Where(o => o.Id == id).First();
            context.Encargados.Remove(encargado);
            context.SaveChanges();
            return RedirectToAction("Lista");
        }

        public ActionResult MisReservas(int Id)
        {
            var Reservas = context.Reservas.Where(o => o.IdUser == Id).Include(o =>o.Encargado).Include(o =>o.Servicio).Include(o => o.Detalle);
            return View(Reservas);
        }
    }
}