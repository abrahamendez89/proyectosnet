using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ACCESO_DATOS.Manejador;
using ACCESO_DATOS.Mapeo.Oracle;
using ACCESO_DATOS.Conexiones;
using UTILERIASERP.Utilerias.API;
using System.Web.Configuration;

namespace CustomFiltersMVC
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            try
            {
                PeticionAPI peticion = Seguridad.ValidarPeticion<PeticionAPI>(actionContext.ActionArguments["value"].ToString());
                
                String csmodel_ado = WebConfigurationManager.AppSettings["csmodel_ado"];
                String csmodel_ambiente_ado = WebConfigurationManager.AppSettings["csmodel_ambiente_ado"];

                if (csmodel_ado == null)
                {
                    throw new Exception("No está definido 'csmodel_ado' en web.config");
                }
                if (csmodel_ambiente_ado == null)
                {
                    throw new Exception("No está definido 'csmodel_ambiente_ado' en web.config");
                }
                
                if(csmodel_ambiente_ado.ToLower().Equals("debug"))
                {
                    ManejadorInstanciasBD.ZMX_AmbienteAPI = ManejadorInstanciasBD.Ambiente.Desarrollo;
                }
                else if (csmodel_ambiente_ado.ToLower().Equals("desarrollo"))
                {
                    ManejadorInstanciasBD.ZMX_AmbienteAPI = ManejadorInstanciasBD.Ambiente.Desarrollo;
                }
                else if (csmodel_ambiente_ado.ToLower().Equals("pruebas"))
                {
                    ManejadorInstanciasBD.ZMX_AmbienteAPI = ManejadorInstanciasBD.Ambiente.Desarrollo;
                }
                else if (csmodel_ambiente_ado.ToLower().Equals("preproduccion"))
                {
                    ManejadorInstanciasBD.ZMX_AmbienteAPI = ManejadorInstanciasBD.Ambiente.Desarrollo;
                }
                else if (csmodel_ambiente_ado.ToLower().Equals("produccion"))
                {
                    ManejadorInstanciasBD.ZMX_AmbienteAPI = ManejadorInstanciasBD.Ambiente.Desarrollo;
                }
                else
                {
                    ManejadorInstanciasBD.ZMX_AmbienteAPI = ManejadorInstanciasBD.Ambiente.NoDefinido;
                }
                ManejadorInstanciasBD.ZMX_Ambiente = peticion.Sesion.Ambiente;
                ManejadorInstanciasBD.ZMX_Usuario = peticion.Sesion.Usuario;
                ManejadorInstanciasBD.ZMX_SetClienteConexion(ACCESO_DATOS.Conexiones.ClienteConfig.ClientesBD.Oracle, new OracleMapeoInsert(), new OracleMapeoSelect(), new OracleMapeoUpdate(),SeguridadCAF.DesencriptarAES(csmodel_ado, "!234#3a@%%_=?'"));
                
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo realizar la conexión.", ex);
            }
        }
    }
}
