using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
namespace Vistas.Controllers
{
    public class AyudaController : Controller
    {
       [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string asunto,string mensaje)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("andrea.vegas.torres@gmail.com");
                correo.To.Add("qmonadastore@gmail.com");
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                string sCuentaCorreo = "andrea.vegas.torres@gmail.com";
                string sPassword = "t2o4i6xd8";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPassword);
                smtp.Send(correo);
                ViewBag.Mensaje = "Mensaje enviado correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }
    }
}