using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace Herramientas.Web
{
    public class OneDriveAPI
    {
        private String API = "https://api.onedrive.com/v1.0";
        private String Token = null;
        private String client_id = "000000004416797A";
        private String scope = "wl.signin wl.offline_access onedrive.readwrite";
        private String redirect_uri = "https://login.live.com/oauth20_desktop.srf";
        private String url_login = "https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=token&redirect_uri={2}";
        private WebBrowser wb;
        private String usuario;
        private String password;
        private String carpeta;
        private String rutaArchivo;
        private long longitudFragmento = 5 * 1024 * 1024;
        private String rutaOneDriveDefault = "/drive/root/children/";

        public delegate void Error(String rutaArchivo, Exception ex);
        public event Error error;

        public delegate void PorcentajeEnviado(double porcentaje);
        public event PorcentajeEnviado porcentajeEnviado;

        public delegate void EnvioTerminado(String rutaArchivo);
        public event EnvioTerminado envioTerminado;

        public OneDriveAPI(String usuarioOneDrive, String passWordOneDrive)
        {
            usuario = usuarioOneDrive;
            password = passWordOneDrive;

        }
        public void SubirArchivoACarpeta(String rutaArchivoSubir, String nombreCarpetaOneDrive)
        {

            rutaArchivo = rutaArchivoSubir;
            carpeta = nombreCarpetaOneDrive;
            //haciendo login

            Control.CheckForIllegalCrossThreadCalls = false;
            url_login = string.Format(url_login, client_id, scope, redirect_uri);

            //Thread.CurrentThread.Join();

            Form form = new Form();
            wb = new WebBrowser();
            form.Controls.Add(wb);
            wb.DocumentCompleted += wb_DocumentCompleted;

            try
            {
                wb.Navigate(new Uri(url_login));
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                if (error != null)
                    error(rutaArchivo, new Exception("Ocurrió un error al intentar loguearse.", ex));
            }
        }

        public void SubirArchivoACarpetaHilo(String rutaArchivoSubir, String nombreCarpetaOneDrive)
        {

            rutaArchivo = rutaArchivoSubir;
            carpeta = nombreCarpetaOneDrive;
            //haciendo login

            Control.CheckForIllegalCrossThreadCalls = false;
            url_login = string.Format(url_login, client_id, scope, redirect_uri);

            //Thread.CurrentThread.Join();

            var th = new Thread(() =>
             {
                 using (WebBrowser wb = new WebBrowser())
                 {
                     wb.Name = "webBrowserGenerated" + Guid.NewGuid();
                     List<Control> list = new List<Control>();
                     //GetAllControl(this, list);
                     //foreach (Control control in list)
                     //{
                     //    if (control.GetType() == typeof(WebBrowser))
                     //    {
                     //        if (control.Name.StartsWith("webBrowserGenerated"))
                     //        {
                     //            control.Refresh();
                     //        }
                     //    }
                     //}
                     wb.DocumentCompleted += (sndr, e) =>
                     {
                         wb_DocumentCompleted(sndr, e);
                         Application.ExitThread();
                     };
                     wb.Navigate(url_login);
                     Application.Run();
                 }
             });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join();
        }

        Boolean intentoLogin = false;
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                wb = (WebBrowser)sender;
                String titulo = wb.Document.Title;
                if (titulo.Equals(""))
                {
                    try
                    {
                        String Fragment = wb.Document.Url.Fragment;
                        int start = Fragment.IndexOf("#access_token=");
                        int end = Fragment.IndexOf("&token_type=");
                        Fragment = Fragment.Substring(start, end).Replace("#access_token=", "");
                        Token = string.Format("bearer {0}", Fragment);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrió un error al obtener el token.", ex);
                    }
                    if (!Token.Equals(""))
                    {
                        //subir el archivo mediante un hilo
                        WebBrowserHelper.ClearCache();
                        Thread t = new Thread(IniciarSubida);
                        t.Start();
                    }
                }
                else if (wb.Document.Title.Contains("Iniciar") || wb.Document.Title.Contains("Log in"))
                {
                    if (intentoLogin)
                    {
                        throw new Exception("Usuario o contraseña invalidos, por favor verifique los datos de inicio de sesión.");
                    }
                    wb.Document.InvokeScript("evt_LoginHost_onload");
                    //ingresando los datos del login.
                    wb.Document.GetElementById("i0118").InnerText = password;
                    wb.Document.GetElementById("i0116").InnerText = usuario;
                    wb.Document.GetElementById("idSIButton9").InvokeMember("Click");
                    intentoLogin = true;

                }
                else if (wb.Document.Body.InnerHtml.ToLower().Contains("consent") || wb.Document.Url.ToString().ToLower().Contains("consent"))
                {
                    wb.Document.InvokeScript("DoSubmit");
                    //aceptando el permiso
                    wb.Document.GetElementById("idBtn_Accept").InvokeMember("Click");
                }
            }
            catch (Exception ex)
            {
                if (error != null)
                    error(rutaArchivo, ex);
            }
        }
        Boolean seSubio = false;
        private void IniciarSubida()
        {
            try
            {
                String idCarpeta = "";
                if (carpeta.Contains(@"\") || carpeta.Contains(@"/"))
                {
                    List<String> carpetas = new List<string>();
                    if (carpeta.Contains("\\"))
                        carpetas = carpeta.Split('\\').ToList<String>();
                    if (carpeta.Contains(@"/"))
                        carpetas = carpeta.Split('/').ToList<String>();
                    foreach (String carp in carpetas)
                    {
                        String id = ObtenerIDDeCarpeta(carp);
                        rutaOneDriveDefault = "/drive/items/" + id + "/children/";
                        idCarpeta = id;
                    }

                }
                else
                    idCarpeta = ObtenerIDDeCarpeta(carpeta);

                SubirArchivoPorFragmentos(this.rutaArchivo, idCarpeta);
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

        //realizar los llamados a la api rest
        private String ObtenerIDDeCarpeta(String carpetaCrear)
        {
            String idCarpeta = "";
            APIRest api = new APIRest();
            api.Method = "GET";
            api.Token = Token;
            api.API = this.API;
            api.ContentType = "application/json";
            api.URI = rutaOneDriveDefault + carpetaCrear;

            try
            {
                dynamic drive = api.HacerPeticion();
                idCarpeta = drive.id;
            }
            catch { }

            try
            {
                if (idCarpeta.Equals(""))
                    idCarpeta = CrearCarpeta(carpetaCrear);
            }
            catch (Exception ex)
            {
                throw new Exception("No fue posible crear la carpeta.", ex);
            }
            return idCarpeta;

        }
        private String CrearCarpeta(String nombreCarpeta)
        {
            try
            {
                APIRest api = new APIRest();
                api.Method = "POST";
                api.Token = this.Token;
                api.API = this.API;
                api.ContentType = "application/json";
                api.URI = rutaOneDriveDefault;
                String jsonTemp = "{\"name\": \"@folderCrear\", \"folder\": { },\"@name.conflictBehavior\": \"rename\"}".Replace("@folderCrear", nombreCarpeta);
                api.ByteData = System.Text.Encoding.UTF8.GetBytes(jsonTemp);
                dynamic drive = api.HacerPeticion();
                return drive.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SubirArchivoPorFragmentos(byte[] archivoBytes, String nombreArchivo, String FolderID)
        {
            if (archivoBytes.Length > longitudFragmento)
            {
                String urlSession = CrearSessionParaSubirArchivoPorFragmentos(nombreArchivo, FolderID);
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
                            SubirFragmentoDeArchivo(fragmento, urlSession, i - longitudFragmento, archivoBytes.Length);

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
                MostrarPorcentaje(100);
            }
            else
            {
                try
                {
                    MostrarPorcentaje(0);
                    SubirArchivoDirectamente(nombreArchivo, archivoBytes, FolderID);
                    MostrarPorcentaje(100);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrió un error al subir el archivo.", ex);
                }
            }
        }
        private void MostrarPorcentaje(double porcentaje)
        {
            if (porcentajeEnviado != null)
                porcentajeEnviado(porcentaje);
        }
        private void SubirArchivoPorFragmentos(String rutaArchivo, String FolderID)
        {
            String nombreArchivo = Path.GetFileName(rutaArchivo);
            byte[] archivoBytes = File.ReadAllBytes(rutaArchivo);
            SubirArchivoPorFragmentos(archivoBytes, nombreArchivo, FolderID);
        }
        private void SubirArchivoDirectamente(String nombreArchivo, byte[] bytesArchivo, String FolderID)
        {
            APIRest api = new APIRest();
            api.Method = "PUT";
            api.Token = this.Token;
            api.API = this.API;
            api.ContentType = "application/octet-stream";
            api.ByteData = bytesArchivo;
            api.URI = "/drive/items/" + FolderID + "/children/@nombreArchivo/content".Replace("@nombreArchivo", nombreArchivo);

            dynamic drive = api.HacerPeticion();
        }
        private void SubirFragmentoDeArchivo(byte[] fragmento, String urlSession, long indiceDesde, long totalBytes)
        {
            APIRest api = new APIRest();
            api.Method = "PUT";
            api.Token = this.Token;
            api.API = this.API;
            api.ByteData = fragmento;
            dynamic drive = api.HacerPeticion(urlSession, indiceDesde, totalBytes);

        }
        private String CrearSessionParaSubirArchivoPorFragmentos(String nombreArchivo, String carpetaID)
        {
            APIRest api = new APIRest();
            api.Method = "POST";
            api.Token = this.Token;
            api.API = this.API;
            api.ContentType = "application/json";
            api.URI = "/drive/items/{parent_item_id}:/{filename}:/upload.createSession".Replace("{parent_item_id}", carpetaID).Replace("{filename}", nombreArchivo);
            String jsonTemp = "{\"item\": {\"@name.conflictBehavior\": \"rename\",\"name\": \"@NombreArchivoSubirGrande\"}}".Replace("@NombreArchivoSubirGrande", nombreArchivo);
            api.ByteData = System.Text.Encoding.UTF8.GetBytes(jsonTemp);
            dynamic drive = api.HacerPeticion();
            return drive.uploadUrl;

        }
    }
}
