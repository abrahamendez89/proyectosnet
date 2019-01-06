using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class ComprobanteNacionalRepPol
    {
        public static String Formato;

        public String UUID_CFDI { get; set; }
        public String RFC { get; set; }
        public String MetPagoAux { get; set; }
        public double MontoTotal { get; set; }
        public String Moneda { get; set; }
        public double TipCamb { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@UUID_CFDI", UUID_CFDI);
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@MetPagoAux", MetPagoAux);
            xmlFinal = xmlFinal.Replace("@MontoTotal", MontoTotal.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Moneda", Moneda);
            xmlFinal = xmlFinal.Replace("@TipCamb", TipCamb.ToString("0.0000"));

            return xmlFinal;

        }
    }
}
