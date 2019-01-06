using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Herramientas.SMS
{
    public class AfilnetSMSService
    {
        //La página de Afilnet es: https://www.afilnet.com/

        private String usuario;
        private String password;
        public String DetallesError { get; set; }
        public AfilnetSMSService(String usuario, String password)
        {
            this.usuario = usuario;
            this.password = password;
        }

        public Boolean EnviarSMSGET(String codigoPais, String telefonoDestino, String remitente, String mensaje)
        {
            if (remitente.Length > 11)
            {
                DetallesError = "La longitud del remitente excede los 11 caracteres";
                return false;
            }
            string email = this.usuario; // Email de la cuenta de cliente  
            string pass = this.password; // Clave de la cuenta de cliente  
            string mobile = telefonoDestino; // Móvil destino  
            string idsender = remitente; // Remitente, 11 caracteres máximo
            string prefix = codigoPais; // Prefijo del pais  
            string sms = mensaje; // Mensaje a enviar  

            string surl = Uri.EscapeUriString("http://www.afilnet.com/http/sms/?email=" + email + "&pass=" + pass + "&mobile=" + mobile + "&id=" + idsender + "&country=" + prefix + "&sms=" + sms); // URL de petición

            // Creamos el objeto url mediante el método estático Create de la clase WebRequest
            WebRequest url = WebRequest.Create(surl);

            /* Si utiliza un proxy:
             * url.Proxy = WebProxy.GetDefaultProxy();
             */

            // Establecemos la conexión y obtenemos la respuesta
            Stream objStream = url.GetResponse().GetResponseStream();

            // Leemos la respuesta devuelta del buffer de entrada
            StreamReader objReader = new StreamReader(objStream);
            string response = objReader.ReadLine();

            // Tratamos la respuesta devuelta
            switch (response)
            {
                case "OK":
                    return true;
                case "-1":
                    DetallesError = "Error en el login, usuario o clave incorrectas";
                    return false;
                default:
                    DetallesError = "No dispone de créditos para realizar el envío";
                    return false;
            }
        }

        public Boolean EnviarSMSPOST(String codigoPais, String telefonoDestino, String remitente, String mensaje)
        {
            if (remitente.Length > 11)
            {
                DetallesError = "La longitud del remitente excede los 11 caracteres";
                return false;
            }
            string email = this.usuario; // Email de la cuenta de cliente  
            string pass = this.password; // Clave de la cuenta de cliente  
            string mobile = telefonoDestino; // Móvil destino  
            string idsender = remitente; // Remitente, 11 caracteres máximo
            string prefix = codigoPais; // Prefijo del pais  
            string sms = mensaje; // Mensaje a enviar  

            string surl = "http://www.afilnet.com/http/post/"; // URL de petición
            string postData = Uri.EscapeUriString("email=" + email + "&pass=" + pass + "&mobile=" + mobile + "&id=" + idsender + "&country=" + prefix + "&sms=" + sms);

            // Creamos el objeto url y configuramos sus parámetros, así como los parámetros post en el buffer de salida
            WebRequest url = WebRequest.Create(surl);
            url.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            url.ContentType = "application/x-www-form-urlencoded";
            url.ContentLength = byteArray.Length;
            Stream dataStream = url.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            // Establecemos la conexión y obtenemos la respuesta
            Stream objStream = url.GetResponse().GetResponseStream();

            // Leemos la respuesta devuelta del buffer de entrada
            StreamReader objReader = new StreamReader(objStream);
            string response = objReader.ReadLine();

            // Tratamos la respuesta devuelta
            switch (response)
            {
                case "OK":
                    return true;
                case "-1":
                    DetallesError = "Error en el login, usuario o clave incorrectas";
                    return false;
                default:
                    DetallesError = response;
                    return false;
            }
        }

    }
}
