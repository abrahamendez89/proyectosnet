using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class AuxiliarCuentasCuentaDetalle
    {
        public static String Formato;

        public DateTime Fecha { get; set; }
        public String NumUnIdenPol { get; set; }
        public String Concepto { get; set; }
        public double Debe { get; set; }
        public double Haber { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@Fecha", Herramientas.Conversiones.Formatos.DateTimeAFechaPolizaSAT(Fecha));
            xmlFinal = xmlFinal.Replace("@NumUnIdenPol", NumUnIdenPol);
            xmlFinal = xmlFinal.Replace("@Concepto", Validaciones.RemplazarCaracteresEspeciales(Concepto));
            xmlFinal = xmlFinal.Replace("@Debe", Debe.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Haber", Haber.ToString("0.0000"));

            return xmlFinal;

        }
    }
}
