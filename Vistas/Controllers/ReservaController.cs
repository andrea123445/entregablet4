using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vistas.Models;

namespace Vistas.Controllers
{
    public class ReservaController : Controller
    {
        public ReservaController()
        {

        }
        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {

            return View();
        }

        public ActionResult Crear(Reserva reserva)
        {

            return View();
        }



    }
}