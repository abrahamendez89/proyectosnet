using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Catalogo
    {
        public static String Formato;

        public double Version { get; set; }
        public String RFC { get; set; }
        public int TotalCuentas { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }


        public List<CatalogoCuenta> Cuentas { get; set; }


        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@Version", Validaciones.RemplazarCaracteresEspeciales(String.Format("{0:#.0}", Version)));
            xmlFinal = xmlFinal.Replace("@RFC", Validaciones.RemplazarCaracteresEspeciales(RFC));
            xmlFinal = xmlFinal.Replace("@Mes", Validaciones.RemplazarCaracteresEspeciales(Mes.ToString("D2")));
            xmlFinal = xmlFinal.Replace("@Anio", Validaciones.RemplazarCaracteresEspeciales(Ano.ToString("D2")));

            String cuentas = "";
            if (Cuentas != null && Cuentas.Count > 0)
            {
                foreach (CatalogoCuenta cta in Cuentas)
                {
                    cuentas += "\t" + cta.ObtenerXMLString() + "\n";
                }
                cuentas = cuentas.Substring(0, cuentas.Length - 1);
            }

            xmlFinal = xmlFinal.Replace("@ListadoCuentas", cuentas);

            return xmlFinal;

        }
        public String ValidarDatos()
        {
            String resultado = "";
            if (Version == 0)
                resultado += "Versión, ";
            if (!Validaciones.ValidaRFC(RFC))
                resultado += "RFC, ";
            if (!Validaciones.ValidaMes(Mes))
                resultado += "Mes, ";
            if (!Validaciones.ValidaAno(Ano))
                resultado += "Año, ";
            if (!Validaciones.ValidaTotalCuentas(TotalCuentas))
                resultado += "Total cuentas, ";
            return resultado;
        }
    }
}
