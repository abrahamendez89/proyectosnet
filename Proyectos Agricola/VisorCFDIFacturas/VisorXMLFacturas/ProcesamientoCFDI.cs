using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using VisorXMLFacturas.ValidarCFDI;

namespace VisorXMLFacturas
{
    public class ProcesamientoCFDI
    {
        public static String responsable;
        public static void ProcesarXML(String responsable, String ruta)
        {
            ProcesamientoCFDI.responsable = responsable;
            Factura fac = CargarXML(ruta);

            string temp = Path.GetTempPath() + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".html";

            Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(temp, fac.GenerarHTML());

            System.Diagnostics.Process.Start(temp);
        }

        private static Factura CargarXML(string ruta)
        {
            XmlDocument _xmlDocument = new XmlDocument();
            _xmlDocument.Load(ruta);
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(_xmlDocument.NameTable);
            xmlnsManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlnsManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

            XmlNode encabezado = _xmlDocument.SelectSingleNode("//cfdi:Comprobante", xmlnsManager);
            XmlNode timbrado = _xmlDocument.SelectSingleNode("//tfd:TimbreFiscalDigital", xmlnsManager);

            Factura fac = new Factura();
            fac.Impuestos = new List<Impuesto>();
            fac.Conceptos = new List<Concepto>();

            fac.Serie = ObtenerValor<String>(encabezado, "serie");// encabezado.Attributes["serie"].Value;
            fac.Folio = ObtenerValor<String>(encabezado, "folio");
            fac.Certificado = ObtenerValor<String>(encabezado, "noCertificado");
            fac.CondicionesPago = ObtenerValor<String>(encabezado, "condicionesDePago");
            fac.FechaFactura = ObtenerValor<DateTime>(encabezado, "fecha");
            fac.FormaPago = ObtenerValor<String>(encabezado, "formaDePago");
            fac.MetodoPago = ObtenerValor<String>(encabezado, "metodoDePago");
            fac.Subtotal = ObtenerValor<Double>(encabezado, "subTotal");
            fac.TipoComprobante = ObtenerValor<String>(encabezado, "tipoDeComprobante");
            fac.Total = ObtenerValor<Double>(encabezado, "total");

            fac.UUID = ObtenerValor<String>(timbrado, "UUID");
            fac.SelloDigital = ObtenerValor<String>(timbrado, "selloCFD");
            fac.SelloSAT = ObtenerValor<String>(timbrado, "selloSAT");
            fac.CertificadoSAT = ObtenerValor<String>(timbrado, "noCertificadoSAT");
            fac.FechaTimbrado = ObtenerValor<DateTime>(timbrado, "FechaTimbrado");

            //sacando los impuestos trasladados

            XmlNodeList impuestos = encabezado.SelectNodes("//cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", xmlnsManager);

            foreach (XmlNode nodo in impuestos)
            {
                Impuesto imp = new Impuesto();
                imp.Importe = ObtenerValor<double>(nodo, "importe");
                imp.Nombre = ObtenerValor<String>(nodo, "impuesto");
                imp.Tasa = ObtenerValor<String>(nodo, "tasa");
                fac.Impuestos.Add(imp);
            }
            // sacando las retenciones
            XmlNodeList retenciones = encabezado.SelectNodes("//cfdi:Impuestos/cfdi:Retenciones/cfdi:Retencion", xmlnsManager);

            foreach (XmlNode nodo in retenciones)
            {
                Impuesto imp = new Impuesto();
                imp.Importe = ObtenerValor<double>(nodo, "importe");
                imp.Nombre = ObtenerValor<String>(nodo, "impuesto");
                fac.Impuestos.Add(imp);
            }

            XmlNodeList conceptos = encabezado.SelectNodes("//cfdi:Conceptos/cfdi:Concepto", xmlnsManager);

            foreach (XmlNode nodo in conceptos)
            {
                Concepto concepto = new Concepto();
                concepto.Importe = ObtenerValor<double>(nodo, "importe");
                concepto.Cantidad = ObtenerValor<int>(nodo, "cantidad");
                concepto.ConceptoDescripcion = ObtenerValor<String>(nodo, "descripcion");
                concepto.Unidad = ObtenerValor<String>(nodo, "unidad");
                concepto.ValorUnitario = ObtenerValor<double>(nodo, "valorUnitario");
                fac.Conceptos.Add(concepto);
            }

            XmlNode emis = encabezado.SelectSingleNode("//cfdi:Emisor", xmlnsManager);

            Emisor emisor = new Emisor();
            emisor.RFC = ObtenerValor<String>(emis, "rfc");
            emisor.Nombre = ObtenerValor<String>(emis, "nombre");
            fac.Emisor = emisor;
            XmlNode dom = encabezado.SelectSingleNode("//cfdi:Emisor/cfdi:DomicilioFiscal", xmlnsManager);
            emisor.DomicilioFiscal = ObtenerValor<String>(dom, "calle") + " | ";
            emisor.DomicilioFiscal += ObtenerValor<String>(dom, "colonia") + " | ";
            emisor.DomicilioFiscal += ObtenerValor<String>(dom, "referencia") + " | ";
            emisor.DomicilioFiscal += ObtenerValor<String>(dom, "codigoPostal") + " | ";
            emisor.DomicilioFiscal += ObtenerValor<String>(dom, "municipio") + " | ";
            emisor.DomicilioFiscal += ObtenerValor<String>(dom, "estado") + " | ";
            emisor.DomicilioFiscal += ObtenerValor<String>(dom, "pais");
            XmlNode reg = encabezado.SelectSingleNode("//cfdi:Emisor/cfdi:RegimenFiscal", xmlnsManager);
            emisor.Regimen = ObtenerValor<String>(reg, "Regimen");

            XmlNode rece = encabezado.SelectSingleNode("//cfdi:Receptor", xmlnsManager);

            Receptor receptor = new Receptor();
            receptor.RFC = ObtenerValor<String>(rece, "rfc");
            receptor.Nombre = ObtenerValor<String>(rece, "nombre");
            fac.Receptor = receptor;
            XmlNode domi = encabezado.SelectSingleNode("//cfdi:Receptor/cfdi:Domicilio", xmlnsManager);
            receptor.Domicilio = ObtenerValor<String>(domi, "calle");
            receptor.Colonia = ObtenerValor<String>(domi, "colonia");
            receptor.Municipio = ObtenerValor<String>(domi, "municipio");
            receptor.Estado = ObtenerValor<String>(domi, "estado");
            receptor.Pais = ObtenerValor<String>(domi, "pais");
            receptor.CodigoPostal = ObtenerValor<String>(domi, "codigoPostal");

            fac.EstatusCDFI = ObtenerStatusCFDI(fac);
            fac.Responsable = responsable;

            return fac;

        }

        private static T ObtenerValor<T>(XmlNode nodo, String atributo)
        {
            try
            {
                return (T)Convert.ChangeType(nodo.Attributes[atributo].Value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        private static String ObtenerStatusCFDI(Factura fac)
        {
            try
            {
                ConsultaCFDIServiceClient con = new ConsultaCFDIServiceClient();
                /*
                 * Parámetros: expresionImpresa, 
                 * Cadena que contiene los parámetros de consulta: 
                 * re = rfc Emisor, 
                 * rr = RFC Receptor y 
                 * id= UUDI, la cadena puede variar dependiendo del lenguaje, en el caso de C# la cadena a enviar es:
                 */
                String cadena = "?re=" + fac.Emisor.RFC + "&rr=" + fac.Receptor.RFC + "&tt=" + fac.Total + "&id=" + fac.UUID;
                Acuse acuse = con.Consulta(cadena);
                return acuse.Estado;
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al establecer la conexión con el SAT.");
                return "No revisado por problema de Conexión";
            }
        }
    }
}
