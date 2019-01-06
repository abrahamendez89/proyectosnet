using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TallerWeb.Controllers
{
    public class UsuarioController : Controller
    {
        //servidor/Usuario
        // Vista para ingresar a la aplicación
        public ActionResult Ingresar()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(_Usuario usuario)
        {

            if (usuario.St_Usuario == "abraham" && usuario.St_Password == "123")
                return Json(true);
            else
                return Json(false);

        }
    }
}
