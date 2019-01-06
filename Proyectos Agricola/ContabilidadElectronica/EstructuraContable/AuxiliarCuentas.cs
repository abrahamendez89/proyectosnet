using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class AuxiliarCuentas
    {
        public static String Formato;

        public double Version { get; set; }
        public String RFC { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public String TipoSolicitud { get; set; }
        public String NumOrden { get; set; }
        public String NumTramite { get; set; }

        public List<AuxiliarCuentasCuenta> DetalleCuentas { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@Version", Version.ToString("0.0"));
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@Mes", Mes.ToString("00"));
            xmlFinal = xmlFinal.Replace("@Anio", Anio.ToString());
            xmlFinal = xmlFinal.Replace("@TipoSolicitud", TipoSolicitud);
            if (TipoSolicitud.Equals("AF") || TipoSolicitud.Equals("FC"))
                xmlFinal = xmlFinal.Replace("@NumOrden", NumOrden);
            else
                xmlFinal = xmlFinal.Replace("NumOrden=\"@NumOrden\"", "");

            if (TipoSolicitud.Equals("DE") || TipoSolicitud.Equals("CO"))
                xmlFinal = xmlFinal.Replace("@NumTramite", NumTramite);
            else
                xmlFinal = xmlFinal.Replace("NumTramite=\"@NumTramite\"", ""); 

            String detalle = "";

            if (DetalleCuentas != null && DetalleCuentas.Count > 0)
            {
                foreach (AuxiliarCuentasCuenta comp in DetalleCuentas)
                {
                    detalle += "\t" + comp.ObtenerXMLString() + "\n";
                }
                detalle = detalle.Substring(0, detalle.Length - 1);
            }
            xmlFinal = xmlFinal.Replace("@ListadoCuentas", detalle);

            return xmlFinal;

        }
    }
}
