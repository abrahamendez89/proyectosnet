using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class ComprobanteExtranjero
    {
        public static String Formato;

        public String NumFactExt { get; set; }
        public String TaxID { get; set; }
        public double MontoTotal { get; set; }
        public String Moneda { get; set; }
        public double TipCamb { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@NumFactExt", NumFactExt);
            xmlFinal = xmlFinal.Replace("@TaxID", TaxID);
            xmlFinal = xmlFinal.Replace("@MontoTotal", MontoTotal.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Moneda", Moneda);
            xmlFinal = xmlFinal.Replace("@TipCamb", TipCamb.ToString("0.0000"));


            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaNumFactExt(NumFactExt))
                resultado += "NumFactExt, ";
            if (!TaxID.Equals("") && !Validaciones.ValidaTaxID(TaxID))
                resultado += "TaxID, ";
            if (!Validaciones.ValidaMoneda(Moneda))
                resultado += "Moneda, ";
            if (!Validaciones.ValidaTipoCambio(TipCamb))
                resultado += "TipCamb, ";
            return resultado;
        }
    }
}
