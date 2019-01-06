using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class PolizaContenedor
    {
        public static String Formato;

        public double Version { get; set; }
        public String RFC { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public String TipoSolicitud { get; set; }
        public String NumOrden { get; set; }
        public String NumTramite { get; set; }

        public List<Poliza> Polizas { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@Version", String.Format("{0:#.0}", Version));
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@Mes", Mes.ToString("00"));
            xmlFinal = xmlFinal.Replace("@Anio", Ano.ToString());
            xmlFinal = xmlFinal.Replace("@TipoSolicitud", TipoSolicitud);
            if(TipoSolicitud.Equals("AF") || TipoSolicitud.Equals("FC"))
                xmlFinal = xmlFinal.Replace("@NumOrden", NumOrden);
            else
                xmlFinal = xmlFinal.Replace("NumOrden=\"@NumOrden\"", "");

            if (TipoSolicitud.Equals("DE") || TipoSolicitud.Equals("CO"))
                xmlFinal = xmlFinal.Replace("@NumTramite", NumTramite);
            else
                xmlFinal = xmlFinal.Replace("NumTramite=\"@NumTramite\"", ""); 

            String polizas = "";
            if (Polizas != null && Polizas.Count > 0)
            {
                foreach (Poliza pol in Polizas)
                {
                    polizas += "\t" + pol.ObtenerXMLString() + "\n";
                }
                polizas = polizas.Substring(0, polizas.Length - 1);
            }

            xmlFinal = xmlFinal.Replace("@ListadoPolizas", polizas);

            return xmlFinal;

        }
        public String ValidarDatos()
        {
            String resultado = "";
            if (Version > 0)
                resultado += "Version, ";
            if (!Validaciones.ValidaAno(Ano))
                resultado += "Año, ";
            if (!Validaciones.ValidaMes(Mes))
                resultado += "Mes, ";
            if (!Validaciones.ValidaRFC(RFC))
                resultado += "Concepto, ";
            if (!Validaciones.ValidaTipoSolicitud(TipoSolicitud))
                resultado += "TipoSolicitud, ";
            if (!Validaciones.ValidaNumOrden(TipoSolicitud, NumOrden))
                resultado += "NumOrden, ";
            if (!Validaciones.ValidaNumTramite(TipoSolicitud, NumTramite))
                resultado += "NumTramite, ";
            return resultado;
        }
    }
}
