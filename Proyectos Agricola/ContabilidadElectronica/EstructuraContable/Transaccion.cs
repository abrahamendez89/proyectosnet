using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Transaccion
    {
        public static String Formato;

        public String NumeroCuenta { get; set; }
        public String DesCta { get; set; }
        public String Concepto { get; set; }
        public double Debe { get; set; }
        public double Haber { get; set; }

        public List<Cheque> Cheques { get; set; }
        public List<Transferencia> Transferencias { get; set; }
        //public List<Comprobante> Comprobantes { get; set; }
        public List<ComprobanteNacional> ComprobantesNacionales { get; set; }
        public List<ComprobanteNacionalOtros> ComprobantesNacionalesOtros { get; set; }
        public List<ComprobanteExtranjero> ComprobantesExtranjeros { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@NumCta", NumeroCuenta);
            xmlFinal = xmlFinal.Replace("@DesCta", Validaciones.RemplazarCaracteresEspeciales(DesCta));
            xmlFinal = xmlFinal.Replace("@Concepto", Validaciones.RemplazarCaracteresEspeciales(Concepto));
            xmlFinal = xmlFinal.Replace("@Debe", Debe.ToString("0.0000"));
            xmlFinal = xmlFinal.Replace("@Haber", Haber.ToString("0.0000"));

            String cheques = "";
            if (Cheques != null && Cheques.Count > 0)
            {
                foreach (Cheque ch in Cheques)
                {
                    cheques += "\t\t\t" + ch.ObtenerXMLString() + "\n";
                }
                cheques = cheques.Substring(0, cheques.Length - 1);
            }
            String transferencias = "";
            if (Transferencias != null && Transferencias.Count > 0)
            {
                foreach (Transferencia tr in Transferencias)
                {
                    transferencias += "\t\t\t" + tr.ObtenerXMLString() + "\n";
                }
                transferencias = transferencias.Substring(0, transferencias.Length - 1);
            }
            //String comprobantes = "";
            //if (Comprobantes != null && Comprobantes.Count > 0)
            //{
            //    foreach (Comprobante com in Comprobantes)
            //    {
            //        comprobantes += "\t" + com.ObtenerXMLString() + "\n";
            //    }
            //    comprobantes = comprobantes.Substring(0, comprobantes.Length - 1);
            //}
            String comprobantesNacionales = "";
            if (ComprobantesNacionales != null && ComprobantesNacionales.Count > 0)
            {
                foreach (ComprobanteNacional com in ComprobantesNacionales)
                {
                    comprobantesNacionales += "\t\t\t" + com.ObtenerXMLString() + "\n";
                }
                comprobantesNacionales = comprobantesNacionales.Substring(0, comprobantesNacionales.Length - 1);
            }

            String comprobantesNacionalesOtros = "";
            if (ComprobantesNacionalesOtros != null && ComprobantesNacionalesOtros.Count > 0)
            {
                foreach (ComprobanteNacionalOtros com in ComprobantesNacionalesOtros)
                {
                    comprobantesNacionalesOtros += "\t\t\t" + com.ObtenerXMLString() + "\n";
                }
                comprobantesNacionalesOtros = comprobantesNacionalesOtros.Substring(0, comprobantesNacionalesOtros.Length - 1);
            }

            String comprobantesExtranjeros = "";
            if (ComprobantesExtranjeros != null && ComprobantesExtranjeros.Count > 0)
            {
                foreach (ComprobanteExtranjero com in ComprobantesExtranjeros)
                {
                    comprobantesExtranjeros += "\t\t\t" + com.ObtenerXMLString() + "\n";
                }
                comprobantesExtranjeros = comprobantesExtranjeros.Substring(0, comprobantesExtranjeros.Length - 1);
            }

            xmlFinal = xmlFinal.Replace("@Cheques", cheques);
            xmlFinal = xmlFinal.Replace("@Transferencias", transferencias);
            xmlFinal = xmlFinal.Replace("@ComprobantesNacionales", comprobantesNacionales);
            xmlFinal = xmlFinal.Replace("@ComprobantesOtrosNacionales", comprobantesNacionalesOtros);
            xmlFinal = xmlFinal.Replace("@ComprobantesExtranjeros", comprobantesExtranjeros);
            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaNumeroCuenta1_100(NumeroCuenta))
                resultado += "NumeroCuenta, ";
            if (!Validaciones.ValidaDesCtaTransaccion1_100(DesCta))
                resultado += "Descripción Cuenta, ";
            if (!Validaciones.ValidaConceptoTransaccion1_200(Concepto))
                resultado += "Concepto, ";
            return resultado;
        }
    }
}
