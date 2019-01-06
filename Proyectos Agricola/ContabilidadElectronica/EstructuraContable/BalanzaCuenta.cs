using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class BalanzaCuenta
    {
        public static String Formato;

        public String NumCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public double Debe { get; set; }
        public double Haber { get; set; }
        public double SaldoFinal { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Trim().Replace("@NumCta", Validaciones.RemplazarCaracteresEspeciales(NumCuenta));
            xmlFinal = xmlFinal.Replace("@SaldoIni", Validaciones.RemplazarCaracteresEspeciales(Validaciones.ConvertirDineroAString(SaldoInicial)));
            xmlFinal = xmlFinal.Replace("@Debe", Validaciones.RemplazarCaracteresEspeciales(Validaciones.ConvertirDineroAString(Debe)));
            xmlFinal = xmlFinal.Replace("@Haber", Validaciones.RemplazarCaracteresEspeciales(Validaciones.ConvertirDineroAString(Haber)));
            xmlFinal = xmlFinal.Replace("@SaldoFin", Validaciones.RemplazarCaracteresEspeciales(Validaciones.ConvertirDineroAString(SaldoFinal)));

            return xmlFinal;

        }
        public String ValidarDatos()
        {
            String resultado = "";
            if (Validaciones.ValidaNumCuenta(NumCuenta))
                resultado += "NumCuenta, ";
            return resultado;
        }
    }
}
