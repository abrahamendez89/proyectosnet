using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Cheque
    {
        public static String Formato;

        public String NumeroChequeEmitido { get; set; }
        public String BancoEmisNal { get; set; }
        public String BancoEmisExt { get; set; }
        public String CuentaOrigen { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public String Beneficiario { get; set; }
        public String RFC { get; set; }
        public double TipoCambio { get; set; }
        public String Moneda { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@Num", NumeroChequeEmitido);
            if (BancoEmisNal == null)
                xmlFinal = xmlFinal.Replace("BanEmisNal=\"@BanEmisNal\"", "");
            else
                xmlFinal = xmlFinal.Replace("@BanEmisNal", BancoEmisNal);
            if (BancoEmisExt == null)
                xmlFinal = xmlFinal.Replace("BanEmisExt=\"@BanEmisExt\"", "");
            else
                xmlFinal = xmlFinal.Replace("@BanEmisExt", BancoEmisExt);
            xmlFinal = xmlFinal.Replace("@CtaOri", CuentaOrigen);
            xmlFinal = xmlFinal.Replace("@Fecha", Herramientas.Conversiones.Formatos.DateTimeAFechaPolizaSAT(Fecha));
            xmlFinal = xmlFinal.Replace("@Monto", Monto.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Benef", Validaciones.RemplazarCaracteresEspeciales(Beneficiario));
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@TipCamb", TipoCambio.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Moneda", Moneda);


            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaNumeroCheque1_20(NumeroChequeEmitido))
                resultado += "NumChequeEmitido, ";
            if (!Validaciones.ValidaBanco(BancoEmisNal))
                resultado += "BancoEmisor, ";
            if (!Validaciones.ValidaCuenta1_50(CuentaOrigen))
                resultado += "CuentaOrigen, ";
            if (!Validaciones.ValidaBeneficiario1_300(Beneficiario))
                resultado += "Beneficiario, ";
            if (!Validaciones.ValidaRFC(RFC))
                resultado += "RFC, ";
            return resultado;
        }
    }
}
