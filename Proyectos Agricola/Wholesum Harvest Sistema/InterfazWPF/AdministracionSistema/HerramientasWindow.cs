using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing.Imaging;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using Herramientas.Cifrado;
using System.Net;
using System.Net.Sockets;
using AForge.Video.DirectShow;
using AForge.Video;
using LogicaNegocios;
using System.Text.RegularExpressions;
using Dominio.Sistema;
using System.Windows.Threading;
using Herramientas.Archivos;
using Herramientas.WPF;
using Dominio;
using Herramientas.Conversiones;
using InterfazWPF.AdministracionSistema.ControlesUsuario;
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema
{
    public class HerramientasWindow
    {
        #region notificaciones
        static int notificacionesEnPantalla = 5;
        static Boolean[] activos = new Boolean[notificacionesEnPantalla];
        static Notificacion[] notificaciones = new Notificacion[notificacionesEnPantalla];
        public static void CerrarNotificaciones()
        {
            try
            {
                for (int i = 0; i < activos.Length; i++)
                {
                    if (notificaciones[i] != null)
                    {
                        notificaciones[i].Close();
                    }
                }
            }
            catch (System.Windows.Media.Animation.AnimationException an) { }

        }
        public static int ObtenerRowSeleccionadoDataGrid(object sender, MouseButtonEventArgs e)
        {
            return Herramientas.WPF.Utilidades.ObtenerRowSeleccionadoDataGrid(sender, e);
        }
        public static String ObtenerValorVariable(ManejadorDB manejador, String nombreVariable)
        {
            _sis_VariableGlobal variable = manejador.Cargar<_sis_VariableGlobal>(_sis_VariableGlobal.ConsultaPorNombre, new List<object>() { nombreVariable });
            if (variable == null)
            {
                GuardarValorVariableGlobal(manejador, nombreVariable, null);
                return "";
            }
            else
            {
                return variable.St_valor;
            }

        }
        public static void MostrarVisorConsultas(String titulo, DataTable dt)
        {
            VisorConsultas visor = new VisorConsultas();
            visor.MostrarConsulta(titulo, dt);
            MostrarVentana(visor, true);
        }
        public static void GuardarValorVariableGlobal(ManejadorDB manejador, String nombreVariable, String valorVariable)
        {
            _sis_VariableGlobal variable = manejador.Cargar<_sis_VariableGlobal>(_sis_VariableGlobal.ConsultaPorNombre, new List<object>() { nombreVariable });
            if (variable == null) variable = manejador.CrearObjeto<_sis_VariableGlobal>();
            variable.St_Nombre = nombreVariable;
            variable.St_valor = valorVariable;
            variable.EsModificado = true;
            manejador.GuardarAsincrono("", variable);
        }
        public static void AgregarColumnaConBindingADataGridView(System.Windows.Controls.DataGrid dgv, String header, String binding)
        {
            System.Windows.Controls.DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            textColumn.CanUserSort = false;
            textColumn.Binding = new System.Windows.Data.Binding(binding);
            dgv.Columns.Add(textColumn);
        }
        public static System.Drawing.Color ObtenerTonalidadOscuraDeColor(System.Drawing.Color color)
        {

            String stCol = color.ToString().Replace("#", "");

            String r = stCol.Substring(0, 2);
            String v = stCol.Substring(2, 2);
            String a = stCol.Substring(4, 2);

            double ir = color.R;//Convert.ToInt32(r, 16);
            double iv = color.G;//Convert.ToInt32(v, 16);
            double ia = color.B;//Convert.ToInt32(a, 16);

            double factor = 40;

            if (ir - factor >= 0) ir -= factor;
            if (iv - factor >= 0) iv -= factor;
            if (ia - factor >= 0) ia -= factor;

            System.Drawing.Color colorNuevo = System.Drawing.Color.FromArgb((byte)ir, (byte)iv, (byte)ia);

            return colorNuevo;
        }
        public static System.Windows.Media.Color ObtenerTonalidadOscuraDeColor(System.Windows.Media.Color color)
        {

            String stCol = color.ToString().Replace("#", "");

            String r = stCol.Substring(0, 2);
            String v = stCol.Substring(2, 2);
            String a = stCol.Substring(4, 2);

            double ir = color.R;//Convert.ToInt32(r, 16);
            double iv = color.G;//Convert.ToInt32(v, 16);
            double ia = color.B;//Convert.ToInt32(a, 16);

            double factor = 40;

            if (ir - factor >= 0) ir -= factor;
            if (iv - factor >= 0) iv -= factor;
            if (ia - factor >= 0) ia -= factor;

            System.Windows.Media.Color colorNuevo = System.Windows.Media.Color.FromRgb((byte)ir, (byte)iv, (byte)ia);

            return colorNuevo;
        }
        public static void OcultarNotificaciones()
        {
            try
            {
                for (int i = 0; i < activos.Length; i++)
                {
                    if (notificaciones[i] != null)
                    {
                        notificaciones[i].Hide();
                    }
                }
            }
            catch (System.Windows.Media.Animation.AnimationException an) { }
        }
        public static void EstablecerPadre(Window window)
        {
            for (int i = 0; i < activos.Length; i++)
            {
                if (notificaciones[i] != null)
                {
                    notificaciones[i].Owner = window;
                    notificaciones[i].Show();
                }
            }
        }
        public static void CentrarVentanaEnPantalla(Window window)
        {
            int alto = Principal.GetPantallaSistema().Bounds.Height;
            int ancho = Principal.GetPantallaSistema().Bounds.Width;
            window.Top = alto - window.Height - (Principal.GetPantallaSistema().Bounds.Y * -1) - ((alto - window.Height) / 2);
            window.Left = Principal.GetPantallaSistema().Bounds.X + ancho - window.Width - ((ancho - window.Width) / 2);
        }
        private static void MostrarNotificacionPrivado(String titulo, String mensaje, Bitmap imagen, int SegundosAMostrar, Delegate delegadoMasInformacion, Delegate delegadoCerrar, Boolean cerrarDespuesDeMasInformacion, Boolean EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos)
        {
            try
            {
                int alto = Principal.GetPantallaSistema().Bounds.Height;
                int ancho = Principal.GetPantallaSistema().Bounds.Width;

                int posicion = -1;
                for (int i = 0; i < activos.Length; i++)
                {
                    if (!activos[i])
                    {
                        posicion = i;
                        break;
                    }
                }
                if (posicion >= 0)
                {
                    activos[posicion] = true;
                    if (imagen == null)
                        imagen = new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\informacion.png");
                    Notificacion n = new Notificacion(titulo, mensaje, imagen, SegundosAMostrar, posicion, delegadoMasInformacion, delegadoCerrar, cerrarDespuesDeMasInformacion, EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos);
                    notificaciones[posicion] = n;
                    n.WindowStartupLocation = WindowStartupLocation.Manual;

                    n.Top = alto - 50 - (Principal.GetPantallaSistema().Bounds.Y * -1) - 133 * (posicion + 1);
                    n.Left = Principal.GetPantallaSistema().Bounds.X + ancho - 359;
                    n.Topmost = true;
                    n.Show();

                    n.seCerroNotificacion += n_seCerroNotificacion;
                }
            }


            catch (InvalidOperationException ioe)
            {
                Log.EscribirLog(ioe.Message + ": " + ioe.StackTrace);
            }
        }

        public static void MostrarNotificacion(String mensaje, String titulo, Bitmap imagen, Delegate delegado, Delegate delegadoCerrado, Boolean CerrarDespuesDeMasInformacion)
        {
            MostrarNotificacionPrivado(titulo, mensaje, imagen, 0, delegado, delegadoCerrado, CerrarDespuesDeMasInformacion, false);
        }
        public static void MostrarNotificacion(String mensaje, String titulo, Bitmap imagen, Delegate delegadoMasInformacion, Boolean CerrarDespuesDeMasInformacion)
        {
            MostrarNotificacionPrivado(titulo, mensaje, imagen, 0, delegadoMasInformacion, null, CerrarDespuesDeMasInformacion, false);
        }
        public static void MostrarNotificacion(String mensaje, String titulo, Bitmap imagen, int SegundosAMostrar)
        {
            MostrarNotificacionPrivado(titulo, mensaje, imagen, SegundosAMostrar, null, null, false, false);
        }
        public static void MostrarNotificacion(String mensaje, String titulo, Bitmap imagen)
        {
            MostrarNotificacionPrivado(titulo, mensaje, imagen, 5, null, null, false, false);
        }
        public static void MostrarNotificacion(String mensaje, String titulo, Bitmap imagen, int SegundosAMostrar, Delegate delegadoMasInformacion)
        {
            MostrarNotificacionPrivado(titulo, mensaje, imagen, SegundosAMostrar, delegadoMasInformacion, null, false, false);
        }
        public static void MostrarNotificacion(String mensaje, String titulo)
        {
            MostrarNotificacionPrivado(titulo, mensaje, new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\informacion.png"), 5, null, null, false, false);
        }
        public static void MostrarNotificacion(String mensaje, String titulo, Bitmap imagen, Delegate delegadoEjecutarDespuesDeTiempoTranscurrido, int SegundosAMostrar)
        {
            MostrarNotificacionPrivado(titulo, mensaje, imagen, SegundosAMostrar, null, delegadoEjecutarDespuesDeTiempoTranscurrido, false, true);
        }
        static void n_seCerroNotificacion(int posicion)
        {
            activos[posicion] = false;
            notificaciones[posicion] = null;
        }
        #region notificaciones dentro de un hilo
        public static void MostrarNotificacionHilo(Window window, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
               {
                   MostrarNotificacion(mensaje, titulo);
               }));
        }
        public static void MostrarNotificacionHilo(Window window, String mensaje, String titulo, Bitmap imagen, Delegate delegadoEjecutarDespuesDeTiempoTranscurrido, int SegundosAMostrar)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MostrarNotificacion(mensaje, titulo,imagen,delegadoEjecutarDespuesDeTiempoTranscurrido, SegundosAMostrar);
            }));
        }
        public static void MostrarNotificacionHilo(Window window, String mensaje, String titulo, Bitmap imagen, int SegundosAMostrar, Delegate delegadoMasInformacion)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MostrarNotificacion(mensaje, titulo, imagen, SegundosAMostrar,delegadoMasInformacion);
            }));
        }
        public static void MostrarNotificacionHilo(Window window, String mensaje, String titulo, Bitmap imagen)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MostrarNotificacion(mensaje, titulo, imagen);
            }));
        }
        public static void MostrarNotificacionHilo(Window window, String mensaje, String titulo, Bitmap imagen, int SegundosAMostrar)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MostrarNotificacion(mensaje, titulo, imagen,SegundosAMostrar);
            }));
        }
        public static void MostrarNotificacionHilo(Window window, String mensaje, String titulo, Bitmap imagen, Delegate delegadoMasInformacion, Boolean CerrarDespuesDeMasInformacion)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MostrarNotificacion(mensaje, titulo, imagen, delegadoMasInformacion, CerrarDespuesDeMasInformacion);
            }));
        }
        #endregion
        #endregion
        #region fotos webcam
        private static Bitmap fotoWebCam = null;
        private static void video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            fotoWebCam = (Bitmap)eventArgs.Frame.Clone();
        }
        public static Bitmap ObtenerFotoDeWebCam()
        {
            try
            {
                VideoCaptureDevice FuenteDeVideo = null;
                FilterInfoCollection DispositivosDeVideo;
                fotoWebCam = null;
                DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (DispositivosDeVideo.Count > 0)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivosDeVideo[0].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(video_NuevoFrame);
                    if (FuenteDeVideo != null)
                    {
                        FuenteDeVideo.Start();
                        DateTime inicio = DateTime.Now;
                        while (fotoWebCam == null)
                        {
                            DateTime final = DateTime.Now;
                            TimeSpan duracion = final - inicio;
                            double segundosTotales = duracion.TotalSeconds;
                            int segundos = duracion.Seconds;
                            if (segundos == 3)
                            {
                                break;
                            }
                        }
                        FuenteDeVideo.SignalToStop();
                    }
                }
                return fotoWebCam;
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "HerramientasWindow.ObtenerFotoDeWebCam: " + ex.Message, "Error");
                return null;
            }
        }
        #endregion
        #region encriptacion
        public static String EncriptarConMD5(String textoACifrar)
        {
            return CifradoMD5.EncriptarTexto(textoACifrar);
        }
        public static String DesencriptarConMD5(String textoACifrar)
        {
            return CifradoMD5.DesencriptarTexto(textoACifrar);
        }

        public static String EncriptarConAES(String textoACifrar)
        {
            return CifradoAES.EncriptarTexto(textoACifrar);
        }
        public static String DesencriptarConAES(String textoACifrar)
        {
            return CifradoAES.DesencriptarTexto(textoACifrar);
        }
        #endregion
        #region mensajes en pantalla
        #region mensajes para hilos
        public static void MensajeHilo(Window window, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                Mensaje(mensaje, titulo);
            }));
        }
        public static Boolean MensajeSIoNOHilo(Window window, String pregunta, String titulo)
        {
            Boolean respuesta = false;
            window.Dispatcher.Invoke(new Action(() =>
            {
                respuesta = MensajeSIoNO(pregunta, titulo);
            }));
            return respuesta;
        }
        public static Boolean MensajeSIoNOAdvertenciaHilo(Window window, String pregunta, String titulo)
        {
            Boolean respuesta = false;
            window.Dispatcher.Invoke(new Action(() =>
            {
                respuesta = MensajeSIoNOAdvertencia(pregunta, titulo);
            }));
            return respuesta;
        }
        public static void MensajeErrorHilo(Window window, Exception exception, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MensajeError(exception, mensaje, titulo);
            }));
        }
        public static void MensajeErrorSimpleHilo(Window window, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MensajeErrorSimple(mensaje, titulo);
            }));
        }
        public static void MensajeAdvertenciaHilo(Window window, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MensajeAdvertencia(mensaje, titulo);
            }));
        }
        public static void MensajeAdvertenciaAltaHilo(Window window, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MensajeAdvertenciaAlta(mensaje, titulo);
            }));
        }
        public static void MensajeInformacionHilo(Window window, String mensaje, String titulo)
        {
            window.Dispatcher.Invoke(new Action(() =>
            {
                MensajeInformacion(mensaje, titulo);
            }));
        }

        #endregion
        public static void MensajeInformacion(String mensaje, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(null, mensaje, titulo, VentanaDialogo.VentanaDialogoTipoVentana.Informacion);
            dialogo.Close();
        }

        public static void MensajeExc(MensajeException mensaje)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(mensaje);
            dialogo.Close();
        }
        public static Boolean MensajeLogicaNegocios(Exception exception, string mensaje, string titulo, LogicaNegocios.MensajeException.TipoMensaje tipoMensaje)
        {
            if (tipoMensaje == MensajeException.TipoMensaje.Pregunta)
                return MensajeSIoNO(mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.PreguntaAdvertencia)
                return MensajeSIoNOAdvertencia(mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.Advertencia)
                MensajeAdvertencia(mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.AdvertenciaAlta)
                MensajeAdvertenciaAlta(mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.Error)
                MensajeError(exception, mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.ErrorSimple)
                MensajeErrorSimple(mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.Informacion)
                MensajeInformacion(mensaje, titulo);
            else if (tipoMensaje == MensajeException.TipoMensaje.Mensaje)
                Mensaje(mensaje, titulo);
            return true;

        }
        public static void Mensaje(String mensaje, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(null, mensaje, titulo, VentanaDialogo.VentanaDialogoTipoVentana.Mensaje);
            dialogo.Close();
        }
        public static Boolean MensajeSIoNO(String pregunta, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            if (dialogo.Mostrar(null, pregunta, titulo, VentanaDialogo.VentanaDialogoTipoVentana.Pregunta) == VentanaDialogo.VentanaDialogoBoton.Si)
            {
                dialogo.Close();
                return true;
            }
            else
            {
                dialogo.Close();
                return false;
            }
        }
        public static Boolean MensajeSIoNOAdvertencia(String pregunta, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            if (dialogo.Mostrar(null, pregunta, titulo, VentanaDialogo.VentanaDialogoTipoVentana.PreguntaAdvertencia) == VentanaDialogo.VentanaDialogoBoton.Si)
            {
                dialogo.Close();
                return true;
            }
            else
            {
                dialogo.Close();
                return false;
            }
        }
        public static void MensajeError(Exception exception, String mensaje, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(exception, mensaje, titulo, VentanaDialogo.VentanaDialogoTipoVentana.Error);
            dialogo.Close();
        }
        public static void MensajeErrorSimple(String mensaje, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(null, mensaje, titulo, VentanaDialogo.VentanaDialogoTipoVentana.ErrorSimple);
            dialogo.Close();
        }
        public static void MensajeAdvertencia(String mensaje, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(null, mensaje, titulo, VentanaDialogo.VentanaDialogoTipoVentana.Advertencia);
            dialogo.Close();
        }
        public static void MensajeAdvertenciaAlta(String mensaje, String titulo)
        {
            VentanaDialogo dialogo = new VentanaDialogo();
            dialogo.Mostrar(null, mensaje, titulo, VentanaDialogo.VentanaDialogoTipoVentana.AdvertenciaAlta);
            dialogo.Close();
        }
        #endregion
        #region herramientas
        public static _sis_Usuario ObtenerUsuarioLogueado()
        {
            return Principal.usuario;
        }
        private static List<_sis_ImagenRecurso> listaImagenes;
        public static List<_sis_ImagenRecurso> ObtenerImagenesRecursos(ManejadorDB manejador)
        {
            if (listaImagenes == null)
            {
                listaImagenes = manejador.CargarLista<_sis_ImagenRecurso>(_sis_ImagenRecurso.ConsultaTodos);
            }
            return listaImagenes;
        }
        public static Boolean UsuarioLogueadoTienePermisosEdicionCatalogo()
        {
            _sis_Usuario usu = Principal.usuario;
            if (usu.BPuedeAccederCatalogoRapido)
                return true;
            if (usu.RolSistema != null && usu.RolSistema.BPuedeAccederCatalogoRapido)
                return true;

            return false;
        }
        public static DataTable DataGridtoDataTable(System.Windows.Controls.DataGrid dg)
        {
            dg.SelectionMode = DataGridSelectionMode.Extended;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
            string[] Lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ',' });
            int Cols = Fields.GetLength(0);

            DataTable dt = new DataTable();
            for (int i = 0; i < Cols; i++)
                dt.Columns.Add(Fields[i].ToUpper(), typeof(string));
            DataRow Row;
            for (int i = 1; i < Lines.GetLength(0) - 1; i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                {
                    Row[f] = Fields[f];
                }
                dt.Rows.Add(Row);
            }
            return dt;
        }
        public static String ObtenerIPLocal()
        {
            IPAddress[] IPS = Dns.GetHostAddresses(Dns.GetHostName());
            String ipLocal = "";
            foreach (IPAddress ip in IPS)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    ipLocal = ip.ToString();
            }
            return ipLocal;
        }
        public static String ObtenerIPInternet()
        {
            string strIP = "";
            try
            {
                WebClient wc = new WebClient();
                strIP = wc.DownloadString("http://checkip.dyndns.org");
                strIP = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
                wc.Dispose();
            }
            catch { }
            return strIP;
        }
        #endregion
        #region herramientas para imagenes
        public static Bitmap CargarImagenDeArchivosABitmap()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.bmp";
            Bitmap imagen = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagen = new Bitmap(ofd.FileName);
            }
            return imagen;
        }
        public static Bitmap ObtenerFotoPantalla(Window window)
        {
            Screen screen = System.Windows.Forms.Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(window).Handle);

            Bitmap bmpScreenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenshot;
        }
        private static BitmapSource BitmapToImageSource(Bitmap source)
        {
            if (source == null) return null;
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
        public static BitmapSource CargarImagenDeArchivosABitmapSource()
        {
            return BitmapToImageSource(CargarImagenDeArchivosABitmap());
        }
        public static void AgregarEventoCambiarImagen(System.Windows.Controls.Image controlImage)
        {
            controlImage.MouseDown += controlImage_MouseDown;
            controlImage.DataContext = false;
            controlImage.ToolTip = "Click izquierdo para cambiar | Click derecho para borrar";
            if (controlImage.Source == null)
                AsignarFondoBlancoImage(controlImage);
        }
        public static void AsignarFondoBlancoImage(System.Windows.Controls.Image controlImage)
        {
            var b = new Bitmap(1, 1);
            b.SetPixel(0, 0, System.Drawing.Color.White);
            controlImage.Source = BitmapToImageSource(b);
        }
        public enum FormatoImagen
        {
            JPEG = 0,
            PNG = 1
        }
        public static Bitmap ObtenerBitmapDeImageControl(System.Windows.Controls.Image controlImage, FormatoImagen formato)
        {
            if (!(Boolean)controlImage.DataContext)
                return null;

            if (formato == FormatoImagen.JPEG)
            {
                return ImageSourceABitmap(controlImage.Source, ImageFormat.Jpeg);
            }
            else if (formato == FormatoImagen.PNG)
            {
                return ImageSourceABitmap(controlImage.Source, ImageFormat.Png);
            }
            return null;

        }
        static void controlImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image controlImagen = (System.Windows.Controls.Image)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                BitmapSource imagen = HerramientasWindow.CargarImagenDeArchivosABitmapSource();
                if (imagen != null)
                {
                    controlImagen.Source = imagen;
                    controlImagen.DataContext = true;
                }
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                AsignarFondoBlancoImage(controlImagen);
                controlImagen.DataContext = false;
            }

        }
        public static ImageSource BitmapAImageSource(Bitmap imagen)
        {
            if (imagen == null) return null;
            return BitmapToImageSource(imagen);
        }
        public static ImageSource BitmapAImageSource(String rutaImagen)
        {
            try
            {
                Bitmap imagen = new Bitmap(rutaImagen);
                if (imagen == null) return null;
                return BitmapToImageSource(imagen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Bitmap ImageSourceABitmap(ImageSource imagen)
        {

            if (imagen == null) return null;

            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(imagen as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();

            return (Bitmap)Bitmap.FromStream(ms);
        }
        public static Bitmap ImageSourceABitmap(ImageSource imagen, ImageFormat formato)
        {

            if (imagen == null) return null;

            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(imagen as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();

            Bitmap imagenConvertida = (Bitmap)System.Drawing.Image.FromStream(ms);

            MemoryStream ms2 = new MemoryStream();

            imagenConvertida.Save(ms2, formato);

            return (Bitmap)Bitmap.FromStream(ms);
        }
        public static Bitmap ComprimirImagen(Bitmap imagenAComprimir, int ancho, int alto, ImageFormat formato)
        {
            if (imagenAComprimir == null) return null;
            Bitmap imagenConvertida = (Bitmap)((System.Drawing.Image)imagenAComprimir.GetThumbnailImage(ancho, alto, delegate { return false; }, System.IntPtr.Zero));
            MemoryStream ms = new MemoryStream();

            imagenConvertida.Save(ms, formato);

            return (Bitmap)Bitmap.FromStream(ms);
            //return imagenConvertida;
        }
        public static void MostrarImagenEnVisor(Bitmap imagen)
        {
            VisorImagenes visor = new VisorImagenes(imagen);
            visor.ShowDialog();
        }
        public static void MostrarImagenEnVisor(ImageSource imagen)
        {
            MostrarImagenEnVisor(ImageSourceABitmap(imagen, System.Drawing.Imaging.ImageFormat.Jpeg));
        }
        #endregion
        #region mostrar ventanas controladas
        private static Principal ventanaPrincipalAtributo;
        public static List<Window> ventanasFuera = new List<Window>();
        public Principal VentanaPrincipalReferencia { get { return ventanaPrincipalAtributo; } }
        public static void PrincipalAgregarVentana(Window ventana, String nombreVentana)
        {
            ventanaPrincipalAtributo.AgregarVentanaSinPermisos(ventana, nombreVentana);
        }
        public static void EstablecerPrincipal(Principal ventanaPrincipal)
        {
            ventanaPrincipalAtributo = ventanaPrincipal;
        }
        public static System.Windows.Size ObtenerSizePrincipal()
        {
            return new System.Windows.Size(ventanaPrincipalAtributo.ActualWidth, ventanaPrincipalAtributo.ActualHeight);
        }
        public static void PrincipalOnTOP(Boolean valor)
        {
            ventanaPrincipalAtributo.Topmost = valor;
        }
        public static void MostrarVentanaEmergenteConTools(Window ventana, Boolean SoloAbrirUna)
        {
            FormularioEmergenteConTools fom = new FormularioEmergenteConTools(ventana);
            fom.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            HerramientasWindow.MostrarVentanaDialogo(fom, SoloAbrirUna);
        }
        public static void MostrarVentanaDialogo(Window ventana, Boolean SoloAbrirUna)
        {
            if (SoloAbrirUna)
            {
                foreach (Window window in HerramientasWindow.ventanasFuera)
                {
                    if (window.GetType().FullName.Equals(ventana.GetType().FullName))
                        return;
                }
            }
            ventana.Icon = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\ventana.png"));

            //ventana.Owner = ventanaPrincipalAtributo;
            ventana.Closing += ventanaModal_Closing;
            ventana.MouseMove += ventanaPrincipalAtributo.Principal_MouseMove;
            ventana.KeyDown += ventanaPrincipalAtributo.Principal_KeyDown;
            ventana.ShowInTaskbar = true;
            ventana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            HerramientasWindow.ventanasFuera.Add(ventana);
            ventana.ShowDialog();
        }
        public static void MostrarVentana(Window ventana, Boolean SoloAbrirUna)
        {
            if (SoloAbrirUna)
            {
                foreach (Window window in HerramientasWindow.ventanasFuera)
                {
                    if (window.GetType().FullName.Equals(ventana.GetType().FullName))
                        return;
                }
            }
            ventana.Icon = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\ventana.png"));

            //ventana.Owner = ventanaPrincipalAtributo;
            ventana.Closing += ventanaModal_Closing;
            ventana.MouseMove += ventanaPrincipalAtributo.Principal_MouseMove;
            ventana.KeyDown += ventanaPrincipalAtributo.Principal_KeyDown;
            ventana.ShowInTaskbar = true;
            ventana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            HerramientasWindow.ventanasFuera.Add(ventana);
            ventana.Show();
            //ventana.Activate();
        }

        static void ventanaModal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ventanasFuera.Remove((Window)sender);
            //int total = ventanasFuera.Count;
            //for (int i = 0; i < total; i++)
            //{
            //    if (ventanasFuera[i].GetType().Name.Equals(((Window)sender).GetType().Name))
            //        ventanasFuera.RemoveAt(i);
            //    i++;
            //    total--;
            //}

        }
        public static void CerrarVentanasEmergentes()
        {
            int total = ventanasFuera.Count;
            for (int i = 0; i < total; i++)
            {
                ventanasFuera[i].Close();
                i++;
                total--;
            }
        }
        public static void referenciaWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            foreach (Window window in ventanasFuera)
            {
                if (((Window)sender).Visibility == Visibility.Hidden)
                    window.Hide();
                else
                    window.Show();
            }
        }
        #endregion

    }
}
