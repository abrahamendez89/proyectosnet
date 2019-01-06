using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;

namespace OneDrive
{
    public class Peticion
    {
        private String api = "https://api.onedrive.com/v1.0";
        private String token;
        private String urlPeticion;
        private String metodo;
        private byte[] byteDATA;
        private String ContentType;

        public byte[] ByteDATA
        {
            get { return byteDATA; }
            set { byteDATA = value; }
        }

        public String ContentType1
        {
            get { return ContentType; }
            set { ContentType = value; }
        }

        public String UrlPeticion
        {
            get { return urlPeticion; }
            set { urlPeticion = value; }
        }
        public String Token
        {
            get { return token; }
            set { token = value; }
        }
        public String Metodo
        {
            get { return metodo; }
            set { metodo = value; }
        }
        public dynamic HacerPeticion()
        {
            return HacerPeticion(null, -1, -1);
        }
        public dynamic HacerPeticion(String url)
        {
            return HacerPeticion(url, -1, -1);
        }
        public dynamic HacerPeticion(String url, long indiceDesde, long totalBytes)
        {
            try
            {
                Boolean urlDirecta = url != null;
                if (!urlDirecta)
                {
                    url = api + this.urlPeticion;
                }
                HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
                peticion.Method = this.metodo;

                peticion.ContentType = ContentType;
                peticion.Headers.Add("Authorization", token);

                if (byteDATA != null)
                {
                    if (indiceDesde >= 0)
                    {
                        //peticion.AddRange("Content-Range", indiceDesde, indiceDesde + byteDATA.Length);
                        //peticion.Headers.Add("Range", indiceDesde+"-"+indiceDesde+byteDATA.Length);
                        long length = byteDATA.Length;

                        String fragmento = String.Format("bytes {0}-{1}/{2}", indiceDesde, indiceDesde + length-1, totalBytes);

                        peticion.Headers.Add("Content-Range", fragmento);
                        peticion.ContentLength = length;
                    }
                    peticion.ContentLength = byteDATA.Length;
                    peticion.GetRequestStream().Write(byteDATA, 0, byteDATA.Length);

                }
                //recibiendo respuesta
                HttpWebResponse respuesta = (HttpWebResponse)peticion.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created) // ASUMIMOS QUE TODO VA BIEN
                {
                    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                    String result = read.ReadToEnd();
                    read.Close();
                    respuesta.Close();
                    dynamic stuff = JObject.Parse(result);
                    return stuff;
                }
                else
                {
                    throw new Exception("Ocurrio un error " + respuesta.StatusCode);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
