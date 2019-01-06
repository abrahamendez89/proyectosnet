using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class ReportePolizasAuxDetalle
    {
        public static String Formato;

        public String NumUnIdenPol { get; set; }
        public DateTime Fecha { get; set; }
        public List<ComprobanteNacionalRepPol> ComprobantesNacionales { get; set; }
        public List<ComprobanteNacionalOtrosRepPol> ComprobantesNacionalesOtros { get; set; }
        public List<ComprobanteExtranjeroRepPol> ComprobantesExtranjeros { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@NumUnIdenPol", NumUnIdenPol);
            xmlFinal = xmlFinal.Replace("@Fecha", Herramientas.Conversiones.Formatos.DateTimeAFechaPolizaSAT(Fecha));

            String detalle = "";

            if (ComprobantesNacionales != null && ComprobantesNacionales.Count > 0)
            {
                foreach (ComprobanteNacionalRepPol comp in ComprobantesNacionales)
                {
                    detalle += "\t" + comp.ObtenerXMLString() + "\n";
                }
                detalle = detalle.Substring(0, detalle.Length - 1);
            }
            if (ComprobantesNacionalesOtros != null && ComprobantesNacionalesOtros.Count > 0)
            {
                foreach (ComprobanteNacionalOtrosRepPol comp in ComprobantesNacionalesOtros)
                {
                    detalle += "\t" + comp.ObtenerXMLString() + "\n";
                }
                detalle = detalle.Substring(0, detalle.Length - 1);
            }
            if (ComprobantesExtranjeros != null && ComprobantesExtranjeros.Count >0)
            {
                foreach (ComprobanteExtranjeroRepPol comp in ComprobantesExtranjeros)
                {
                    detalle += "\t" + comp.ObtenerXMLString() + "\n";
                }
                detalle = detalle.Substring(0, detalle.Length - 1);
            }
            xmlFinal = xmlFinal.Replace("@ListadoComprobantes", detalle);
            return xmlFinal;

        }
    }
}
