using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class ComprobanteNacionalOtros
    {
        public static String Formato;

        public String CFD_CBB_Serie { get; set; }
        public int CFD_CBB_NumFol { get; set; }
        public String RFC { get; set; }
        public String Moneda { get; set; }
        public double MontoTotal { get; set; }
        public double TipCamb { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@CFD_CBB_Serie", CFD_CBB_Serie);
            xmlFinal = xmlFinal.Replace("@CFD_CBB_NumFol", CFD_CBB_NumFol.ToString());
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@MontoTotal", MontoTotal.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Moneda", Moneda);
            xmlFinal = xmlFinal.Replace("@TipCamb", TipCamb.ToString("0.0000"));


            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaCFD_CBB_Serie(CFD_CBB_Serie))
                resultado += "CFD_CBB_Serie, ";
            if (!Validaciones.ValidaCFD_CBB_NumFol(CFD_CBB_NumFol))
                resultado += "CFD_CBB_NumFol, ";
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
