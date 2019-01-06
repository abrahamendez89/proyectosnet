
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDrive
{
    public partial class frm_login : Form
    {
        public static String Token = "bearer {0}";
        private String client_id = "000000004416797A";
        private String scope = "wl.signin wl.offline_access onedrive.readwrite";
        //private String scope = "wl.offline_access onedrive.readwrite";
        private String redirect_uri = "https://login.live.com/oauth20_desktop.srf";
        private String url_login = "https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=token&redirect_uri={2}";
        public frm_login()
        {
            InitializeComponent();
            mainThreadContext = System.Threading.SynchronizationContext.Current;
            loadLogin();
        }
        public System.Threading.SynchronizationContext mainThreadContext;

        private void loadLogin()
        {
            url_login = "https://www.dropbox.com/1/oauth2/authorize?client_id=n1sb0ohpjsemx75&redirect_uri=https://www.dropbox.com/home&response_type=token";
            //url_login = string.Format(url_login, client_id, redirect_uri);


            //OneDriveAPI od = new OneDriveAPI("abrahamm@wholesumharvest.com", "Cocaleca1");
            //od.SubirArchivoACarpeta(@"C:\Users\Abrahamm.WHOLESUM\Documents\ANV040509TA4201509PL.xml", "pruebaMetodo");

            wb.DocumentCompleted += webBrowserLogin_DocumentCompleted;
            wb.Navigate(new Uri(url_login));

            //Thread t = new Thread(Iniciar);
            //t.Start();
        }

        private String Loguear()
        {



            String jsonTemp = "{\"loginfmt\":\"abrahamm@wholesumharvest.com\",  \"passwd\":\"asd\", \"SI\": \"Iniciar sesión\",\"login\": \"abrahamm@wholesumharvest.com\",\"type\": \"11\",\"PPSX\": \"passp\",\"NewUser\": \"1\",\"LoginOptions\": \"1\"}";

            byte[] byteDATA = System.Text.Encoding.ASCII.GetBytes(jsonTemp);


            HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url_login);
            peticion.Method = "POST";
            peticion.ContentType = "application/json";
            //peticion.Headers.Add("Authorization", token);

            peticion.ContentLength = byteDATA.Length;
            peticion.GetRequestStream().Write(byteDATA, 0, byteDATA.Length);

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
        
        private void webBrowserLogin_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            String titulo = wb.Document.Url.ToString();
            if (titulo.Contains("access_token=") && Token != null)
            {
                String Fragment = wb.Document.Url.Fragment;
                int start = Fragment.IndexOf("#access_token=");
                int end = Fragment.IndexOf("&token_type=");
                Fragment = Fragment.Substring(start, end).Replace("#access_token=", "");
                Token = string.Format(Token, Fragment);
                if (!Token.Equals(""))
                {
                                        
                }
            }
            else if (wb.Document.Title.Contains("Iniciar"))
            {
                Thread t = new Thread(Iniciar);
                t.Start();
            }
            else if (wb.Document.Title.Contains("Autorización") && !wb.Document.Title.Contains("Iniciar"))
            {
                Thread t = new Thread(Permitir);
                t.Start();
            }
        }
        private void Permitir()
        {
            Thread.Sleep(1000);
            mainThreadContext.Send(delegate
            {
                foreach (HtmlElement item in wb.Document.GetElementsByTagName("button"))
                {
                    if (item.OuterHtml.Contains("auth-button button-primary"))
                    {
                        item.InvokeMember("Click");
                        break;
                    }
                }

            }, null);
        }
        private void Iniciar()
        {
            Thread.Sleep(1000);
            mainThreadContext.Send(delegate
            {

                String html = wb.Document.Body.InnerHtml;

                String idEmailInput = GetIDByElementName(html, "login_email");
                String idPassInput = GetIDByElementName(html, "login_password");

                wb.Document.GetElementById(idEmailInput).InnerText = "abrahamendez89@gmail.com";
                wb.Document.GetElementById(idPassInput).InnerText = "Cocaleca1";

                foreach (HtmlElement item in wb.Document.GetElementsByTagName("button"))
                {
                    if (item.OuterHtml.Contains("login-button button-primary"))
                    {
                        item.InvokeMember("Click");
                        break;
                    }
                }

            }, null);
        }
        
        private String GetIDByElementName(String html, String elementName)
        {
            int indice = html.IndexOf(elementName);
            //buscando el < para no perder el id si viene antes del name

            for (int i = indice; i >= 0; i--)
            {
                if (html[i] == '<')
                {
                    indice = i;
                    break;
                }
            }
            indice = html.IndexOf("id=", indice);
            indice += 4;
            String id = "";
            while (true)
            {
                id += html[indice];
                indice++;
                if (id.EndsWith("\""))
                {
                    id = id.Replace("\"", "");
                    break;
                }
            }
            return id;
        }
        private void btn_cerrarLogin_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AsignarValores();
        }
    }
}
