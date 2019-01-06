using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Herramientas.Web
{
    public class DropBoxAPI
    {
        private String API = "https://api.dropboxapi.com/2";
        private String url_login = "https://www.dropbox.com/1/oauth2/authorize?client_id={0}&response_type=token&redirect_uri={1}";
        private String redirect_uri = "https://www.dropbox.com/home";
        private String Token = null;
        private String client_id = "n1sb0ohpjsemx75";
        //private String scope = "wl.signin wl.offline_access onedrive.readwrite";
        private WebBrowser wb;
        private String usuario;
        private String password;
        private String carpeta;
        private String rutaArchivo;
        private long longitudFragmento = 5 * 1024 * 1024;

        public delegate void Error(String rutaArchivo, Exception ex);
        public event Error error;

        public delegate void PorcentajeEnviado(double porcentaje);
        public event PorcentajeEnviado porcentajeEnviado;

        public delegate void EnvioTerminado(String rutaArchivo);
        public event EnvioTerminado envioTerminado;

        public System.Threading.SynchronizationContext mainThreadContext = System.Threading.SynchronizationContext.Current;

        public DropBoxAPI(String usuarioDropBox, String passWordDropBox)
        {
            usuario = usuarioDropBox;
            password = passWordDropBox;

        }
        public void SubirArchivoACarpeta(String rutaArchivoSubir, String nombreCarpetaOneDrive)
        {
            mainThreadContext = System.Threading.SynchronizationContext.Current;
            rutaArchivo = rutaArchivoSubir;
            carpeta = nombreCarpetaOneDrive;
            carpeta = carpeta.Replace("\\", "/");
            if (!carpeta.EndsWith("/"))
                carpeta += "/";
            //haciendo login

            Control.CheckForIllegalCrossThreadCalls = false;
            url_login = string.Format(url_login, client_id, redirect_uri);

            wb = new WebBrowser();
            wb.DocumentCompleted += wb_DocumentCompleted;
            //Thread t = new Thread(Iniciar);
            //t.Start();
            try
            {
                wb.Navigate(new Uri(url_login));
            }
            catch (Exception ex)
            {
                if (error != null)
                    error(rutaArchivo, new Exception("Ocurrió un error al intentar loguearse.", ex));
            }
        }
        Boolean intentoLogin = false;
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                String titulo = wb.Document.Url.ToString();
                if (titulo.Contains("access_token=") && Token == null)
                {
                    String Fragment = wb.Document.Url.Fragment;
                    int start = Fragment.IndexOf("#access_token=");
                    int end = Fragment.IndexOf("&token_type=");
                    Fragment = Fragment.Substring(start, end).Replace("#access_token=", "");
                    Token = string.Format("bearer {0}", Fragment);
                    if (!Token.Equals(""))
                    {
                        //iniciar subida aqui
                        WebBrowserHelper.ClearCache();
                        Thread t = new Thread(IniciarSubida);
                        t.Start();
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
            catch (Exception ex)
            {
                if (error != null)
                    error(rutaArchivo, ex);
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

                wb.Document.GetElementById(idEmailInput).InnerText = usuario;
                wb.Document.GetElementById(idPassInput).InnerText = password;

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
        private void SubirArchivoDirectamente(String nombreArchivo, byte[] bytesArchivo)
        {
            try
            {
                APIRest api = new APIRest();
                api.Method = "PUT";
                //api.Token = this.Token;
                api.API = "https://content.dropboxapi.com/1";
                api.ContentType = "application/octet-stream";
                api.ByteData = bytesArchivo;
                string rutaDropbox = carpeta + nombreArchivo;
                api.URI = "/files_put/auto/" + rutaDropbox + "?access_token=" + this.Token.Replace("bearer ", "");

                dynamic drive = api.HacerPeticion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private String SubirArchivoPorChunks(String nombreArchivo, byte[] bytesArchivo, String uploadID_offset)
        {
            try
            {
                APIRest api = new APIRest();
                api.Method = "PUT";
                //api.Token = this.Token;
                api.API = "https://content.dropboxapi.com/1";
                api.ContentType = "application/octet-stream";
                api.ByteData = bytesArchivo;
                //string rutaDropbox = carpeta + nombreArchivo;
                if (uploadID_offset != null)
                {
                    String upload_id = uploadID_offset.Split('|')[0];
                    String offset = uploadID_offset.Split('|')[1];
                    uploadID_offset = "upload_id=" + upload_id + "&offset=" + offset + "&";
                }
                api.URI = "/chunked_upload?" + uploadID_offset + "access_token=" + this.Token.Replace("bearer ", "");

                dynamic drive = api.HacerPeticion();

                return drive.upload_id + "|" + drive.offset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CommitArchivoPorChunks(String nombreArchivo, String uploadID_offset)
        {
            try
            {
                APIRest api = new APIRest();
                api.Method = "POST";
                //api.Token = this.Token;
                api.API = "https://content.dropboxapi.com/1";
                //api.ContentType = "application/octet-stream";
                //api.ByteData = bytesArchivo;
                string rutaDropbox = carpeta + nombreArchivo;
                if (uploadID_offset != null)
                {
                    String upload_id = uploadID_offset.Split('|')[0];
                    uploadID_offset = "upload_id=" + upload_id + "&";
                }
                api.URI = "/commit_chunked_upload/auto/" + rutaDropbox + "?" + uploadID_offset + "access_token=" + this.Token.Replace("bearer ", "");

                dynamic drive = api.HacerPeticion();

                //return drive.upload_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SubirArchivoPorFragmentos(String nombreArchivo, byte[] archivoBytes)
        {
            if (archivoBytes.Length > longitudFragmento)
            {
                String uploadID_offset = null;
                for (long i = 0; i < archivoBytes.Length; i++)
                {
                    byte[] fragmento = null;
                    if (archivoBytes.Length - i > longitudFragmento)
                        fragmento = new byte[longitudFragmento];
                    else
                    {
                        fragmento = new byte[archivoBytes.Length - i];
                        longitudFragmento = archivoBytes.Length - i;
                    }
                    int indice = 0;
                    for (; indice < longitudFragmento; indice++)
                    {
                        if (i == archivoBytes.Length)
                            break;
                        fragmento[indice] = archivoBytes[i];
                        i++;
                    }
                    Boolean seSubioFragmento = false;
                    for (int intento = 0; intento < 3; intento++)
                    {
                        try
                        {
                            uploadID_offset = SubirArchivoPorChunks(nombreArchivo, fragmento, uploadID_offset);

                            seSubioFragmento = true;
                            break;
                        }
                        catch { }
                    }
                    if (!seSubioFragmento)
                    {
                        throw new Exception("Se supero el total de intentos para subir un fragmento del archivo.");

                    }
                    i--;

                    double porcentaje = (i * 100) / archivoBytes.Length;
                    MostrarPorcentaje(porcentaje);
                }
                CommitArchivoPorChunks(nombreArchivo, uploadID_offset);
                MostrarPorcentaje(100);
            }
            else
            {
                try
                {
                    MostrarPorcentaje(0);
                    SubirArchivoDirectamente(nombreArchivo, archivoBytes);
                    MostrarPorcentaje(100);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrió un error al subir el archivo.", ex);
                }
            }
        }
        private void IniciarSubida(object obj)
        {
            try
            {
                SubirArchivoPorFragmentos(Herramientas.Archivos.Archivo.ObtenerNombreArchivo(this.rutaArchivo), Herramientas.Archivos.Archivo.CargarArchivoAByteArray(rutaArchivo));
                if (envioTerminado != null)
                {
                    envioTerminado(rutaArchivo);
                }
            }
            catch (Exception ex)
            {
                if (error != null)
                    error(rutaArchivo, ex);
            }
        }
        private void MostrarPorcentaje(double porcentaje)
        {
            if (porcentajeEnviado != null)
                porcentajeEnviado(porcentaje);
        }
    }
}
