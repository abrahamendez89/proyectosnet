using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class ComprobanteNacional
    {
        public static String Formato;

        public String UUID_CFDI { get; set; }
        public String RFC { get; set; }
        public String Moneda { get; set; }
        public double MontoTotal { get; set; }
        public double MontoSubTotal { get; set; }
        public double ImpuestosTrasladados { get; set; }
        public double ImpuestosRetenidos { get; set; }
        public double TipCamb { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@UUID_CFDI", UUID_CFDI);
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@MontoTotal", MontoTotal.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Moneda", Moneda);
            xmlFinal = xmlFinal.Replace("@TipCamb", TipCamb.ToString("0.0000"));


            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaUUID_CFDI(UUID_CFDI))
                resultado += "UUID_CFDI, ";
            if (!Validaciones.ValidaRFC(RFC))
                resultado += "RFC, ";
            if (!Validaciones.ValidaMoneda(Moneda))
                resultado += "Moneda, ";
            if (!Validaciones.ValidaTipoCambio(TipCamb))
                resultado += "TipCamb, ";
            return resultado;
        }
    }
}
