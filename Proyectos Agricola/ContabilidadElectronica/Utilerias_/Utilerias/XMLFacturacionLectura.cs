using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerias.Utilerias
{
    public class XMLFacturacionLectura
    {
        String archivo = "";
        #region VariablesAEncontrar

        public static readonly String UUID = "UUID=";
        public static readonly String EmisorRFC = "Emisor rfc=";
        public static readonly String FolioFactura = "folio=";
        public static readonly String EmisorRFCsaasd = "Emisor rfc=";
        public static readonly String EmisorRF1C = "Emisor rfc=";
        public static readonly String EmisorRF2C = "Emisor rfc=";
        public static readonly String Emisor3RFC = "Emisor rfc=";
        public static readonly String Emisor4RFC = "Emisor rfc=";
        public static readonly String Emisor1RFC = "Emisor rfc=";
        public static readonly String Emisor2RFC = "Emisor rfc=";

        #endregion
        public XMLFacturacionLectura(String rutaArchivo)
        {
            archivo = Archivo.CargarArchivo(rutaArchivo);
        }
        //public XMLFacturacionLectura(String archivoXMLLeido)
        //{
        //    archivo = archivoXMLLeido;
        //}

        public T ObtenerValor<T>(String ValorABuscar)
        {
            int indice = archivo.IndexOf(ValorABuscar);

            String valor = "";
            int numeroComillas = 0;
            for (int i = indice; i < archivo.Length; i++)
            {
                valor += archivo[i];
                if (archivo[i] == '"')
                {
                    numeroComillas++;
                }
                if (numeroComillas == 2)
                    break;
            }
            valor = valor.Replace(ValorABuscar, "").Replace("\"", "");
            T ValorRetorno = default(T);
            try
            {
                ValorRetorno = (T)Converter.ParseType(valor, typeof(T));
            }
            catch { }

            return ValorRetorno;
        }


    }
}
