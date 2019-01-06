using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TallerWeb.Controllers
{
    public class CatalogoPruebaController : Controller
    {
        //
        // GET: /CataologoPrueba/
        [HttpGet]
        public JsonResult Todos()
        {
            _CatalogoPrueba emp1 = new _CatalogoPrueba();
            emp1.Nombre = "abraham";
            emp1.Edad = 26;

            _CatalogoPrueba emp2 = new _CatalogoPrueba();
            emp2.Nombre = "alfredo";
            emp2.Edad = 32;

            _CatalogoPrueba emp3 = new _CatalogoPrueba();
            emp3.Nombre = "said";
            emp3.Edad = 32;

            List<_CatalogoPrueba> empleados = new List<_CatalogoPrueba>();
            empleados.Add(emp1);
            empleados.Add(emp2);
            empleados.Add(emp3);

            return Json(empleados, JsonRequestBehavior.AllowGet);

        }

    }
}
