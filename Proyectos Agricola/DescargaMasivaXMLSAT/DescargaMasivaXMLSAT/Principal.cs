using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Herramientas.ORM;
using Herramientas.SQL;
using Dominio;
using System.Threading;
using Herramientas.Archivos;
using Herramientas.Mail;
using Herramientas.Web;

namespace DescargaMasivaXMLSAT
{
    public partial class Principal : Form
    {
        ManejadorDB manejador;
        List<_CuentaEmpresa> empresasCuentas;
        _CuentaEmpresa empresaSeleccionada;
        String cuentaOneDrive = "";// "respaldoswholesum@outlook.com";
        String passOneDrive = ""; //"Wholesum2014";
        String rutaOneDrive = "";
        Boolean usarCorreo = false;
        Boolean usarOneDrive = false;
        String emails;
        Variable var;
        public Principal()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += Principal_FormClosing;
            var = new Variable("configuracion.conf");
            emails = var.ObtenerValorVariable<String>("EMAILS");
            cuentaOneDrive = var.ObtenerValorVariable<String>("CUENTA_ONEDRIVE");
            passOneDrive = Herramientas.Cifrado.CifradoMD5.DesencriptarTexto(var.ObtenerValorVariable<String>("CONTRASEÑA_ONEDRIVE"));
            rutaOneDrive = var.ObtenerValorVariable<String>("RUTA_ONEDRIVE");
            usarCorreo = var.ObtenerValorVariable<Boolean>("USAR_RESPALDO_CORREO");
            usarOneDrive = var.ObtenerValorVariable<Boolean>("USAR_RESPALDO_ONEDRIVE");
            lbl_tarea.Text = "";

            this.Text += " - (20151102_1219)";


            wb.DocumentCompleted += wb_DocumentCompleted;
            wb.Navigate("https://portalcfdi.facturaelectronica.sat.gob.mx/");
            try
            {
                SQLite sql = new SQLite();
                sql.ConfigurarConexion("DATA.db", false);
                manejador = new ManejadorDB(sql);

                CargarLista();
            }
            catch (Exception ex)
            {
                CrearBD();
            }
        }
        Boolean respaldado = false;
        Boolean respaldandoActivo = false;
        void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!usarOneDrive)
            {
                return;
            }
            if (respaldandoActivo)
            {
                e.Cancel = true;
                Herramientas.Forms.Mensajes.Informacion("Se encuentra respaldando, espere.");
                return;
            }
            if (!respaldado)
            {
                respaldandoActivo = true;
                Herramientas.Forms.Mensajes.Informacion("Espere un momento, se hará un respaldo de su información.");
                String nombreArchivo = "RESP_DATA_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".DB";
                Herramientas.Archivos.Archivo.CopiarArchivo(Environment.CurrentDirectory + "\\DATA.DB", Environment.CurrentDirectory + "\\" + nombreArchivo);

                if (cuentaOneDrive == null || passOneDrive == null || rutaOneDrive == null || cuentaOneDrive.Trim().Equals("") || passOneDrive.Trim().Equals("") || rutaOneDrive.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Advertencia("No fue posible respaldar en OneDrive debido a que se requiere configuración.");
                    respaldado = true;
                    respaldandoActivo = false;
                    return;
                }

                OneDriveAPI api = new OneDriveAPI(cuentaOneDrive, passOneDrive);
                api.error += api_error;
                api.envioTerminado += api_envioTerminado;
                api.porcentajeEnviado += api_porcentajeEnviado;
                api.SubirArchivoACarpeta(Environment.CurrentDirectory + "\\" + nombreArchivo, rutaOneDrive);

                e.Cancel = true;
            }
        }
        void api_porcentajeEnviado(double porcentaje)
        {
            pb_progreso.Value = (int)porcentaje;
        }

        void api_envioTerminado(String rutaArchivo)
        {
            Herramientas.Archivos.Archivo.EliminarArchivo(rutaArchivo);
            Herramientas.Forms.Mensajes.Informacion("Respaldado en OneDrive Correctamente en la cuenta: "+cuentaOneDrive+".");
            respaldado = true;
            respaldandoActivo = false;
            Close();
        }

        void api_error(String rutaArchivo, Exception ex)
        {
            Herramientas.Archivos.Archivo.EliminarArchivo(rutaArchivo);
            Herramientas.Forms.Mensajes.Error("Ocurrió un error al subir a OneDrive: " + ex.Message);
            respaldado = true;
            respaldandoActivo = false;
            Close();
        }
        Boolean intentoLogueo = false;
        Boolean clckPorRFC = false;
        private void CrearBD()
        {

        }
        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!clckPorRFC)
            {
                clckPorRFC = true;
                wb.Navigate("https://cfdiau.sat.gob.mx/nidp/app/login?id=SATUPCFDiCon&sid=0&option=credential&sid=0");
            }
        }

        WebClient wc = new WebClient();
        private void descargarXML_Click(object sender, EventArgs e)
        {
            if (Bloqueado)
            {
                Herramientas.Forms.Mensajes.Informacion("Actualmente se encuentra descargando, espere a que termine la descarga actual e intente nuevamente.");
                return;
            }
            Paquete paquete = new Paquete();
            paquete.URLS = new List<string>();

            //paquete.Recibidos = Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Son XML Recibidos a tu empresa?");

            //String nombre = "";
            //if (paquete.Recibidos)
            //    nombre = "RECIBIDOS";
            //else
            //    nombre = "EMITIDOS";

            //if (!Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Seleccionaste la opción '" + nombre + "' ¿Deseas continuar?"))
            //{
            //    return;
            //}

            HtmlDocument htmlDocument = wb.Document;
            String prueba = htmlDocument.GetType().ToString();
            HtmlElementCollection htmlElementCollection = htmlDocument.Images;

            int cadIni = 0;
            int cadFin = 0;

            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                String imgUrl = htmlElement.GetAttribute("id");
                if (imgUrl.Equals("BtnDescarga"))
                {
                    imgUrl = htmlElement.OuterHtml.Replace((char)34, ' ');
                    //localizando cadena del cromprobante
                    cadIni = imgUrl.IndexOf("?Datos=") + 1;
                    cadFin = imgUrl.IndexOf("','Recuperacion')") + 1;

                    imgUrl = imgUrl.Substring(cadIni, (cadFin - cadIni) - 1);

                    imgUrl = "https://portalcfdi.facturaelectronica.sat.gob.mx/RecuperaCfdi.aspx?" + imgUrl;

                    paquete.URLS.Add(imgUrl);
                }
            }
            if (paquete.URLS.Count == 0)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Asegurese de que haya consultado CFDI en la pagina del SAT, Intente nuevamente.");
                return;
            }
            wc.Headers.Add(HttpRequestHeader.Cookie, GetGlobalCookies(wb.Document.Url.ToString()));
            Thread tDescargas = new Thread(ProcesoDescarga);
            tDescargas.Start(paquete);

            //ProcesoDescarga();

        }

        private void ProcesoDescarga(Object data)
        {
            int contadorSinDescargarError = 0;
            Bloqueado = true;
            Paquete paquete = (Paquete)data;
            String rutaTEMP = Environment.CurrentDirectory + "\\" + "TEMP\\";
            Herramientas.Archivos.Archivo.CrearCarpetaSiNoExiste(rutaTEMP);
            for (int i = 1; i <= paquete.URLS.Count; i++)
            {
                String archivoDescarga = rutaTEMP + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";
                try
                {
                    lbl_tarea.Text = "Descargando(" + i + "/" + paquete.URLS.Count + "): " + paquete.URLS[i - 1];
                }
                catch { }
                Boolean descargadoBandera = false;
                for (int j = 0; j < 3; j++)
                {
                    try
                    {
                        wc.DownloadFile(paquete.URLS[i - 1], archivoDescarga);
                        descargadoBandera = true;
                        break;
                    }
                    catch { }
                }
                if (!descargadoBandera)
                    contadorSinDescargarError++;

                double porcentaje = (100 * i) / paquete.URLS.Count;
                pb_progreso.Value = Herramientas.Conversiones.Formatos.DoubleRedondeoAEnteroArriba(porcentaje);
                try
                {
                    lbl_tarea.Text = "Descargado en: " + archivoDescarga;
                }
                catch { }

                Clasificar(archivoDescarga, paquete.Recibidos);
            }
            Herramientas.Forms.Mensajes.Informacion("Terminó con la descarga y clasificación");
            if (contadorSinDescargarError > 0)
                Herramientas.Forms.Mensajes.Error(contadorSinDescargarError + " XML no se descargaron correctamente.");
            Bloqueado = false;
            lbl_tarea.Text = "";
            pb_progreso.Value = 0;
            try
            {
                if (usarCorreo)
                {
                    Herramientas.Forms.Mensajes.Advertencia("Se hará un respaldo de la información descargada, no cierre el programa hasta que se le indique.");
                    RespaldarAlCorreoLaBD();
                }
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Error al enviar el correo de respaldo: " + ex.Message);
            }
        }

        private void RespaldarAlCorreoLaBD()
        {
            String nombreArchivo = "RESP_DATA_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".DB";
            Herramientas.Archivos.Archivo.CopiarArchivo(Environment.CurrentDirectory + "\\DATA.DB", Environment.CurrentDirectory + "\\" + nombreArchivo);

            Adjunto adj = new Adjunto();
            adj.NombreArchivo = nombreArchivo;
            adj.Tipo = Adjunto.TipoAdjunto.OTRO;
            adj.Stream = Herramientas.Archivos.Archivo.CargarArchivoAMemoria(Environment.CurrentDirectory + "\\" + nombreArchivo);

            Herramientas.Mail.EmailFormatos.correoEnviado += EmailFormatos_correoEnviado;
            Herramientas.Mail.EmailFormatos.errorEnviarCorreo += EmailFormatos_errorEnviarCorreo;
            Herramientas.Mail.EmailFormatos.EnviarMailInformacion("Respaldo de base de datos de la descarga masiva de XML.", "Respaldo de XML descargados SAT", emails, new List<Adjunto>() { adj });
            Herramientas.Archivos.Archivo.EliminarArchivo(Environment.CurrentDirectory + "\\" + nombreArchivo);
        }
        void EmailFormatos_errorEnviarCorreo(string mensajeError)
        {
            Herramientas.Forms.Mensajes.Informacion(mensajeError);
        }

        void EmailFormatos_correoEnviado()
        {
            Herramientas.Forms.Mensajes.Informacion("Se envio correctamente el correo de respaldo, puede cerrar el programa.");
        }

        private Boolean Bloqueado = false;
        private void Clasificar(String urlTemp, Boolean esRecibido)
        {
            try
            {
                lbl_tarea.Text = "Clasificando: " + urlTemp;
            }
            catch
            { }
            String archivo = Herramientas.Archivos.Archivo.LeerArchivoTexto(urlTemp);

            XML xml = new XML(urlTemp);


            String folioFactura = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio");
            String total = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total");
            String fecha = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "fecha");
            String UUID = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "UUID");

            if (UUID == null)
            {
                int indice = archivo.ToUpper().IndexOf("UUID");
                indice += 6;
                UUID = archivo.Substring(indice, 32 + 4);
            }

            DataTable dt = manejador.EjecutarConsulta("select id from _XMLCFDI where _st_uuid = '" + UUID + "'");



            String rfcEmisor = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc");
            String rfcReceptor = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc");
            DateTime fechaC = Convert.ToDateTime(fecha);
            String complemento = "";


            String rfcDestino = "";


            if (rfcEmisor.ToUpper().Trim().Equals(empresaSeleccionada.Usuario.ToUpper().Trim()))
                esRecibido = false;
            else if (rfcReceptor.ToUpper().Trim().Equals(empresaSeleccionada.Usuario.ToUpper().Trim()))
                esRecibido = true;


            if (esRecibido)
            {
                String nombreEmpresaEmisora = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "nombre");
                if (nombreEmpresaEmisora == null) nombreEmpresaEmisora = "SIN_NOMBRE";
                nombreEmpresaEmisora = nombreEmpresaEmisora.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("\"", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Trim();
                rfcDestino = nombreEmpresaEmisora + "-" + xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc");
                complemento = "RECIBIDAS";
            }
            else
            {
                String nombreEmpresaEmisora = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "nombre");
                if (nombreEmpresaEmisora == null) nombreEmpresaEmisora = "SIN_NOMBRE";
                rfcDestino = nombreEmpresaEmisora + "-" + xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc");
                nombreEmpresaEmisora = nombreEmpresaEmisora.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("\"", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Trim();
                complemento = "EMITIDAS";
            }

            if (folioFactura == null) folioFactura = "SIN_FOLIO";


            //guardando en BD
            try
            {
                if (dt.Rows.Count == 0)
                {
                    try
                    {
                        lbl_tarea.Text = "Guardando en BD: " + urlTemp;
                    }
                    catch { }
                    _XMLCFDI xmlcfdi = new _XMLCFDI();
                    xmlcfdi.Do_Monto = Convert.ToDouble(total);
                    xmlcfdi.Dt_FechaEmisionFactura = fechaC;
                    xmlcfdi.St_ContenidoXML = archivo;
                    xmlcfdi.St_FolioFactura = folioFactura;
                    xmlcfdi.St_RFCEmisor = rfcEmisor;
                    xmlcfdi.St_RFCReceptor = rfcReceptor;
                    xmlcfdi.St_UUID = UUID;
                    xmlcfdi.EsModificado = true;

                    manejador.Guardar(xmlcfdi);
                    try
                    {
                        lbl_tarea.Text = "Guardado exitoso: " + urlTemp;
                    }
                    catch { }
                }
            }
            catch
            {
                try
                {
                    lbl_tarea.Text = "Falló al guardar en BD: " + urlTemp;
                }
                catch { }
                Thread.Sleep(2000);
            }

            String rutaClasificada = Environment.CurrentDirectory + "\\" + "CLASIFICADOS\\" + empresaSeleccionada.Usuario + "\\" + complemento + "\\" + rfcDestino + "\\" + fechaC.Year + "\\" + Herramientas.Conversiones.Formatos.DatetimeANombreMesLargo(fechaC).ToUpper() + "\\";
            Herramientas.Archivos.Archivo.CrearCarpetaSiNoExiste(rutaClasificada);
            String rutaClasificado = rutaClasificada + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(fechaC) + "_" + folioFactura + "_" + total + ".xml";
            try
            {
                rutaClasificado = rutaClasificado.Trim().Replace("  ", " ");
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(rutaClasificado, archivo, false);
                Herramientas.Archivos.Archivo.EliminarArchivo(urlTemp);
            }
            catch
            {
                try
                {
                    lbl_tarea.Text = "Falló al guardar el archivo: " + urlTemp;
                }
                catch { }
                Thread.Sleep(2000);
            }
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true, PreserveSig = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);

        const int INTERNET_COOKIE_HTTPONLY = 0x2000;
        public static string GetGlobalCookies(string url)
        {
            uint datasize = 8192;
            StringBuilder cookieData = new StringBuilder(Convert.ToInt32(datasize));

            if (InternetGetCookieEx(url, null, cookieData, ref datasize, INTERNET_COOKIE_HTTPONLY, IntPtr.Zero) && cookieData.Length > 0)
            {
                return cookieData.ToString();
            }
            else
            {
                return null;
            }
        }


        private void entrarEmpresa_Click(object sender, EventArgs e)
        {
            if (empresaSeleccionada == null)
            {
                Herramientas.Forms.Mensajes.Informacion("Seleccione una empresa primero.");
                return;
            }
            try
            {
                wb.Document.GetElementById("Ecom_User_ID").InnerText = empresaSeleccionada.Usuario;
                wb.Document.GetElementById("Ecom_Password").InnerText = empresaSeleccionada.Contrasena;
                HtmlDocument document = wb.Document;
                document.GetElementById("submit").InvokeMember("Click");
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Advertencia("Asegurese de que esta ingresando mediante usuario y contraseña en el SAT.");
            }
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolicitarContrasena sol = new SolicitarContrasena();
            sol.ShowDialog();

            if (sol.EsValido)
            {

                CatalogoCuentasEmpresas cat = new CatalogoCuentasEmpresas(manejador);
                cat.ShowDialog();
                CargarLista();
            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("Contraseña incorrecta, intente de nuevo.");
            }
            sol.Close();
        }

        private void carpetaSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CargarLista()
        {
            empresasCuentas = manejador.CargarLista<_CuentaEmpresa>("select * from _CuentaEmpresa where estaDeshabilitado = 'False'");
            cmb_empresas.Items.Clear();
            foreach (_CuentaEmpresa empresa in empresasCuentas)
            {
                cmb_empresas.Items.Add(empresa.NombreEmpresa);
            }

        }

        private void cmb_empresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_empresas.SelectedItem != null)
            {
                empresaSeleccionada = empresasCuentas[cmb_empresas.SelectedIndex];
            }
        }

        private void xMLEnBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmb_empresas.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Advertencia("Primero debe seleccionar una empresa.");
                return;
            }
            XMLEnBD xml = new XMLEnBD(manejador, empresasCuentas[cmb_empresas.SelectedIndex]);
            xml.ShowDialog();
        }

        private void respaldarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolicitarContrasena sol = new SolicitarContrasena();
            sol.ShowDialog();

            if (sol.EsValido)
            {

                ConfiguracionOneDrive cat = new ConfiguracionOneDrive();
                cat.ShowDialog();
                var.LeerArchivo();
                cuentaOneDrive = var.ObtenerValorVariable<String>("CUENTA_ONEDRIVE");
                passOneDrive = Herramientas.Cifrado.CifradoMD5.DesencriptarTexto(var.ObtenerValorVariable<String>("CONTRASEÑA_ONEDRIVE"));
                rutaOneDrive = var.ObtenerValorVariable<String>("RUTA_ONEDRIVE");
            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("Contraseña incorrecta, intente de nuevo.");
            }
            sol.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            //WebBrowserHelper.ClearCache();
            //clckPorRFC = false;
            //wb.Navigate("https://portalcfdi.facturaelectronica.sat.gob.mx/");
        }


    }
    class Paquete
    {
        public Boolean Recibidos { get; set; }
        public List<String> URLS { get; set; }
    }
}
