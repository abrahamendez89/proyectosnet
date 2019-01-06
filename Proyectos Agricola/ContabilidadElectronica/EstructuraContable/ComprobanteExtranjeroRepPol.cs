using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class ComprobanteExtranjeroRepPol
    {
        public static String Formato;

        public String NumFactExt { get; set; }
        public String TaxID { get; set; }
        public double MontoTotal { get; set; }
        public String MetPagoAux { get; set; }
        public String Moneda { get; set; }
        public double TipCamb { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@NumFactExt", NumFactExt);
            xmlFinal = xmlFinal.Replace("@TaxID", TaxID);
            xmlFinal = xmlFinal.Replace("@MontoTotal", MontoTotal.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@MetPagoAux", MetPagoAux);
            xmlFinal = xmlFinal.Replace("@Moneda", Moneda);
            xmlFinal = xmlFinal.Replace("@TipCamb", TipCamb.ToString("0.0000"));

            return xmlFinal;

        }
    }
}
