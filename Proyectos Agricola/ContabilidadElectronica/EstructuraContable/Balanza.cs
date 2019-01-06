using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Balanza
    {
        public static String Formato;

        public double Version { get; set; }
        public String RFC { get; set; }
        public int TotalCuentas { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public String TipoEnvio { get; set; }
        public DateTime FechaModBal { get; set; }

        public List<BalanzaCuenta> Cuentas { get; set; }


        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Trim().Replace("@Version", Validaciones.RemplazarCaracteresEspeciales(String.Format("{0:#.0}", Version)));
            xmlFinal = xmlFinal.Replace("@RFC", RFC);
            xmlFinal = xmlFinal.Replace("@TotalCuentas", Validaciones.RemplazarCaracteresEspeciales(TotalCuentas.ToString()));
            xmlFinal = xmlFinal.Replace("@Mes",Validaciones.RemplazarCaracteresEspeciales( Mes.ToString("D2")));
            xmlFinal = xmlFinal.Replace("@Anio",Validaciones.RemplazarCaracteresEspeciales( Ano.ToString()));
            if (TipoEnvio.Equals("C"))
            {
                xmlFinal = xmlFinal.Replace("@TipoEnvio", Validaciones.RemplazarCaracteresEspeciales(TipoEnvio));
            }
            else
            {
                xmlFinal = xmlFinal.Replace("@TipoEnvio", Validaciones.RemplazarCaracteresEspeciales(TipoEnvio));
                xmlFinal = xmlFinal.Replace("FechaModBal=\"@FechaModBal\"","");
            }

            String cuentas = "";
            if (Cuentas != null && Cuentas.Count > 0)
            {
                foreach (BalanzaCuenta cta in Cuentas)
                {
                    cuentas += "\t"+cta.ObtenerXMLString()+"\n";
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
            if (!Validaciones.ValidaTipoEnvio(TipoEnvio))
                resultado += "TipoEnvio, ";
            if (!Validaciones.ValidaFechaModBal(TipoEnvio, FechaModBal))
                resultado += "FechaModBal, ";
            if(!Validaciones.ValidaMes(Mes))
                resultado += "Mes, ";
            if (!Validaciones.ValidaAno(Ano))
                resultado += "Año, ";
            if (!Validaciones.ValidaTotalCuentas(TotalCuentas))
                resultado += "Total cuentas, ";
            return resultado;
        }
    }
}
