using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Herramientas.Net
{
    public class WebService
    {
        public string Url { get; set; }
        public string Metodo { get; set; }
        Dictionary<string, String> Parametros = new Dictionary<string, String>();
        public XDocument ResultadoXML;
        public String[] ResultadoArreglo;
        public string ResultadoString;

        public WebService(string url, string metodo)
        {
            Url = url;
            Metodo = metodo;
        }

        public void Ejecutar()
        {
            Ejecutar(true);
        }

        public void AgregarParametroConValor(String parametro, String valor)
        {
            Parametros.Add(parametro, valor);
        }
        
        public void Ejecutar(bool codificar)
        {
            try
            {
                string soapStr =
                    @"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
               xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
               @body
            </soap:Envelope>";

                if (Parametros.Count > 0)
                {
                    soapStr = soapStr.Replace("@body", @"<soap:Body>
                                                            <{0} xmlns=""http://tempuri.org/"">
                                                              {1}
                                                            </{0}>
                                                          </soap:Body>");
                }
                else
                {
                    soapStr = soapStr.Replace("@body", "");
                }

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Headers.Add("SOAPAction", "\"http://tempuri.org/" + Metodo + "\"");
                req.ContentType = "text/xml;charset=\"utf-8\"";
                req.Accept = "text/xml";
                req.Method = "POST";
                

                if (Parametros.Count > 0)
                {
                    using (Stream stm = req.GetRequestStream())
                    {
                        string postValues = "";
                        foreach (var param in Parametros)
                        {
                            if (codificar)
                                postValues += string.Format("<{0}>{1}</{0}>", HttpUtility.UrlEncode(param.Key), HttpUtility.UrlEncode(param.Value));
                            else
                                postValues += string.Format("<{0}>{1}</{0}>", param.Key, param.Value);
                        }

                        soapStr = string.Format(soapStr, Metodo, postValues);
                        using (StreamWriter stmw = new StreamWriter(stm))
                        {
                            stmw.Write(soapStr);
                        }
                    }
                }
                using (StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    string result = responseReader.ReadToEnd();
                    ResultadoXML = XDocument.Parse(result);

                    XmlDocument document = new XmlDocument();
                    document.LoadXml(result);  //loading soap message as string 
                    XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);

                    manager.AddNamespace("d", "http://someURL");
                    manager.AddNamespace("bhr", "http://tempuri.org/");

                    XmlNodeList xnList = document.SelectNodes("//bhr:" + Metodo + "Response", manager);
                    int nodes = xnList.Count;

                    if (nodes > 0 && xnList[0].ChildNodes.Count > 0)
                    {
                        ResultadoArreglo = new string[xnList[0].ChildNodes[0].ChildNodes.Count];

                        for (int i = 0; i < xnList[0].ChildNodes[0].ChildNodes.Count; i++)
                        {
                            XmlNode xn = xnList[0].ChildNodes[0].ChildNodes[i];
                            ResultadoArreglo[i] = xn.InnerText;
                        }
                    }

                    ResultadoString = result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
