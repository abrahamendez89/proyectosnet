using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Transferencia
    {
        public static String Formato;

        public String CuentaOrigen { get; set; }
        public String BancoOrigenNal { get; set; }
        public String BancoOrigenExt { get; set; }
        public double Monto { get; set; }
        public double TipoCambio { get; set; }
        public String CuentaDestino { get; set; }
        public String BancoDestinoNal { get; set; }
        public String BancoDestinoExt { get; set; }
        public DateTime Fecha { get; set; }
        public String Beneficiario { get; set; }
        public String RFC { get; set; }

        public String ObtenerXMLString()
        {

            string xmlFinal = Formato.Replace("@CtaOri", CuentaOrigen);
            if (BancoOrigenNal != null)
                xmlFinal = xmlFinal.Replace("@BancoOriNal", BancoOrigenNal);
            else
                xmlFinal = xmlFinal.Replace("BancoOriNal=\"@BancoOriNal\"", "");

            if (BancoOrigenExt != null)
                xmlFinal = xmlFinal.Replace("@BancoOriExt", BancoOrigenExt);
            else
                xmlFinal = xmlFinal.Replace("BancoOriExt=\"@BancoOriExt\"", "");

            xmlFinal = xmlFinal.Replace("@CtaDestino", CuentaDestino);
            if (BancoDestinoNal != null)
                xmlFinal = xmlFinal.Replace("@BancoDestinoNal", BancoDestinoNal);
            else
                xmlFinal = xmlFinal.Replace("BancoDestNal=\"@BancoDestinoNal\"", "");

            if (BancoDestinoExt != null)
                xmlFinal = xmlFinal.Replace("@BancoDestinoExt", BancoDestinoExt);
            else
                xmlFinal = xmlFinal.Replace("BancoDestExt=\"@BancoDestinoExt\"", "");

            xmlFinal = xmlFinal.Replace("@Fecha", Herramientas.Conversiones.Formatos.DateTimeAFechaPolizaSAT(Fecha));
            xmlFinal = xmlFinal.Replace("@Beneficiario", Validaciones.RemplazarCaracteresEspeciales(Beneficiario));
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@Monto", Monto.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@TipCamb", TipoCambio.ToString("0.0000"));

            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaCuenta1_50(CuentaOrigen))
                resultado += "cuentaOrigen, ";
            if (!Validaciones.ValidaBanco(BancoOrigenNal))
                resultado += "BancoOrigen, ";
            if (!Validaciones.ValidaCuenta1_50(CuentaDestino))
                resultado += "CuentaDestino, ";
            if (!Validaciones.ValidaBanco(BancoDestinoNal))
                resultado += "BancoDestino, ";
            if (!Validaciones.ValidaBeneficiario1_300(Beneficiario))
                resultado += "Beneficiario, ";
            if (!Validaciones.ValidaRFC(RFC))
                resultado += "RFC, ";
            return resultado;
        }
    }
}
