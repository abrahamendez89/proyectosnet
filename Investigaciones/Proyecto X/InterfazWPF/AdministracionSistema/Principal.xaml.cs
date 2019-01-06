using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using Dominio.Sistema;
using Dominio;
using Herramientas.Archivos;
using System.Windows.Media.Animation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using System.Threading;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.Xaml;
using System.Threading.Tasks;
using System.Xml;
using Herramientas.ORM;
using Herramientas.ORM.Memoria;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    /// 
    public partial class Principal : Window
    {
        public enum RazonCierre
        {
            TerminoSistema = 0,
            CerroSesion = 1,
            BloqueoSesion = 2
        }

        public delegate void SeCerroSistema(RazonCierre razon);
        public event SeCerroSistema seCerroSistema;


        private ManejadorDB manejador;

        private List<String> fondos = new List<string>();
        public static _sis_Usuario usuario;

        private Variable variablesDATA;
        private Variable variablesCONN;
        private int versionActual = 0;
        private String CambiosEnVersion = "";
        private int tiempoConmnutacion = 5000;
        private int tiempoRepeticionProceso = 10000;
        private int tiempoActualizacionModulos = 15000;
        private int tiempoMonitoreoMouse = 5000;
        private int segundosParaAutoBloqueo = 300;
        public Boolean EstaEnBloqueo { get; set; }
        public Boolean EstaActivadaActualizacion { get; set; }
        private String nombreSistema = "Sistema";
        private String rolstr = "No definido";
        private String servidor;
        private String baseDatos;
        private Boolean EstaEnModoPruebas = false;
        public static String ipLocal;
        public static String ipInternet = "Obteniendo...";
        public static Principal Instancia;
        private ManejadorDB manejadorUsuario;
        private List<String> ImagenesToolBoxFormularios = new List<string>();
        public static System.Windows.Forms.Screen GetPantallaSistema()
        {
            System.Windows.Forms.Screen PantallaSistema = System.Windows.Forms.Screen.FromHandle(
       new System.Windows.Interop.WindowInteropHelper(Principal.Instancia).Handle);
            return PantallaSistema;
        }
        public Principal()
        {
            //constructor vacío
        }
        public static void CentrarVentanaEnPantalla(Window window)
        {
            int alto = Login.GetPantallaSistema().Bounds.Height;
            int ancho = Login.GetPantallaSistema().Bounds.Width;
            window.Top = alto - window.Height - (Login.GetPantallaSistema().Bounds.Y * -1) - ((alto - window.Height) / 2);
            window.Left = Login.GetPantallaSistema().Bounds.X + ancho - window.Width - ((ancho - window.Width) / 2);
        }
        public Principal(_sis_Usuario usuario, ManejadorDB manejador)
        {
            InitializeComponent();
            //referenciaWindow = this;
            contenedorVentanas.AsignarManejador(manejador);
            //AlmacenObjetos.seBorroAlmacen += AlmacenObjetos_seBorroAlmacen;
            HerramientasWindow.EstablecerPrincipal(this);
            Principal.usuario = usuario;

            Instancia = this;


            ObjetoBase.UsuarioLogueado = usuario.Cuenta;
            variablesDATA = new Variable("data.conf");
            variablesCONN = new Variable("conn.conf");
            this.Icon = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Sistema.png"));
            servidor = HerramientasWindow.DesencriptarConMD5(variablesCONN.ObtenerValorVariable<String>("ServidorInstancia"));
            baseDatos = HerramientasWindow.DesencriptarConMD5(variablesCONN.ObtenerValorVariable<String>("BaseDeDatos"));
            ipLocal = HerramientasWindow.ObtenerIPLocal();
            //Log.UbicacionArchivo = "log.txt";
            versionActual = variablesDATA.ObtenerValorVariable<int>("version_actual");


            EstaEnModoPruebas = usuario.BRecibeVersionesPrueba;
            if (EstaEnModoPruebas)
                variablesDATA.GuardarValorVariable("esta_en_modo_pruebas", "si");
            else
                variablesDATA.GuardarValorVariable("esta_en_modo_pruebas", "no");
            //EstaEnModoPruebas = variablesDATA.ObtenerValorVariable<Boolean>("esta_en_modo_pruebas");
            variablesDATA.ActualizarArchivo();
            Thread obtenerIpInternet = new Thread(ObtenerIpInternet);
            obtenerIpInternet.Start();


            this.manejador = manejador; // = new ManejadorDB();

            IsVisibleChanged += Principal_IsVisibleChanged;
            IsVisibleChanged += HerramientasWindow.referenciaWindow_IsVisibleChanged;




            _sis_DatosSistema datosSistema = manejador.Cargar<_sis_DatosSistema>(_sis_DatosSistema.ConsultaTodos);
            if (datosSistema != null)
            {
                if (datosSistema.BImagenIcono != null)
                    this.Icon = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenIcono);
                img_fondo.Source = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenFondoPrincipal);
                nombreSistema = datosSistema.STitulo;
                //if (datosSistema.ISegundosAutobloqueo != 0)
                segundosParaAutoBloqueo = datosSistema.ISegundosAutobloqueo;
            }


            menu.clickElementoMenuOpcion += menu_clickElementoMenuOpcion;
            menu.AltoElementoMenu = 70;
            menu.AnchoElementoMenu = 70;
            menu.SeparacionElementoMenu = 1;

            PreviewMouseDown += Principal_PreviewMouseDown;
            MouseMove += Principal_MouseMove;
            KeyDown += Principal_KeyDown;

            contenedorToolbox_Sistema.MouseEnter += contenedorToolbox_Sistema_MouseEnter;
            contenedorToolbox_Sistema.MouseLeave += contenedorToolbox_Sistema_MouseLeave;

            contenedorToolbox.MouseEnter += contenedorToolbox_MouseEnter;
            contenedorToolbox.MouseLeave += contenedorToolbox_MouseLeave;

            contenedorToolbox_Sistema.clickOpcionSistema += contenedorToolbox_Sistema_clickOpcionSistema;
            contenedorToolbox.clickOpcionVentana += contenedorToolbox_clickOpcionVentana;

            contenedorVentanas.clickVentana += contenedorVentanas_clickVentana;
            CargarModulos();
            CargarToolboxSistema();


            ReiniciarAutobloqueo();
            //IniciarWorkers();
            cargarMarcadores();
            //new DirectoryInfo((@"Imagenes\Iconos\Formularios")).GetFiles().Select(o => o.Name).ToArray();
            ImagenesToolBoxFormularios.AddRange(new DirectoryInfo((@"Imagenes\Iconos\Sistema")).GetFiles().Select(o => o.Name).ToArray());
            ImagenesToolBoxFormularios.AddRange(new DirectoryInfo((@"Imagenes\Iconos\Formularios")).GetFiles().Select(o => o.Name).ToArray());

            CentrarVentanaEnPantalla(this);
        }
        private void serializar()
        {

            string savedButton = System.Windows.Markup.XamlWriter.Save(contenedorVentanas);
            StringReader stringReader = new StringReader(savedButton);
            XmlReader xmlReader = XmlReader.Create(stringReader);


            StringBuilder outstr = new StringBuilder();
            //this code need for right XML fomating 
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            XamlDesignerSerializationManager dsm =
              new XamlDesignerSerializationManager(XmlWriter.Create(outstr, settings));
            //this string need for turning on expression saving mode 
            dsm.XamlWriterMode = XamlWriterMode.Expression;
            System.Windows.Markup.XamlWriter.Save(contenedorVentanas, dsm);

            String convertido = outstr.ToString();
            StringReader stringReader2 = new StringReader(convertido);
            XmlReader xmlReader2 = XmlReader.Create(stringReader2);
            ContenedorVentanas readerLoadButton = (ContenedorVentanas)System.Windows.Markup.XamlReader.Load(xmlReader2);



            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ContenedorVentanas));
            //using (var writer = new StreamWriter(@"d:\test.xml"))
            //{
            //    serializer.Serialize(writer, contenedorVentanas);
            //}



            //MemoryStream ms = new MemoryStream();
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(ms, this); /// data is the class i wanna serialize.
            //ms.Seek(0, 0);
            //StreamReader rdr = new StreamReader(ms);
            //string str = rdr.ReadToEnd();
            //byte[] byteArray = Encoding.ASCII.GetBytes(str);

            //XamlSerializer xs = new XamlSerializer();
            //xs.DiscoverAttachedProperties(typeof(AttachedProps));
            //string text = xs.Serialize(this.nestedObject);

        }
        //void AlmacenObjetos_seBorroAlmacen()
        //{
        //    Dispatcher.Invoke(new Action(() =>
        //    {
        //        HerramientasWindow.MostrarNotificacion("Almacen de objetos", "Se eliminó el almacen de objetos.");
        //    }));
        //}
        private void ObtenerIpInternet()
        {
            ipInternet = HerramientasWindow.ObtenerIPInternet();
        }

        void Principal_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType() != typeof(Menu))
                menu.OcultarMenusOpciones();
        }


        private Thread tControlador;
        private Boolean ConmutacionActivada;

        private void cargarMarcadores()
        {
            try
            {
                //_sis_FormularioPermisosPorRol form = manejador.Cargar<_sis_FormularioPermisosPorRol>(_sis_FormularioPermisosPorRol.ConsultaPorID, new List<object>() { 1 });
                //_sis_FormularioPermisosPorRol form2 = manejador.Cargar<_sis_FormularioPermisosPorRol>(_sis_FormularioPermisosPorRol.ConsultaPorID, new List<object>() { 2 });
                //_sis_FormularioPermisosPorRol form3 = manejador.Cargar<_sis_FormularioPermisosPorRol>(_sis_FormularioPermisosPorRol.ConsultaPorID, new List<object>() { 3 });

                //ElementoMarcador e = new ElementoMarcador(form);
                //barraMarcadores.AgregarElementoMarcador(e);
                //ElementoMarcador e2 = new ElementoMarcador(form2);
                //barraMarcadores.AgregarElementoMarcador(e2);
                //ElementoMarcador e3 = new ElementoMarcador(form3);
                //barraMarcadores.AgregarElementoMarcador(e3);

                //e.clickElementoMarcador += e_clickElementoMarcador;
                //e2.clickElementoMarcador += e_clickElementoMarcador;
                //e3.clickElementoMarcador += e_clickElementoMarcador;
            }
            catch { }
        }

        void e_clickElementoMarcador(_sis_FormularioPermisosPorRol formulario)
        {
            contenedorVentanas.AgregarFormularioConPermisos(formulario, this.tamPrincipal);
        }
        private void IniciarControladorConmutaciones()
        {
            tControlador = new Thread(ControladorConmutaciones);
            tControlador.Start();
        }
        private void ControladorConmutaciones()
        {
            while (true)
            {
                Thread.Sleep(tiempoConmnutacion);
                ConmutacionActivada = !ConmutacionActivada;
            }
        }
        public void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            inicio = DateTime.Now;
        }

        public void Principal_MouseMove(object sender, MouseEventArgs e)
        {
            inicio = DateTime.Now;
        }

        public void ReiniciarAutobloqueo()
        {
            inicio = DateTime.Now;
            //if (bw_MonitoreoMouse != null && !bw_MonitoreoMouse.IsBusy) bw_MonitoreoMouse.RunWorkerAsync();
            //if (bw_monitoreoAccesoNoPermitido != null && !bw_monitoreoAccesoNoPermitido.IsBusy) bw_monitoreoAccesoNoPermitido.RunWorkerAsync();
            //if (bw_monitoreoActualizaciones != null && !bw_monitoreoActualizaciones.IsBusy) bw_monitoreoActualizaciones.RunWorkerAsync();
            TerminarWorkers();
            IniciarWorkers();


        }
        #region control de workers
        private void IniciarWorkers()
        {

            IniciarControladorConmutaciones();
            bw_monitoreoActualizaciones = new BackgroundWorker();
            bw_monitoreoActualizaciones.RunWorkerCompleted += BuscadorActualizaiones_Completo;
            bw_monitoreoActualizaciones.DoWork += BuscadorActualizaciones_DoWork;
            bw_monitoreoActualizaciones.WorkerSupportsCancellation = true;
            bw_monitoreoActualizaciones.RunWorkerAsync();

            bw_monitoreoAccesoNoPermitido = new BackgroundWorker();
            bw_monitoreoAccesoNoPermitido.DoWork += BuscadorAccesosNoPermitidos_DoWork;
            bw_monitoreoAccesoNoPermitido.WorkerSupportsCancellation = true;
            bw_monitoreoAccesoNoPermitido.RunWorkerAsync();

            bw_MonitoreoMouse = new BackgroundWorker();
            bw_MonitoreoMouse.DoWork += bw_MonitoreoMouse_DoWork;
            bw_MonitoreoMouse.WorkerSupportsCancellation = true;
            bw_MonitoreoMouse.RunWorkerAsync();

            if (bw_actualizadorModulos == null)
            {
                bw_actualizadorModulos = new BackgroundWorker();
                bw_actualizadorModulos.DoWork += bw_actualizadorModulos_DoWork;
                bw_actualizadorModulos.WorkerSupportsCancellation = true;
                bw_actualizadorModulos.RunWorkerAsync();
            }
        }
        private void TerminarWorkers()
        {
            if (tControlador != null) tControlador.Abort();
            ConmutacionActivada = false;
            if (bw_MonitoreoMouse != null) bw_MonitoreoMouse.CancelAsync();
            if (bw_monitoreoAccesoNoPermitido != null) bw_monitoreoAccesoNoPermitido.CancelAsync();
            if (bw_monitoreoActualizaciones != null) bw_monitoreoActualizaciones.CancelAsync();
            //if (bw_actualizadorModulos != null) bw_actualizadorModulos.CancelAsync();
        }
        #endregion
        #region actualizador de modulos
        void bw_actualizadorModulos_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bw_actualizadorModulos.CancellationPending)
            {
                try
                {
                    Thread.Sleep(tiempoActualizacionModulos);
                    Dispatcher.Invoke(new Action(() =>
                    {
                        CargarModulos();
                        //BloquearSistema();
                        //HerramientasWindow.Mensaje("El Sistema se ha bloqueado por inactividad, ingrese nuevamente.", "Bloqueo de sistema");
                    }));
                }
                catch { }
            }
        }
        Boolean primeraVez = true;
        Boolean detectoEntradaOtroLado = false;
        private delegate void DelegadoCerradoOtroLogueo();
        private void CargarModulos()
        {
            try
            {
                if (manejadorUsuario == null) manejadorUsuario = new ManejadorDB();
                //usuario.EliminarCache();
                usuario = manejadorUsuario.Cargar<_sis_Usuario>(_sis_Usuario.consultaPorID, new List<Object>() { usuario.Id });
                if (usuario.RolSistema != null)
                {
                    List<_sis_Contenedor> contenedores = null;
                    //usuario.EliminarCache();
                    usuario.Manejador = manejadorUsuario;
                    try
                    {
                        if (usuario.RolSistema != null)
                        {
                            TimeSpan diferenciaTRol = (DateTime.Now - usuario.RolSistema.DtFechaModificacion);
                            if (menu.NumeroElementos == 0 || (diferenciaTRol.TotalSeconds <= tiempoActualizacionModulos / 1000))
                            {
                                menu.LimpiarElementos();
                                contenedores = usuario.RolSistema.Contenedores;
                                if (contenedores != null)
                                {
                                    foreach (_sis_Contenedor contenedor in contenedores)
                                    {
                                        contenedor.EliminarCache();
                                        menu.AgregarElementoMenu(contenedor);
                                    }
                                }
                                menu.DibujarElementos(menu.ActualWidth);
                                //---
                                if (usuario.RolSistema != null)
                                    rolstr = usuario.RolSistema.Nombre;
                                Title = nombreSistema + " [versión " + versionActual + "] - Usuario: " + usuario.Cuenta + " - Rol: " + rolstr;
                                if (!primeraVez)
                                    HerramientasWindow.MostrarNotificacion("Se cargo su perfil y los accesos al sistema.", "Perfil cargado");
                                else
                                    primeraVez = false;
                            }
                            else
                                usuario.RestaurarUltimaCache();
                        }
                        if (usuario.ContenedorEspecial != null)
                        {
                            TimeSpan diferenciaTContenedorEspecial = (DateTime.Now - usuario.ContenedorEspecial.DtFechaModificacion);
                            if ((diferenciaTContenedorEspecial.TotalSeconds <= tiempoActualizacionModulos / 1000))
                            {
                                menu.EliminarOpcionesEspeciales();
                                if (usuario.ContenedorEspecial != null)
                                {
                                    if (usuario.ContenedorEspecial.FormulariosPermisos != null && usuario.ContenedorEspecial.FormulariosPermisos.Count > 0)
                                    {
                                        usuario.ContenedorEspecial.ImagenAsociada = new _sis_ImagenAsociada();
                                        usuario.ContenedorEspecial.ImagenAsociada.Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\carpeta_especial.png");
                                        menu.AgregarElementoMenu(usuario.ContenedorEspecial);

                                    }
                                }
                                menu.DibujarElementos(menu.ActualWidth);
                                Title = nombreSistema + " [versión " + versionActual + "] - Usuario: " + usuario.Cuenta + " - Rol: " + rolstr;
                                HerramientasWindow.MostrarNotificacion("Se cargo su perfil y los accesos al sistema.", "Perfil cargado");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
                else if (!usuario.EsAdministradorDeSistema)
                {
                    menu.LimpiarElementos();
                    HerramientasWindow.MensajeAdvertencia("Actualmente no tiene asignado un Rol. Favor de contactar al administrador del Sistema para la asignación de un Rol.", "Información");
                }
                else
                {
                    menu.LimpiarElementos();
                }

                if (usuario.SMensajeDeIntentoDeConexionEnOtroEquipo != null && !usuario.SMensajeDeIntentoDeConexionEnOtroEquipo.Equals(""))
                {
                    if (usuario.EsAdministradorDeSistema || (usuario.RolSistema != null && usuario.RolSistema.EsAdministradorDeSistema))
                    {


                        //Dispatcher.Invoke(new Action(() =>
                        //{
                        //    HerramientasWindow.MensajeInformacion(usuario.SMensajeDeIntentoDeConexionEnOtroEquipo, "Atención!");
                        //}));
                        if (!detectoEntradaOtroLado)
                        {
                            detectoEntradaOtroLado = true;
                            DelegadoCerradoOtroLogueo delegadoParaCerrar = CerrarSistemaPorOtroLogueo;
                            HerramientasWindow.MostrarNotificacion(usuario.SMensajeDeIntentoDeConexionEnOtroEquipo, "Atención!", new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\advertencia3.png"), delegadoParaCerrar, 5);

                        }
                    }
                    else
                    {
                        HerramientasWindow.MostrarNotificacion(usuario.SMensajeDeIntentoDeConexionEnOtroEquipo, "Detección de intento de acceso", new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\advertencia3.png"), 0);
                        usuario.SMensajeDeIntentoDeConexionEnOtroEquipo = "";
                        usuario.EsModificado = true;
                        manejador.GuardarAsincrono("", usuario);
                    }
                }

            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MensajeError(ex, ex.Message, "Error al cargar modulos de usuario.");
                }));
            }
        }

        private void CerrarSistemaPorOtroLogueo()
        {
            usuario.SMensajeDeIntentoDeConexionEnOtroEquipo = "";
            usuario.EsModificado = true;
            manejador.Guardar(usuario);
            System.Windows.Application.Current.Shutdown();
        }
        #endregion
        #region para actualizacion de modulos
        private BackgroundWorker bw_actualizadorModulos;
        private ManejadorDB manejadorActualizadorModulos;
        #endregion
        #region para actualizaciones
        private BackgroundWorker bw_monitoreoActualizaciones;
        private ManejadorDB manejadorActualizaciones;
        private int versionServidor;
        #endregion
        #region para accesos no permitidos
        private BackgroundWorker bw_monitoreoAccesoNoPermitido;
        private ManejadorDB manejadorAccesosNoPermitidos;
        #endregion
        #region para saber si se movio el mouse
        private BackgroundWorker bw_MonitoreoMouse;
        private DateTime inicio;
        #endregion
        #region monitoreo de mouse
        void bw_MonitoreoMouse_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bw_MonitoreoMouse.CancellationPending)
            {
                Thread.Sleep(tiempoMonitoreoMouse);
                DateTime final = DateTime.Now;
                TimeSpan duracion = final - inicio;
                double segundosTotales = duracion.TotalSeconds;
                int segundos = duracion.Seconds;
                if (segundosParaAutoBloqueo == 0) continue;
                if (segundosTotales >= segundosParaAutoBloqueo && segundosParaAutoBloqueo != 0)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        BloquearSistema();
                        HerramientasWindow.Mensaje("El Sistema se ha bloqueado por inactividad, ingrese nuevamente.", "Bloqueo de sistema");
                    }));
                }
            }
        }
        #endregion
        #region buscarActualizaciones
        //mostrando mensaje
        private delegate void MostrarMensajeActualizacion();
        void BuscadorActualizaiones_Completo(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.IsVisible && hayActualizacionDisponible)
            {
                MostrarMensajeActualizacion delegado = mostrarVersionDisponible;
                HerramientasWindow.MostrarNotificacion("Existe una actualización disponible, favor de cerrar el sistema y entrar nuevamente para descargar la actualización.", "Actualización disponible", new Bitmap(@"Imagenes\Iconos\Sistema\actualizacion.png"), delegado, false);
            }
        }
        //mensaje del delegado
        private void mostrarVersionDisponible()
        {
            String titulo = "Se encuentra la versión [" + versionServidor + "] disponible del sistema para descargar, ¿Desea actualizar ahora mismo?\n\n" + "              *** Cambios incluidos ***\n";
            String cambiosListados = "";
            String[] cambios = CambiosEnVersion.Split('|');
            foreach (String cambio in cambios)
            {
                cambiosListados += "-" + cambio + "\n";
            }
            cambiosListados = cambiosListados.Substring(0, cambiosListados.Length - 1);
            if (HerramientasWindow.MensajeSIoNO(titulo + cambiosListados, "Actualización disponible"))
            {
                CerrarSistemaYAbrirActualizador();
            }
        }
        private void CerrarSistemaYAbrirActualizador()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\Aplicacion.exe";
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory + @"\";
            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Close()));
            Close();
            if (!IsVisible)
            {
                System.Windows.Application.Current.Shutdown();
                p.Start();
                p.Dispose();
            }
        }
        //proceso de inicio de busqueda
        Boolean hayActualizacionDisponible = false;
        void BuscadorActualizaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            manejadorActualizaciones = new ManejadorDB();
            while (!bw_monitoreoActualizaciones.CancellationPending)// && Visibility == System.Windows.Visibility.Visible)
            {
                Thread.Sleep(tiempoRepeticionProceso);
                //if (ConmutacionActivada)
                hayActualizacionDisponible = HayActualizacion();
                if (hayActualizacionDisponible)
                {
                    return;
                }
            }
        }
        //consulta realizada
        private Boolean HayActualizacion()
        {

            DataTable resultado = null;

            if (EstaEnModoPruebas)
                resultado = manejadorActualizaciones.EjecutarConsulta(_sis_VersionesDeSistema.ConsultaExisteNuevaVersionPruebas);
            else
                resultado = manejadorActualizaciones.EjecutarConsulta(_sis_VersionesDeSistema.ConsultaExisteNuevaVersion);

            if (resultado.Rows.Count > 0)
            {
                versionServidor = Convert.ToInt32(resultado.Rows[0][0]);
                CambiosEnVersion = Convert.ToString(resultado.Rows[0][1]);
                if (versionActual != versionServidor)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region buscarAccesosNoPermitidos
        //mostrando mensaje
        private delegate void MostrarMensajeAccesoNoPermitido();
        private delegate void DelegadoCerrado();
        private Boolean SeCerroNotificacionAlertaAcceso = true;
        void BuscadorAccesosNoPermitidos_DoWork(object sender, DoWorkEventArgs e)
        {
            manejadorAccesosNoPermitidos = new ManejadorDB();
            //buscar
            Boolean estaActivo = false;
            while (!bw_monitoreoAccesoNoPermitido.CancellationPending)
            {
                Thread.Sleep(tiempoRepeticionProceso);
                //if (ConmutacionActivada)
                //{
                Dispatcher.Invoke(new Action(() => estaActivo = this.IsActive));
                if (SeCerroNotificacionAlertaAcceso && estaActivo && hayAccesoNoPermitido())
                {
                    SeCerroNotificacionAlertaAcceso = false;
                    MostrarMensajeAccesoNoPermitido delegado = mostrarAccesoNoPermitido;
                    DelegadoCerrado delegadoCerrado = SeCerroNotificacionDeAccesoNoPermitido;
                    Dispatcher.Invoke(new Action(() => HerramientasWindow.MostrarNotificacion("Se ha detectado un intruso, favor de revisar en Más información.", "Alerta!!", new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\advertencia3.png"), delegado, delegadoCerrado, true)));

                }
                //}
            }
        }
        private void SeCerroNotificacionDeAccesoNoPermitido()
        {
            SeCerroNotificacionAlertaAcceso = true;
        }
        private void mostrarAccesoNoPermitido()
        {
            AccesoNoPermitido accesoNoPermitido = new AccesoNoPermitido();
            accesoNoPermitido.ShowDialog();
        }
        private Boolean hayAccesoNoPermitido()
        {
            _sis_LimiteAccesosFallidosAlcanzado limiteAlcanzado = manejadorAccesosNoPermitidos.Cargar<_sis_LimiteAccesosFallidosAlcanzado>(_sis_LimiteAccesosFallidosAlcanzado.ConsultaAccesosFallidosNoVerificados);

            if (limiteAlcanzado != null)
            {
                return true;
            }
            return false;
        }
        #endregion
        private void CargarToolboxSistema()
        {
            if (usuario.RolSistema != null || usuario.EsAdministradorDeSistema)
            {
                Bitmap foto = new Bitmap(@"Imagenes\Iconos\Sistema\usuario.png");
                if (usuario.ImagenAsociada != null && usuario.ImagenAsociada.Imagen != null)
                    foto = usuario.ImagenAsociada.Imagen;
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = usuario.SNombreCompleto, Imagen = foto });
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Bloquear sistema", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\bloquearSistema.png") });
                //contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Guardar sesión", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\guardarSesion.png") });
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Soporte", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\soporte.png") });
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Borrar memoria temporal", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\memoriaRam.png") });
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Información técnica", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\informacion_tecnica.png") });
                if (usuario.EsAdministradorDeSistema || usuario.RolSistema.EsAdministradorDeSistema)
                    contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Configuración", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\configuracion.png") });
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Cerrar sesión", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\cerrarSesion.png") });
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Cerrar sistema", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\salir.png") });
            }
            else
            {
                contenedorToolbox_Sistema.AgregarElementoSistema(new ElementoSistema() { Titulo = "Cerrar sistema", Imagen = new Bitmap(@"Imagenes\Iconos\Sistema\salir.png") });
            }
            contenedorToolbox_Sistema.DibujarElementos();
        }

        void menu_clickElementoMenuOpcion(_sis_FormularioPermisosPorRol formulario)
        {
            contenedorVentanas.AgregarFormularioConPermisos(formulario, this.tamPrincipal);
        }
        public void AgregarVentanaSinPermisos(Window window, String nombreformulario)
        {
            contenedorVentanas.AgregarWindow(window, nombreformulario, this.tamPrincipal);

        }
        void Principal_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((Boolean)e.NewValue == false)
            {
                contenedorVentanas.CerrarVentanas();
            }
            else
            {
                inicio = DateTime.Now;
                HerramientasWindow.EstablecerPadre(this);
            }
        }
        private Window ventanaActual = null;
        private String[] metodosPermitidos = null;
        void contenedorVentanas_clickVentana(Window window, String[] metodosPermitidos)
        {
            ventanaActual = window;
            this.metodosPermitidos = metodosPermitidos;
            if (window == null)
                contenedorToolbox.BorrarElementos();
            else
            {
                LlenarToolbox();
                //contenedorVentanas.Redimensionar(ventanaActual, this.tamPrincipal);
            }
        }

        private void LlenarToolbox()
        {
            contenedorToolbox.BorrarElementos();
            if (ventanaActual != null)
            {
                Type t = ventanaActual.GetType();

                MethodInfo[] metodos = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                foreach (MethodInfo metodo in metodos)
                {
                    if (metodo.Name.ToLower().StartsWith("toolbox_"))
                    {
                        String nombre = metodo.Name.Replace("toolbox_", "").Replace("_", " ");
                        if (((metodosPermitidos != null && metodosPermitidos.Contains(nombre))) || metodosPermitidos == null)
                        {
                            ElementoToolBox tool = new ElementoToolBox();
                            tool.Metodo = metodo.Name;
                            tool.Titulo = nombre;
                            tool.Tipo = t;

                            tool.Imagen = HerramientasWindow.BitmapAImageSource(ObtenerImagenRecursoCoincide(nombre));

                            if (tool.Imagen == null)
                            {
                                String nombreImagen = ObtenerArchivoImagenCoincide(nombre);
                                if (!nombreImagen.Trim().Equals(""))
                                    tool.Imagen = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Formularios\" + nombreImagen));
                                else
                                    tool.Imagen = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Tarea.png"));

                            }
                            contenedorToolbox.AgregarToolBox(tool);
                        }
                    }
                    else if (metodo.Name.ToLower().StartsWith("_toolbox_"))
                    {
                        String nombre = metodo.Name.Replace("_toolbox_", "").Replace("_", " ");
                        ElementoToolBox tool = new ElementoToolBox();
                        tool.Metodo = metodo.Name;
                        tool.Titulo = nombre;
                        tool.Tipo = t;


                        tool.Imagen = HerramientasWindow.BitmapAImageSource(ObtenerImagenRecursoCoincide(nombre));

                        if (tool.Imagen == null)
                        {
                            String nombreImagen = ObtenerArchivoImagenCoincide(nombre);
                            if (!nombreImagen.Trim().Equals(""))
                                tool.Imagen = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Formularios\" + nombreImagen));
                            else
                                tool.Imagen = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Tarea.png"));
                        }
                        contenedorToolbox.AgregarToolBox(tool);
                    }
                }
                contenedorToolbox.DibujarElementos();
            }

        }
        private Bitmap ObtenerImagenRecursoCoincide(String nombreMetodo)
        {
            List<_sis_ImagenRecurso> imagenesRecursos = HerramientasWindow.ObtenerImagenesRecursos(manejador);
            if (imagenesRecursos == null) return null;
            foreach (_sis_ImagenRecurso imagen in imagenesRecursos)
            {
                if (nombreMetodo.ToLower().Trim().Contains(imagen.St_nombreImagen.ToLower().Trim()))
                    return imagen.Bm_Imagen;
            }
            return null;
        }
        private String ObtenerArchivoImagenCoincide(String nombreMetodo)
        {
            foreach (String nombreArchivo in ImagenesToolBoxFormularios)
            {
                if (nombreMetodo.ToLower().Trim().Contains(nombreArchivo.ToLower().Trim().Replace(".png", "").Replace(".jpeg", "").Replace(".jpg", "")))
                    return nombreArchivo;
            }
            return "";
        }
        private void BloquearSistema()
        {
            HerramientasWindow.OcultarNotificaciones();
            EstaEnBloqueo = true;
            TerminarWorkers();
            Hide();
            if (seCerroSistema != null)
                seCerroSistema(RazonCierre.BloqueoSesion);
        }
        void contenedorToolbox_Sistema_clickOpcionSistema(string titulo, Bitmap imagen)
        {
            //try
            //{
            //    throw new Exception("hubo un error de nulo aqui.");
            //}
            //catch (Exception ex)
            //{
            //    HerramientasWindow.MensajeError(ex, ex.Message, "Error");
            //}

            if (titulo.Equals("Configuración"))
            {
                _sis_Formulario formulario = new _sis_Formulario();
                formulario.ImagenAsociada = new _sis_ImagenAsociada() { Imagen = imagen };
                formulario.STituloFormulario = titulo;
                formulario.BPermiteMultiples = false;
                formulario.SReferenciaFormulario = "InterfazWPF.AdministracionSistema.ConfiguracionSistema";
                contenedorVentanas.AgregarFormularioSinPermisos(formulario, this.tamPrincipal);

            }
            else if (titulo.Equals("Borrar memoria temporal"))
            {
                AlmacenObjetos.BorrarAlmacen();
                HerramientasWindow.MostrarNotificacion("Se ha eliminado la memoria temporal exitosamente.", "Borrado de memoria temporal", imagen);
            }
            else if (titulo.Equals("Guardar sesión"))
            {

                serializar();
                //no implementado


                //byte[] bytes = fastBinaryJSON.BJSON.ToBJSON(this); //para convertir en bytes

                //Principal principal = (Principal)fastBinaryJSON.BJSON.ToObject(bytes); //para retornar el objeto pero existe un problema al usar Bitmap
                //principal.Show();
            }
            else if (titulo.Equals("Cerrar sistema"))
            {
                seTerminaraSistema = true;
                Close();
                if (seCerraraVentana)
                    System.Windows.Application.Current.Shutdown();
            }
            else if (titulo.Equals("Información técnica"))
            {
                //HerramientasWindow.MostrarNotificacion(@"-Serv\Inst: " + servidor + "\n-BD: " + baseDatos + "\n-IP(LAN|WAN): " + ipLocal + "|" + ipInternet + "\n-Versión: " + versionActual, "Información técnica", new Bitmap(@"Imagenes\Iconos\Sistema\informacion_tecnica.png"), 0);

                HerramientasWindow.MostrarNotificacion(Login.DatosConexion+"\n-Versión: " + versionActual, "Información técnica", new Bitmap(@"Imagenes\Iconos\Sistema\informacion_tecnica.png"), 0);
            }
            else if (titulo.Equals("Cerrar sesión"))
            {
                Close();
            }
            else if (titulo.Equals("Bloquear sistema"))
            {
                BloquearSistema();
            }
            else if (titulo.Equals("Soporte"))
            {
                //if (!usuario.EsAdministradorDeSistema)
                //{
                EnviarSoporte enviar = new EnviarSoporte();
                enviar.Show();
                //}

            }
            else if (titulo.Equals(usuario.SNombreCompleto))
            {
                ConfiguracionUsuario conf = new ConfiguracionUsuario(usuario);
                conf.ShowDialog();
                //if(usuario.ImagenAsociada != null && usuario.ImagenAsociada.Imagen != null)
                //    contenedorToolbox_Sistema
            }
        }
        #region Ejecución de toolbox Opciones
        BackgroundWorker procesoToolbox;
        void contenedorToolbox_clickOpcionVentana(Type tipo, string titulo, string metodo)
        {
            try
            {
                MethodInfo metodoEjec = tipo.GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                metodoEjec.Invoke(ventanaActual, new object[] { });
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error al ejecutar el método.", "Error");
            }


            //HerramientasWindow.MostrarNotificacion("Proceso ejecutandose", "Se esta ejecutando la operación en segundo plano, puede continuar trabajando.");
            //MethodInfo metodoEjec = tipo.GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);

            //procesoToolbox = new BackgroundWorker();
            //procesoToolbox.RunWorkerCompleted += procesoToolbox_RunWorkerCompleted;
            //procesoToolbox.DoWork += procesoToolbox_DoWork;
            //procesoToolbox.WorkerSupportsCancellation = true;
            //procesoToolbox.RunWorkerAsync(metodoEjec);
        }
        void procesoToolbox_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //MethodInfo metodoEjec = (MethodInfo)e.Argument;
                //ThreadPool.QueueUserWorkItem(delegate { metodoEjec.Invoke(ventanaActual, new object[] { }); });

                //Dispatcher.InvokeAsync(
                //new Action(() =>
                //{
                MethodInfo metodoEjec = (MethodInfo)e.Argument;

                metodoEjec.Invoke(ventanaActual, new object[] { });
                //}), DispatcherPriority.Background);
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MensajeError(ex, ex.Message, "Error");
                }));
            }
        }

        void procesoToolbox_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        #endregion
        #region toolbox
        Boolean entroToolbox = false;
        Boolean entroToolboxSistema = false;
        void contenedorToolbox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (entroToolbox)
            {
                Storyboard mouseEnter = (Storyboard)this.FindResource("salioToolBox");
                mouseEnter.Begin();
                entroToolbox = false;
            }
        }

        void contenedorToolbox_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard mouseEnter = (Storyboard)this.FindResource("EntroAToolBox");
            mouseEnter.Begin();
            entroToolbox = true;
        }
        void contenedorToolbox_Sistema_MouseLeave(object sender, MouseEventArgs e)
        {
            if (entroToolboxSistema)
            {
                Storyboard mouseEnter = (Storyboard)this.FindResource("salioAMenu");
                mouseEnter.Begin();
                entroToolboxSistema = false;
            }
        }

        void contenedorToolbox_Sistema_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard mouseEnter = (Storyboard)this.FindResource("entroAMenu");
            mouseEnter.Begin();
            entroToolboxSistema = true;
        }

        #endregion
        private System.Windows.Size tamPrincipal;
        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            this.tamPrincipal = e.NewSize;
            menu.DibujarElementos(menu.ActualWidth);
            contenedorVentanas.Redimensionar(ventanaActual);//, e.NewSize);
        }
        private Boolean seCerraraVentana;
        private Boolean seTerminaraSistema;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (contenedorVentanas.CantidadVentanas > 0 && !HerramientasWindow.MensajeSIoNOAdvertencia("Si cierra el sistema puede perder la información con la que está trabajando. ¿Desea continuar?", "Atención"))
            {
                e.Cancel = true;
                seCerraraVentana = false;
            }
            else if (!EstaEnBloqueo)
            {
                seCerraraVentana = true;
                EstaEnBloqueo = false;
                HerramientasWindow.CerrarNotificaciones();
                if (bw_monitoreoAccesoNoPermitido == null || bw_monitoreoAccesoNoPermitido == null || bw_MonitoreoMouse == null)
                    HerramientasWindow.MensajeErrorSimple("Ha ocurrido un error y los 'Workers' se han detenido antes de tiempo. Verificar con sistemas.", "Error con workers");
                try
                {
                    bw_monitoreoActualizaciones.CancelAsync();
                    bw_monitoreoAccesoNoPermitido.CancelAsync();
                    bw_MonitoreoMouse.CancelAsync();
                    bw_actualizadorModulos.CancelAsync();
                    tControlador.Abort();
                }
                catch { }

                if (seCerroSistema != null)
                {
                    if (seTerminaraSistema)
                        seCerroSistema(RazonCierre.TerminoSistema);
                    else
                        seCerroSistema(RazonCierre.CerroSesion);
                }

                ///HerramientasWindow.CerrarVentanasEmergentes();
                Thread actualizarEquipo = new Thread(ActualizarEquipoRegistrado);
                actualizarEquipo.Start();
            }

        }
        private void ActualizarEquipoRegistrado()
        {
            try
            {
                ManejadorDB manejadorOtro = new ManejadorDB();
                _sis_EquiposRegistrados equipoRegistrado = manejadorOtro.Cargar<_sis_EquiposRegistrados>(_sis_EquiposRegistrados.ConsultaPorNombreEquipo, new List<object>() { Environment.MachineName });
                if (equipoRegistrado == null) equipoRegistrado = new _sis_EquiposRegistrados();
                equipoRegistrado.Manejador = manejadorOtro;
                equipoRegistrado.SNombreEquipo = Environment.MachineName;
                equipoRegistrado.UltimoUsuarioConexion = usuario;
                equipoRegistrado.BEstaBloqueado = false;
                equipoRegistrado.BEstaConectado = false;
                equipoRegistrado.EsModificado = true;
                manejadorOtro.Guardar(equipoRegistrado);

                usuario.Manejador = manejadorOtro;
                usuario.BEstaConectadoAlSistema = false;
                usuario.EsModificado = true;
                manejadorOtro.Guardar(usuario);

            }
            catch (Exception ex)
            {
                //Dispatcher.Invoke(new Action(() =>
                //{
                //    HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error al actualizar la información del equipo.");
                //}));
            }
        }

    }
}

