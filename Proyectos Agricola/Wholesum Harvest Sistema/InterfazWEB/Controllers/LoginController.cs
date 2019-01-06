using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio;
using LogicaNegocios.Sistema;
using Dominio.Sistema;
using Herramientas.ORM;
using Herramientas.SQL;
using InterfazWEB.Clases;

namespace InterfazWEB.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpPost]
        public JsonResult Acceso(_sis_Usuario usuarioLogin)
        {
            ManejadorDB.TipoSQLDefault = typeof(SQLServer);
            ManejadorDB.CadenaConexionDefault = "data source = @SERVIDOR; initial catalog = @BASEDATOS; user id = @USUARIO; password = @CONTRASENA";
            ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@SERVIDOR", "192.168.140.126\\crop");
            ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@BASEDATOS", "ProgramaSiembra");
            ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@USUARIO", "sa");
            ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@CONTRASENA", "1@TCE123");


            sis_ln_Login ln = new sis_ln_Login();
            _sis_Usuario usuario = ln.ValidarAcceso(usuarioLogin.Cuenta, usuarioLogin.Contrasena);
            _sis_Rol rol =  usuario.RolSistema;
            if (usuario == null)
                return Json(new ResultadoPeticion() { Codigo = "100", FueError = true, Descripcion = "Usuario o contraseña Incorrecto" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new ResultadoPeticion() { Codigo = "100", FueError = false, Descripcion = "Usuario correcto", Datos = usuario}, JsonRequestBehavior.AllowGet);
        }

    }
}
