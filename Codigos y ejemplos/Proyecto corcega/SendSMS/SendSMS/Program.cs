using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SendSMS
{
    class Program
    {
        static String ipCel = "192.168.2.107";
        static Boolean Prueba = false;
        static String sms = "Te invitamos a una reunión vecinal el día de hoy a las 6:00 PM en el piñatero con motivo de darle formalidad al comité, Participa!, también te invitamos a realizar las nuevas encuestas en http://corcega.my.to";
        static int indiceInicial = 9;


        static String bodyUsuarios = "{\"password\": \"Qwer1234!\"}";
        static String urlUsuarios = "http://104.131.146.48:3000/usuarios";
        static String urlProspectos = "http://104.131.146.48:3000/prospectos";
        static String metodoUsuarios = "POST";

        static String bodyEnviarSMS = "";
        //static String urlEnviarSMS = "http://192.168.43.1:8080/v1/sms/?phone=@numero&message=@mensaje";
        static String urlEnviarSMS = "http://" + ipCel + ":1688/services/api/messaging/?To=@numero&Message=@mensaje";
        static String metodoEnviarSMS = "POST";

        static String rutaLlegoSMS = "http://" + ipCel + ":1688/services/api/messaging/status/@idMensaje";

        //@nombre para el nombre

        static String mensaje = "Plataforma Córcega: Hola @nombre, @sms (Este ha sido un mensaje enviado de forma automática, por favor no responder, gracias)";

        static void Main(string[] args)
        {
            EnviarSMSMasivoUsuarios();
            //EnviarSMSMasivoProspectos();
        }
        public static void EnviarSMSMasivoProspectos()
        {
            ObtenerProspectos();
            String mensajeProspectos = "Plataforma Córcega: Hola @nombre, te hacemos la cordial invitación a participar en los asuntos que suceden en nuestro fraccionamiento, para ello puedes registrarte en la página 'http://corcega.my.to', e incribirte en la página de Facebook 'Vecinos Stanza Córcega' contamos con tu participación!. (Este ha sido un mensaje enviado de forma automática, favor de no responder.)";
            EnviarSMSProspectos(mensajeProspectos);
        }

        public static void EnviarSMSMasivoUsuarios()
        {
            mensaje = mensaje.Replace("@sms", sms);
            Console.WriteLine("Obteniendo lista de contactos...");
            if (!Prueba)
            {
                ObtenerContactos();
                //result.datos = result.datos.Where(x => x.nombreCalle.Contains("Av. Córcega ")).ToList();
            }
            else
            {
                result = new ResponseContactos();
                result.datos = new List<Dato>();
                result.datos.Add(new Dato { numCelular = "6671944875", nombres = "Abraham Salvador", nombreCalle = "Costa latina" });
                result.datos.Add(new Dato { numCelular = "6672146386", nombres = "Sarah", nombreCalle = "Costa latina" });
            }
            //agregando el filtrado por calle



            Console.WriteLine("Se obtuvo lista de contactos.");
            Console.WriteLine("Enviando mensajes...");
            EnviarSMS();
            //EnviarSMSPrueba();
            Console.WriteLine("Mensajes enviados.");
            Console.ReadKey();
        }

        static ResponseContactos result;
        static ResponseProspectos resultProspectos;
        static String json;
        public static void EnviarSMS()
        {
            //result.datos.ForEach(x =>
            //{
            //String mensaje = "CHAVAL!!";
            for(int i = indiceInicial; i < result.datos.Count; i++)
            {
                try
                {
                    var x = result.datos[i];
                    String numeroCel = x.numCelular;
                    //String mensaje = "";
                    String nombres = x.nombres;
                    String mensajet = mensaje.Replace("@nombre", nombres);
                    Convert.ToInt64(numeroCel);
                    String url = urlEnviarSMS.Replace("@numero", numeroCel).Replace("@mensaje", mensajet);
                    WebClient wc = new WebClient();
                    wc.Headers.Add("Content-Type", "application/json");
                    wc.Encoding = System.Text.Encoding.UTF8;
                    byte[] data = Encoding.ASCII.GetBytes(bodyEnviarSMS);
                    var response = wc.UploadString(url, metodoEnviarSMS);
                    String resultado = JsonHelper.FormatJson(response);
                    ResponseSendSMS smsSend = JsonConvert.DeserializeObject<ResponseSendSMS>(response);

                    Console.Write(i + ":" + numeroCel + "-" + Format(nombres) + "=");
                    if (!LlegoMensaje(smsSend.message.id))
                    {
                        i--;
                    }
                }
                catch (Exception ex)
                {

                }
                // }
            }
        }

        public static void EnviarSMSProspectos(String mensaje)
        {
            //int i = 1;
            //resultProspectos.datos.ForEach(x =>
            //{
            //String mensaje = "CHAVAL!!";
            for (int i = 0; i < resultProspectos.datos.Count; i++)
            {
                try
                {
                    var x = resultProspectos.datos[i];
                    String numeroCel = x.telefono;
                    //String mensaje = "";
                    String nombres = x.nombre;
                    String mensajet = mensaje.Replace("@nombre", nombres);
                    Convert.ToInt64(numeroCel);
                    String url = urlEnviarSMS.Replace("@numero", numeroCel).Replace("@mensaje", mensajet);
                    WebClient wc = new WebClient();
                    wc.Headers.Add("Content-Type", "application/json");
                    wc.Encoding = System.Text.Encoding.UTF8;
                    byte[] data = Encoding.ASCII.GetBytes(bodyEnviarSMS);
                    var response = wc.UploadString(url, metodoEnviarSMS);
                    String resultado = JsonHelper.FormatJson(response);
                    ResponseSendSMS smsSend = JsonConvert.DeserializeObject<ResponseSendSMS>(response);

                    Console.Write(i + ":" + numeroCel + "-" + Format(nombres) + "=");
                    if (!LlegoMensaje(smsSend.message.id))
                    {
                        i--;
                    }
                }
                catch (Exception ex)
                {

                }
                // }
            }
        }

        public static String Format(String nombres)
        {
            for (int i = 0; i < 20; i++)
            {
                nombres += " ";
            }
            return nombres.Substring(0, 12);
        }

        public static void ObtenerContactos()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/json");
            wc.Encoding = System.Text.Encoding.UTF8;
            byte[] data = Encoding.ASCII.GetBytes(bodyUsuarios);
            var response = wc.UploadString(urlUsuarios, metodoUsuarios, bodyUsuarios);
            json = JsonHelper.FormatJson(response);

            result = JsonConvert.DeserializeObject<ResponseContactos>(json);

            Console.WriteLine("Se cargaron usuarios: " + result.datos.Count);

            //Console.WriteLine(resultado);
        }

        public static void ObtenerProspectos()
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/json");
            wc.Encoding = System.Text.Encoding.UTF8;
            byte[] data = Encoding.ASCII.GetBytes(bodyUsuarios);
            var response = wc.UploadString(urlProspectos, metodoUsuarios, bodyUsuarios);
            json = JsonHelper.FormatJson(response);

            resultProspectos = JsonConvert.DeserializeObject<ResponseProspectos>(json);

            Console.WriteLine("Se cargaron prospectos: " + resultProspectos.datos.Count);

            //Console.WriteLine(resultado);
        }

        public static Boolean LlegoMensaje(String id)
        {
            //for(int i = 1; i <= 60; i++)
            while (true)
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.Headers.Add("Content-Type", "application/json");
                    wc.Encoding = System.Text.Encoding.UTF8;
                    var response = wc.DownloadString(rutaLlegoSMS.Replace("@idMensaje", id));
                    json = JsonHelper.FormatJson(response);

                    ResponseStatusSMS smsEnviados = JsonConvert.DeserializeObject<ResponseStatusSMS>(response);

                    if (smsEnviados != null && (smsEnviados.status.Equals("Sent") || smsEnviados.status.Equals("Delivered")))
                    {
                        Console.Write(" OK.\n");
                        return true;
                    }
                    else if(smsEnviados != null && smsEnviados.status.Equals("Failed"))
                    {
                        Console.Write(" Fail.\n");
                        return false;
                    }
                    else
                    {
                        Console.Write("|");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("E" + "|");
                }
                Thread.Sleep(1000);
            }
            Console.Write(" Next.\n");
        }
    }

    /*
    public class Message
    {
        public string address { get; set; }
        public string body { get; set; }
        public string _id { get; set; }
        public string msg_box { get; set; }
    }

    public class ResponseSMSEnviados
    {
        public string limit { get; set; }
        public string offset { get; set; }
        public string size { get; set; }
        public List<Message> messages { get; set; }
    }
    */
    public class ResponseContactos
    {
        public bool exito { get; set; }
        public string mensaje { get; set; }
        public int rows { get; set; }
        public List<Dato> datos { get; set; }
    }
    public class Dato
    {
        public int id_Usuario { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string numCelular { get; set; }
        public string email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int id_Numero { get; set; }
        public string nombreCalle { get; set; }
        public string numero { get; set; }
    }

    public class DatoProspecto
    {
        public string telefono { get; set; }
        public string nombre { get; set; }
    }

    public class ResponseProspectos
    {
        public bool exito { get; set; }
        public string mensaje { get; set; }
        public int rows { get; set; }
        public List<DatoProspecto> datos { get; set; }
    }
    public class Message1
    {
        public string answerTo { get; set; }
        public string date { get; set; }
        public string id { get; set; }
        public string message { get; set; }
        public string number { get; set; }
        public bool read { get; set; }
        public string to { get; set; }
    }

    public class ResponseStatusSMS
    {
        public Message1 message { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public bool isSuccessful { get; set; }
        public string requestMethod { get; set; }
    }


    public class Message
    {
        public string date { get; set; }
        public string id { get; set; }
        public string message { get; set; }
        public string number { get; set; }
        public bool read { get; set; }
        public string to { get; set; }
    }

    public class ResponseSendSMS
    {
        public Message message { get; set; }
        public string description { get; set; }
        public bool isSuccessful { get; set; }
        public string requestMethod { get; set; }
    }
}
