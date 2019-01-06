using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace OneDrive.API
{
    public class APIRest
    {
        public String API { get; set; }
        public byte[] ByteData { get; set; }
        public String Method { get; set; }
        public String ContentType { get; set; }
        public String Token { get; set; }
        public String URI { get; set; }

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
                    url = this.API + this.URI;
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = this.Method;

                request.ContentType = ContentType;
                if (this.Token != null)
                    request.Headers.Add("Authorization", this.Token);

                if (this.ByteData != null)
                {
                    if (indiceDesde >= 0)
                    {
                        long length = this.ByteData.Length;
                        String fragmento = String.Format("bytes {0}-{1}/{2}", indiceDesde, indiceDesde + length - 1, totalBytes);
                        request.Headers.Add("Content-Range", fragmento);
                        request.ContentLength = length;
                    }
                    request.ContentLength = this.ByteData.Length;
                    try
                    {
                        request.GetRequestStream().Write(this.ByteData, 0, this.ByteData.Length);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrio un error al enviar los datos al servidor.", ex);
                    }

                }
                //recibiendo respuesta
                HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
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
                    throw new Exception("Ocurrio un error al obtener la respuesta del servidor: " + respuesta.StatusCode);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
