using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Herramientas.Archivos
{
    public class XML
    {
        XmlDocument xDoc;
        XmlNamespaceManager xnspm;
        public XML(String rutaArchivo)
        {
            xDoc = new XmlDocument();
            xDoc.Load(rutaArchivo);
            xnspm = GetNameSpaceManager(xDoc);

        }
        public XML()
        {
        }
        public String XMLContenido { set { xDoc = new XmlDocument(); xDoc.LoadXml(value); xnspm = GetNameSpaceManager(xDoc); } }
        public String ObtenerValorDePropiedad_NODO_XML(String nombreEspacio, String nombreNodo, String nombrePropiedad)
        {
            //    "//cfdi:Emisor"

            XmlNodeList resBusqueda = xDoc.SelectNodes("//" + nombreEspacio + ":" + nombreNodo + "", xnspm);

            foreach (XmlNode xn in resBusqueda)
            {
                foreach (XmlAttribute atributo in xn.Attributes)
                {
                    if (atributo.Name.ToLower().Equals(nombrePropiedad.ToLower()))
                    {
                        return atributo.Value;
                    }
                }
            }  
            return null;
        }
        public List<String> ObtenerNodos_XML(String nombreEspacio, String nombreNodo)
        {
            //    "//cfdi:Emisor"
            List<String> listaAtributos = new List<string>();
            XmlNodeList resBusqueda = xDoc.SelectNodes("//" + nombreEspacio + ":" + nombreNodo + "", xnspm);

            foreach (XmlNode xn in resBusqueda)
            {
                //foreach (XmlAttribute atributo in xn.Attributes)
                //{
                //    if (atributo.Name.ToLower().Equals(nombrePropiedad.ToLower()))
                //    {
                //        return atributo.Value;
                //    }
                //}
                listaAtributos.Add(xn.InnerXml);
            }
            return listaAtributos;
        }
        private XmlNamespaceManager GetNameSpaceManager(XmlDocument xDoc)
        {
            XmlNamespaceManager nsm = new XmlNamespaceManager(xDoc.NameTable);
            XPathNavigator RootNode = xDoc.CreateNavigator();
            RootNode.MoveToFollowing(XPathNodeType.Element);
            Dictionary<String, String> temporal = new Dictionary<string, string>();
            int iteracionesIguales = 0;
            int conteoAnterior = 0;
            while(true)
            {
                conteoAnterior = temporal.Keys.Count;
                IDictionary<string, string> NameSpaces2 = RootNode.GetNamespacesInScope(XmlNamespaceScope.All);
                foreach (KeyValuePair<string, string> kvp in NameSpaces2)
                {
                    if (!temporal.ContainsKey(kvp.Key))
                        temporal.Add(kvp.Key, kvp.Value);
                    
                }
                RootNode.MoveToFollowing(XPathNodeType.Element);



                if (temporal.Keys.Count == conteoAnterior)
                    iteracionesIguales++;
                else
                    iteracionesIguales = 0;

                if (iteracionesIguales == 200)
                    break;
            }

            foreach (String key in temporal.Keys)
            {
                nsm.AddNamespace(key, temporal[key]);
            }

            return nsm;
        }
        public String ContenidoTexto { get { return xDoc.InnerXml; } }
    }
}
