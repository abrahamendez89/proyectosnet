using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Dominio.Sistema;
using Dominio;
using LogicaNegocios.Sistema;
using Herramientas.Web;

namespace ServiciosWeb
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ws_login : System.Web.Services.WebService
    {
        sis_ln_Login login = new sis_ln_Login();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public String ValidarAcceso(String usuario, String pass)
        {
            login.enviarMensaje += login_enviarMensaje;
            _sis_Usuario usr = login.ValidarAcceso(usuario, pass);

            if (usr != null)
            {
                JSON json = new JSON(usr, 2);
                _sis_Rol rol = usr.RolSistema;
                return json.ObtenerJSON();
            }
            else
                return mensajes;
        }
        String mensajes = "";
        bool login_enviarMensaje(Exception exception, string mensaje, string titulo, LogicaNegocios.MensajeException.TipoMensaje tipoMensaje)
        {
            mensajes += "\n"+mensaje;
            return false;
        }
    }
}