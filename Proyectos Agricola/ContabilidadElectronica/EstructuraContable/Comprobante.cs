using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Comprobante
    {
        public static String Formato;

        public String UUID { get; set; }
        public Double Monto { get; set; }
        public String RFC { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@UUID_CFDI", UUID);
            xmlFinal = xmlFinal.Replace("@Monto", Monto.ToString());
            xmlFinal = xmlFinal.Replace("@RFC", RFC);


            return xmlFinal;

        }

        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaUUID_CFDI(UUID))
                resultado += "UUID, ";
            if (!Validaciones.ValidaRFC(RFC))
                resultado += "RFC, ";
            return resultado;
        }
    }
}
