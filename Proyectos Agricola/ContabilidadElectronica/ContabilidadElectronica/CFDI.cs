using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContabilidadElectronica.Validador_CFDI;

namespace ContabilidadElectronica
{
    public class CFDI
    {
        public static String ObtenerEstatusCFDI(String rfcEmisor, String rfcReceptor, double montoTotal, String uuid)
        {
            Validador_CFDI.ConsultaCFDIServiceClient con = new ConsultaCFDIServiceClient();

            /*
             * Parámetros: expresionImpresa, 
             * Cadena que contiene los parámetros de consulta: 
             * re = rfc Emisor, 
             * rr = RFC Receptor y 
             * id= UUDI, la cadena puede variar dependiendo del lenguaje, en el caso de C# la cadena a enviar es:
             */

            String cadena = "?re=" + rfcEmisor + "&rr=" + rfcReceptor + "&tt=" + montoTotal.ToString() + "&id=" + uuid;
            Acuse acuse = con.Consulta(cadena);
            con.Close();
            return acuse.Estado;
        }
    }
}
