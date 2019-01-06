using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstructuraContable
{
    public class Poliza
    {
        public static String Formato;

        public String NumeroPoliza { get; set; }
        public DateTime Fecha { get; set; }
        public String Concepto { get; set; }

        public List<Transaccion> Transacciones { get; set; }

        public String ObtenerXMLString()
        {
            string xmlFinal = Formato.Replace("@NumUnIdenPol", NumeroPoliza);
            xmlFinal = xmlFinal.Replace("@Fecha", Herramientas.Conversiones.Formatos.DateTimeAFechaPolizaSAT(Fecha));
            xmlFinal = xmlFinal.Replace("@Concepto", Validaciones.RemplazarCaracteresEspeciales(Concepto));

            String transacciones = "";
            if (Transacciones != null && Transacciones.Count > 0)
            {
                foreach (Transaccion tra in Transacciones)
                {
                    transacciones += "\t\t" + tra.ObtenerXMLString() + "\n";
                }
                transacciones = transacciones.Substring(0, transacciones.Length - 1);
            }

            xmlFinal = xmlFinal.Replace("@ListadoTransacciones", transacciones);

            return xmlFinal;

        }
        public String ValidarDatos()
        {
            String resultado = "";
            if (!Validaciones.ValidaNumeroPoliza1_50(NumeroPoliza))
                resultado += "NumeroPoliza, ";
            if (!Validaciones.ValidaConceptoPoliza1_300(Concepto))
                resultado += "Concepto, ";
            return resultado;
        }

    }
}
