using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Sistema;

namespace Controladores.Sistema
{
    public class LicenciaController
    {
        ModulosSistemaController modulosController = new ModulosSistemaController();
        public Boolean ValidarLicencia()
        {
            //objeto licencia que usariamos en el sistema cliente y en el sistema validador
            sis_Licencia licencia = new sis_Licencia();
            licencia.IDLicencia = 100;
            licencia.NombreEmpresa = "empresa fulanita";
            licencia.RFC = "RFC";
            licencia.Telefono = "7454019";
            licencia.PaqueteComprado = "#01";
            licencia.Vigencia = new DateTime(2016, 12, 1);
            licencia.ModulosPermitidos = new List<string>();
            licencia.ModulosPermitidos.Add("$01");
            licencia.ModulosPermitidos.Add("$02");
            //se convertira a json para poderlo cifrar
            String json = Herramientas.Web.JSON.ConvertirObjetoAJSON<sis_Licencia>(licencia);
            //se cifrara y sera guardado en el archivo .key
            String cifrado = Herramientas.Cifrado.CifradoAES.EncriptarTexto(json);
            //el archivo .key se va a descifrar en el webservice para modificar los parametros
            String jsonC = Herramientas.Cifrado.CifradoAES.DesencriptarTexto(cifrado);
            //se va a obtener la licencia nuevamente modificar los valores y se encriptara de nuevo.
            sis_Licencia licencia2 = Herramientas.Web.JSON.ConvertirJSONAObjeto<sis_Licencia>(jsonC);


            Dictionary<String, List<String>> modulosComprados = modulosController.CargarModulosDisponiblesDeAcuerdoLicenciaParaSeleccion(licencia);



            if (licencia.Vigencia >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
