using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vistas.BD;
using Vistas.Models;

namespace Vistas.Controllers
{
    public class LoginController : Controller
    {
        public App context;

        public LoginController()
        {
            context = new App();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User usuario)
        {
            var usuarioLog = context.Users.Where(o => o.username == usuario.username).FirstOrDefault();
            if (!string.IsNullOrEmpty(usuario.username)) {
                if (usuario.password == usuarioLog.password)
                {
                    Session["usuario"] = usuarioLog;
                    FormsAuthentication.SetAuthCookie(usuario.username, false);
                    return RedirectToAction("Index", "Panel");
                }
            }
            ViewBag.Conexion = "usuario y/o contraseña invalidos";
            return View("Index");
        }

       
        public ActionResult Recover()
        {
            
            return View();
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }

    }
}