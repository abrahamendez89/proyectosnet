using Prueba2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Prueba2.Controllers
{
    public class IngresarController : Controller
    {
        //
        // GET: /Ingresar/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Ingresar(_Usuario usuario)
        {
            try
            {
                if (usuario.Usuario.Trim().Equals("abraham") && usuario.Contra.Trim().Equals("123"))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return Json("error",JsonRequestBehavior.AllowGet);
                throw;
            }
           
        }
    }
}
