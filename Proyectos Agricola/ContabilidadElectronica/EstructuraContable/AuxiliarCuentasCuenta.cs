using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class AuxiliarCuentasCuenta
    {
        public static String Formato;

        public String NumCta { get; set; }
        public String DesCta { get; set; }
        public double SaldoIni { get; set; }
        public double SaldoFin { get; set; }

        public List<AuxiliarCuentasCuentaDetalle> DetalleCuentas { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@NumCta", NumCta);
            xmlFinal = xmlFinal.Replace("@DesCta", Validaciones.RemplazarCaracteresEspeciales(DesCta));
            xmlFinal = xmlFinal.Replace("@SaldoIni", SaldoIni.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@SaldoFin", SaldoFin.ToString("0.0000"));

            String detalle = "";

            if (DetalleCuentas != null && DetalleCuentas.Count > 0)
            {
                foreach (AuxiliarCuentasCuentaDetalle comp in DetalleCuentas)
                {
                    detalle += "\t" + comp.ObtenerXMLString() + "\n";
                }
                detalle = detalle.Substring(0, detalle.Length - 1);
            }
            xmlFinal = xmlFinal.Replace("@ListadoDetalle", detalle);

            return xmlFinal;

        }
    }
}
