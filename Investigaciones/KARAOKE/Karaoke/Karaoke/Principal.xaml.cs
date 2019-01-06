using Herramientas.Archivos;
using Herramientas.WPF;
using Karaoke.Clases;
using Karaoke.Controles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Karaoke
{
    /// <summary>
    /// 
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Principal : Window
    {
        Disco discoSeleccionado;
        int totalDiscosMostrar = 0;
        Thread HiloSockets;
        Thread HiloSocketsBusqueda;
        Thread HiloSocketsMonitoreo;
        Thread AutoMaximizado;

        public static Principal InstanciaEstatica;

        ListaReproduccion listaReproduccion;
        List<Key> teclas = new List<Key>();
        Key keyMoneda = new Key();
        public static Bitmap disco;
        Bitmap youtubeDefault;
        String mensajeMonedas = "";
        int CreditosActuales;
        Boolean usarCreditos = false;
        Storyboard monedasAnimacion;
        Storyboard promocionAnimacion;
        public static Bitmap LogoNegocio;
        String MensajeNegocio;

        public static Boolean caduc = true;
        public static DateTime inic = DateTime.Now;
        public static Boolean noRep = false;
        int minutosUso = 15;
        int segundosMostrarLogo = 15;
        int pistasAleatorias = 15;
        Boolean activarCategoriaAleatorios = false;

        int pulsacionesMonedas = 0;
        int pulsacionesDadas = 0;

        public Principal(List<Agrupador> agrupadoresPrincipales)
        {
            InitializeComponent();

            this.Title = "KaraTube V20160120 - Desarrollado por: Abraham Méndez - abrahamendez89@hotmail.com";

            controladoresTouch.VisibleTextBox = false;
            controladoresTouch.ejecutarBusqueda += txt_buscador_ejecutarBusqueda;
            InstanciaEstatica = this;
            this.KeyDown += MainWindow_KeyDown;
            this.grd_PlayList.MouseWheel += grd_PlayList_MouseWheel;
            this.Activated += MainWindow_Activated;
            controladoresTouch.click += controladoresTouch_click;
            reproductor.terminoLaReproduccionActual += reproductor_terminoLaReproduccionActual;

            int filas = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<int>("FilasInterfaz");
            int columnas = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<int>("ColumnasInterfaz");
            discos.Columns = 5;
            discos.Rows = 2;

            CreditosActuales = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<int>("CreditosActuales");
            usarCreditos = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<Boolean>("UsarModoCreditos");
            pulsacionesMonedas = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<int>("PulsacionesMonedas");
            pulsacionesDadas = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<int>("PulsacionesDadas");

            int pistAleatorias = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<int>("PistasAleatorias");
            activarCategoriaAleatorios = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<Boolean>("HabilitarAleatorio");
            if (pistAleatorias != 0)
                pistasAleatorias = pistAleatorias;

            if (filas != 0)
                discos.Rows = filas;
            if (columnas != 0)
                discos.Columns = columnas;

            //if (!usarCreditos)
            //    txt_creditos.Visibility = System.Windows.Visibility.Hidden;

            //Herramientas.Sys.RegistroWindows.EscribirClaveWindows("", "");

            Licencia();


            this.agrupadoresPrincipales = agrupadoresPrincipales;
            this.SizeChanged += Principal_SizeChanged;
            totalDiscosMostrar = discos.Columns * discos.Rows;
            this.Closing += MainWindow_Closing;
            try
            {
                img_opciones.Source = Herramientas.WPF.Utilidades.ArchivoAImageSource(@"Imagenes\opciones.png");
                img_cerrar.Source = Herramientas.WPF.Utilidades.ArchivoAImageSource(@"Imagenes\cerrar.png");
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al cargar las imagenes de opciones.png y cerrar.png");
            }
            reproductor.maximizarYa += reproductor_maximizarYa;
            this.IsVisibleChanged += Principal_IsVisibleChanged;
            //cargando lista reproduccion guardada
            listaReproduccion = new ListaReproduccion();

            mensajeMonedas = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("MensajeModoCreditoMoneda");

            //_---------------------
            img_opciones.MouseRightButtonDown += img_opciones_MouseRightButtonDown;
            img_cerrar.MouseRightButtonDown += img_cerrar_MouseRightButtonDown;
            try
            {
                disco = new Bitmap(@"Imagenes\cd_estandar.png");
                //youtubeDefault = new Bitmap(@"Imagenes\categoria_youtube.png");
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al cargar las imagenes de cd_estandar.png.");
            }
            //ReiniciarConexionLan();
            txt_Opcion.Content = "Lista de reproducción:";
            CargarTeclas();
            //agrupadorPrincipalActual = agrupadoresPrincipales[1];

            //controlYoutube.obtenerElementoMultimedia += controlYoutube_obtenerElementoMultimedia;
            rtg_derecho.MouseDown += rtg_derecho_MouseEnter;
            rtg_izquierdo.MouseDown += rtg_izquierdo_MouseEnter;

            //reproductor.Reproducir(new ElementoMultimedia() {TipoElemento = ElementoMultimedia.TipoElementoMultimedia.YouTube, URL = @"https://www.youtube.com/watch?v=wVpC3QBjT1o&feature=player_embedded", SegundosDuracion = 200 });
            this.MouseMove += Principal_MouseMove;
            reproductor.movioMouseSobreReproductor += reproductor_movioMouseSobreReproductor;
            AutoMaximizado = new Thread(checarEstatusReproductorMedia);
            AutoMaximizado.Start();
            //controlYoutube.encontroElementos += controlYoutube_encontroElementos;

            listaReproduccion.seDescargoElemento += listaReproduccion_seDescargoElemento;
            listaReproduccion.actualizarControl += listaReproduccion_actualizarControl;

            String pantallaCompleta = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("IniciarEnPantallaCompleta");
            if (pantallaCompleta != null && pantallaCompleta.ToLower().Equals("si"))
                this.WindowStyle = System.Windows.WindowStyle.None;

            String segundosReproductorFull = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("SegundosFullScreenReproductor");
            if (segundosReproductorFull != null)
            {
                try
                {
                    int segundos = Convert.ToInt32(segundosReproductorFull);
                    segundosParaMaximizarTiempo = segundos;
                }
                catch { }
            }

            monedasAnimacion = (Storyboard)this.FindResource("creditosNuevoCredito");
            promocionAnimacion = (Storyboard)this.FindResource("animacionPromocion");



            controladoresTouch.reiniciarFechaLogo += controladoresTouch_reiniciarFechaLogo;
            rtg_rectanguloAbajo.MouseDown += rtg_rectanguloAbajo_MouseDown;
            rtg_rectanguloArriba.MouseDown += rtg_rectanguloArriba_MouseDown;


            if (listaReproduccion.ElementosLista != null && listaReproduccion.ElementosLista.Count > 0)
            {
                RecargarListaReproduccion();
                indicePlayList = 0;
            }

            Thread reproducirUltimo = new Thread(MetodoReproducirUltimo);
            reproducirUltimo.IsBackground = true;
            reproducirUltimo.Start();

            Thread hInterCambiarMensajes = new Thread(IntercambiarMensajeCreditos);
            hInterCambiarMensajes.IsBackground = true;
            hInterCambiarMensajes.Start();

            if (caduc)
            {
                Thread hChequeoTiempo = new Thread(ChequeoTiempoLibre);
                hChequeoTiempo.IsBackground = true;
                hChequeoTiempo.Start();

            }


            String logoS = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("LogotipoNegocio");
            if (logoS != null && !logoS.Equals(""))
                LogoNegocio = Herramientas.Archivos.Imagenes.StringBase64ABitmap(logoS);

            MensajeNegocio = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("MensajeNegocio") + "";
            MensajeNegocio = MensajeNegocio.ToUpper();
            if (!caduc)
            {
                controladoresTouch.LogoEmpresa = LogoNegocio;
                txt_mensajeNegocio.Text = MensajeNegocio;
            }
            else
            {
                txt_mensajeNegocio.Text = "MODO DE PRUEBA";
            }

            Thread hLogo = new Thread(MostrarLogo);
            hLogo.IsBackground = true;
            hLogo.Start();
        }

        void img_cerrar_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        void img_opciones_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Configuracion.ConfiguracionOpciones conf = new Configuracion.ConfiguracionOpciones();
            conf.ShowDialog();

            CargarTeclas();
        }

        void controladoresTouch_reiniciarFechaLogo()
        {
            ultimaTeclaOMovimiento = DateTime.Now;
        }
        DateTime ultimaTeclaOMovimiento = DateTime.Now;
        private void MostrarLogo(object obj)
        {
            DateTime segundosAnimacionPromocion = DateTime.Now;
            while (true)
            {
                double segundos = (DateTime.Now - ultimaTeclaOMovimiento).TotalSeconds;
                double segundosPromocion = (DateTime.Now - segundosAnimacionPromocion).TotalSeconds;
                if (segundos >= segundosMostrarLogo * 3)
                {
                    if (!caduc)
                        controladoresTouch.ApareceLogo();
                    Dispatcher.Invoke(new Action(() =>
                    {
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                    }));
                }
                if (segundosPromocion >= segundosMostrarLogo && !caduc)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        promocionAnimacion.Begin();
                    }));
                    segundosAnimacionPromocion = DateTime.Now;
                }
                Thread.Sleep(1000);
            }
        }

        private void ChequeoTiempoLibre(object obj)
        {
            while (true)
            {
                double minutos = (DateTime.Now - inic).TotalMinutes;
                if ((minutosUso - ((int)minutos)) >= 0)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        txt_mensajeNegocio.Text = "MODO DE PRUEBA, RESTAN: " + (minutosUso - ((int)minutos)) + " MINUTOS DE USO.";
                    }));
                }
                if (minutos > minutosUso)
                {
                    noRep = true;
                    if (reproductor.EstaReproduciendo())
                    {
                        reproductor.Stop();
                    }
                    Herramientas.Forms.Mensajes.Exclamacion("Modo de prueba concluido, compra una licencia para poder usar el KaraTube por más de " + minutosUso + " minutos continuos.");
                    return;
                }
                Thread.Sleep(30000);
            }
        }

        public static String Licencia()
        {
            String codigoLicencia = null;
            try
            {
                codigoLicencia = Herramientas.Archivos.Archivo.LeerArchivoTexto("log5net.dll");
            }
            catch
            {

            }
            if (codigoLicencia == null)
            {

                codigoLicencia = CrearLicenciaCodigo();
            }
            else
            {
                String decifrado = Herramientas.Cifrado.CifradoAES.DesencriptarTexto(codigoLicencia);
                IdentificadorLicencia lic = Herramientas.Web.JSON.ConvertirJSONAObjeto<IdentificadorLicencia>(decifrado);

                if (!lic.MAC.Equals(Herramientas.Sys.PCInfo.ObtenerMACAddress()) || lic.IDTarjetaMADRE.Equals(Herramientas.Sys.PCInfo.ObtenerIDTarjetaMadre()))
                {
                    codigoLicencia = CrearLicenciaCodigo();
                    Principal.caduc = true;
                    return codigoLicencia;
                }

                if (lic.FechaFIN != DateTime.MinValue)
                {
                    if (DateTime.Now <= lic.FechaFIN)
                    {
                        Principal.caduc = false;
                    }
                }

            }
            return codigoLicencia;
        }
        private static String CrearLicenciaCodigo()
        {
            IdentificadorLicencia iden = new IdentificadorLicencia();
            iden.FechaPrimeraVez = DateTime.Now;
            iden.IDLicencia = -1;
            iden.IDTarjetaMADRE = Herramientas.Sys.PCInfo.ObtenerMarca() + " " + Herramientas.Sys.PCInfo.ObtenerModelo();
            iden.MAC = Herramientas.Sys.PCInfo.ObtenerMACAddress();
            iden.FechaFIN = DateTime.MinValue.AddDays(1);
            iden.FechaPago = DateTime.MinValue.AddDays(1);
            iden.NombreEquipo = Environment.MachineName;
            iden.UsuarioWindows = Environment.UserName;
            iden.VersionWindows = Environment.OSVersion.VersionString;

            String json = Herramientas.Web.JSON.ConvertirObjetoAJSON<IdentificadorLicencia>(iden);
            String cifrado = Herramientas.Cifrado.CifradoAES.EncriptarTexto(json);

            Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(Environment.CurrentDirectory + "\\log5net.dll", cifrado);
            return cifrado;
        }
        private void IntercambiarMensajeCreditos(object obj)
        {
            Boolean permutado = false;
            while (true)
            {
                if (permutado)
                {

                    Dispatcher.Invoke(new Action(() =>
                    {
                        if (usarCreditos)
                        {
                            txt_creditos.Text = "CREDITOS = " + CreditosActuales;

                            if (pulsacionesDadas > 0)
                            {
                                txt_creditos.Text += " | MONEDAS " + pulsacionesDadas + " / " + pulsacionesMonedas;
                            }
                        }
                        else
                            txt_creditos.Text = "MODO LIBRE";

                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        if (usarCreditos)
                            txt_creditos.Text = mensajeMonedas;
                        else
                            txt_creditos.Text = "KARATUBE";
                    }));
                }
                permutado = !permutado;
                Thread.Sleep(6000);
            }
        }

        private void ActualizarCreditos(int operando)
        {
            if (!usarCreditos)
                return;
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            if (operando > 0)
            {
                pulsacionesDadas++;
                if (pulsacionesDadas < pulsacionesMonedas)
                {
                    var.GuardarValorVariable("PulsacionesDadas", pulsacionesDadas);
                    txt_creditos.Text = "MONEDAS = " + pulsacionesDadas + " / " + pulsacionesMonedas;
                    var.ActualizarArchivo();
                    Dispatcher.Invoke(new Action(() =>
                    {
                        monedasAnimacion.Begin();
                    }));
                    return;
                }
                else
                {
                    pulsacionesDadas = 0;
                    var.GuardarValorVariable("PulsacionesDadas", pulsacionesDadas);
                }

            }
            if (CreditosActuales + operando < 0)
            {
                return;
            }
            CreditosActuales += operando;
            var.GuardarValorVariable("CreditosActuales", CreditosActuales);
            var.ActualizarArchivo();



            txt_creditos.Text = "CREDITOS = " + CreditosActuales;

            Dispatcher.Invoke(new Action(() =>
            {
                monedasAnimacion.Begin();
            }));

            if (operando == 1 && CreditosActuales == 1) //se inserto una moneda para continuar con la reproduccion
            {
                if (!reproductor.EstaReproduciendo())
                {
                    ReproducirElementoSeleccionadoLista(0);
                }
            }
        }

        void txt_buscador_ejecutarBusqueda(string busqueda)
        {
            FiltrarEnAgrupador(busqueda);
        }

        private void MetodoReproducirUltimo(object obj)
        {
            Thread.Sleep(3000);
            Dispatcher.Invoke(new Action(() =>
            {
                reproductor.CargarUltimaReproduccion();
                reproductor.ReproducirElementoCargado();
            }));
        }

        void Principal_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == System.Windows.Visibility.Visible && soloAbrirUnaVez)
            {

            }
        }


        void reproductor_maximizarYa()
        {
            try
            {
                Reproductor rep = (Reproductor)grd_parteBaja.Children[grd_parteBaja.Children.IndexOf(reproductor)];

                grd_parteBaja.Children.Remove(rep);
                rep.Minimizo = false;
                grd_reproductor.Children.Add(rep);
                rep.Width = grd_reproductor.ActualWidth;
                rep.Height = grd_reproductor.ActualHeight;// -10;
                rep.Margin = new Thickness(0);
                Maximizado = true;
            }
            catch { }
        }

        void Principal_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (controlYoutube.Visibility == System.Windows.Visibility.Visible)
            //{
            //    controlYoutube.Redimencionar();
            //}
        }
        void controlYoutube_encontroElementos()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
            }));
        }

        void reproductor_movioMouseSobreReproductor()
        {
            if (reproductor.EstaReproduciendo())
            {
                segundosParaMaximizar = 0;
                MinimizarReproductor();
            }
        }
        int segundosParaMaximizar = 0;
        int segundosParaMaximizarTiempo = 5;
        private void checarEstatusReproductorMedia(object obj)
        {
            while (true)
            {
                if (reproductor.EstaReproduciendo() && reproductor.ElementoReproduciendo != null && reproductor.ElementoReproduciendo.TipoElemento != ElementoMultimedia.TipoElementoMultimedia.Musica)
                {
                    if (segundosParaMaximizar < segundosParaMaximizarTiempo)
                        segundosParaMaximizar++;

                    if (segundosParaMaximizar == segundosParaMaximizarTiempo)
                    {
                        Dispatcher.Invoke(new Action(() =>
                        {
                            MaximizarReproductor();
                        }));
                    }
                }
                Thread.Sleep(1000);
            }
        }

        void Principal_MouseMove(object sender, MouseEventArgs e)
        {
            if (reproductor.EstaReproduciendo())
            {
                segundosParaMaximizar = 0;
                //MinimizarReproductor();
            }
        }
        Boolean Maximizado;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }
        private void MaximizarReproductor()
        {
            if (!Maximizado && reproductor.EstaReproduciendo())
            {
                try
                {
                    Reproductor rep = (Reproductor)grd_parteBaja.Children[grd_parteBaja.Children.IndexOf(reproductor)];

                    grd_parteBaja.Children.Remove(rep);
                    rep.Minimizo = false;
                    grd_reproductor.Children.Add(rep);
                    rep.Width = grd_reproductor.ActualWidth;
                    rep.Height = grd_reproductor.ActualHeight;// -10;
                    rep.Margin = new Thickness(0);
                    Maximizado = true;
                }
                catch { }
            }
        }
        private void MinimizarReproductor()
        {
            if (Maximizado)// && reproductor.EstaReproduciendo())
            {
                try
                {
                    Reproductor rep = (Reproductor)grd_reproductor.Children[grd_reproductor.Children.IndexOf(reproductor)];
                    grd_reproductor.Children.Remove(rep);
                    grd_parteBaja.Children.Add(rep);
                    rep.Minimizo = true;

                    rep.Margin = new Thickness(0, 15, 0, 7);
                    rep.Height = 218;
                    rep.Width = 316;
                    Maximizado = false;
                }
                catch { }
            }
        }

        void rtg_izquierdo_MouseEnter(object sender, MouseEventArgs e)
        {
            //if (controlYoutube.Visibility == System.Windows.Visibility.Hidden)
            //{
            Disco d = (Disco)discos.Children[0];
            if (d.Visibility == System.Windows.Visibility.Visible)
            {
                seleccionado = 0;
                discoSeleccionado = d;
                AgrupadorGuia = d.AgrupadorAsignado;
                CargarSegmentoAnterior();

            }
            //}
            //else
            //{
            //    //controlYoutube.PaginaAnterior();
            //}
        }

        void rtg_derecho_MouseEnter(object sender, MouseEventArgs e)
        {
            //if (controlYoutube.Visibility == System.Windows.Visibility.Hidden)
            //{
            Disco d = (Disco)discos.Children[discos.Children.Count - 1];
            if (d.Visibility == System.Windows.Visibility.Visible)
            {
                seleccionado = discos.Children.Count - 1;
                discoSeleccionado = d;
                AgrupadorGuia = d.AgrupadorAsignado.Siguiente;
                CargarSiguienteSemento();

            }
            //}
            //else
            //{
            //    controlYoutube.SiguientePagina();
            //}
        }

        void grd_PlayList_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            int indice = e.Delta;

            if (indice > 0)
            {
                indicePlayList = 0;
                RecorrerArribaLista();
            }
            else
            {
                indicePlayList = 3;
                RecorrerAbajoLista();
            }

        }
        private void CargarTeclas()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            teclas.Clear();
            for (int i = 1; i <= 9; i++)
            {
                try
                {
                    String valor = var.ObtenerValorVariable<String>("TECLA_" + i);
                    KeyConverter k = new KeyConverter();
                    Key mykey = Key.Zoom;
                    if (valor != null && valor.Trim().Equals(""))
                    {
                        mykey = (Key)k.ConvertFromString("NumPad" + i);
                    }
                    else
                    {
                        mykey = (Key)k.ConvertFromString(valor);
                    }
                    teclas.Add(mykey);
                }
                catch { }
            }

            String teclaMoneda = var.ObtenerValorVariable<String>("TeclaMoneda");
            KeyConverter k2 = new KeyConverter();
            if (teclaMoneda != null && !teclaMoneda.Trim().Equals(""))
            {
                keyMoneda = (Key)k2.ConvertFromString(teclaMoneda);
            }

        }
        List<Agrupador> agrupadoresPrincipales = new List<Agrupador>();

        void frm_calificador_continuarReproduciendo()
        {
            if (listaReproduccion.ElementosLista != null && listaReproduccion.ElementosLista.Count > 0)
            {
                ReproducirElementoSeleccionadoLista(0);
            }
            else
            {
                reproductor.Limpiar();
                MinimizarReproductor();
            }
        }
        void reproductor_terminoLaReproduccionActual(Boolean fueSaltado)
        {
            Dispatcher.Invoke(new Action(() =>
            {

                ElementoMultimedia elementoReproducido = reproductor.ElementoReproduciendo;

                GuardarRegistroReproduccion(elementoReproducido);


                if (!fueSaltado && elementoReproducido.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Karaoke)
                {
                    Calificador calificador = new Calificador();
                    calificador.WindowStyle = this.WindowStyle;
                    calificador.ShowDialog();
                }
                //frm_calificador_continuarReproduciendo();
                ReproducirElementoSeleccionadoLista(0);
            }));

        }
        private void GuardarRegistroReproduccion(ElementoMultimedia elementoEstadistico)
        {
            if (elementoEstadistico.URL.ToLower().StartsWith("http"))
                return;
            Variable var = null;
            if (elementoEstadistico.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Karaoke)
                var = Compartidos.ObtenerVariablesTopKaraoke();
            else if (elementoEstadistico.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Musica)
                var = Compartidos.ObtenerVariablesTopMusica();
            else if (elementoEstadistico.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Video)
                var = Compartidos.ObtenerVariablesTopVideos();

            String renombrado = elementoEstadistico.URL + "|" + elementoEstadistico.Titulo;
            var.GuardarValorVariable(renombrado, (var.ObtenerValorVariable<Int32>(renombrado) + 1).ToString());
            var.ActualizarArchivo();
        }
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        #region sockets
        private Boolean corriendo = false;
        private void ReiniciarConexionLan()
        {
            try
            {
                if (clientSocket != null) clientSocket.Close();
                if (clientSocket2 != null) clientSocket2.Close();

                if (serverSocket2 != null) serverSocket2.Stop();
                if (serverSocket != null) serverSocket.Stop();
            }
            catch { }
            if (HiloSockets != null && HiloSockets.ThreadState != ThreadState.Stopped) HiloSockets.Abort();
            if (HiloSocketsBusqueda != null && HiloSocketsBusqueda.ThreadState != ThreadState.Stopped) HiloSocketsBusqueda.Abort();
            if (HiloSocketsMonitoreo != null && HiloSocketsMonitoreo.ThreadState != ThreadState.Stopped) HiloSocketsMonitoreo.Abort();


            //HiloSockets = new Thread(RunSockets);
            //HiloSockets.Start();
            //HiloSocketsBusqueda = new Thread(RunSocketsBusqueda);
            //HiloSocketsBusqueda.Start();
            //HiloSocketsMonitoreo = new Thread(RunSocketsMonitoreo);
            //HiloSocketsMonitoreo.Start();
        }

        TcpClient clientSocket;
        TcpListener serverSocket2;
        TcpClient clientSocket2;
        TcpListener serverSocket;
        String lectura = "";
        private void RunSocketsMonitoreo(object obj)
        {
            //while (true)
            //{
            //    if (!lectura.Trim().Equals(""))
            //    {
            //        String temp = "";
            //        while (!temp.Equals(lectura))
            //        {
            //            Thread.Sleep(100);
            //            temp = lectura;
            //        }
            //        //ejecutar instruccion

            //        try
            //        {
            //            if (lectura.Length > 1)
            //            {
            //                Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(lectura));
            //                System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            //                Bitmap bitImage = new Bitmap((Bitmap)System.Drawing.Image.FromStream(streamBitmap));
            //                Dispatcher.Invoke(new Action(() =>
            //                {
            //                    Herramientas.WPF.VisorImagenes v = new Herramientas.WPF.VisorImagenes(bitImage);

            //                    v.Show();
            //                }));
            //            }
            //            else if (lectura.Length == 1)
            //            {
            //                if (lectura.Equals("E"))
            //                {
            //                }
            //                Dispatcher.Invoke(new Action(() =>
            //                {
            //                    EjecutarTouch(lectura);
            //                }));
            //            }
            //        }
            //        catch { }
            //        lectura = "";

            //    }
            //}
        }
        private void RunSocketsBusqueda()
        {
            while (true)
            {
                try
                {
                    serverSocket2 = new TcpListener(8889);
                    int requestCount = 0;
                    clientSocket2 = default(TcpClient);
                    serverSocket2.Start();
                    clientSocket2 = serverSocket2.AcceptTcpClient();
                    clientSocket2.Close();
                }
                catch { }
            }
        }

        private void RunSockets()
        {
            if (serverSocket != null) return;
            serverSocket = new TcpListener(8888);
            int requestCount = 0;
            clientSocket = default(TcpClient);
            serverSocket.Start();
            clientSocket = serverSocket.AcceptTcpClient();
            requestCount = 0;
            String imagenCompleta = "";
            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[5242880];
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    //lectura += System.Text.Encoding.ASCII.GetString(bytesFrom);

                    List<Byte> bytesBuenos = new List<byte>();
                    int cerosSeguidos = 0;
                    foreach (Byte bTemp in bytesFrom)
                    {
                        if (bTemp != 0)
                        {
                            bytesBuenos.Add(bTemp);
                            cerosSeguidos = 0;
                        }
                        if (bTemp == 0)
                        {
                            cerosSeguidos++;
                            if (cerosSeguidos == 10)
                                break;
                        }
                    }

                    Byte[] arrayTemp = bytesBuenos.ToArray();
                    //imagenCompleta = "";
                    lectura += System.Text.Encoding.ASCII.GetString(arrayTemp).Replace("\n", "");

                }
                catch (Exception ex)
                {

                }
            }
            clientSocket.Close();
            serverSocket.Stop();
        }
        public string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }
        #endregion
        void controladoresTouch_click(BotonTouch boton)
        {
            EjecutarTouch(boton.Indice);
        }
        private int seleccionadoPlayList;
        public void EjecutarTouch(String indice)
        {
            try
            {
                controladoresTouch.DespareceLogo();

                controladoresTouch.EjecutarEvento(indice);

                indice = controladoresTouch.ObtenerAccionActual(indice);

                if (indice.Equals("teclado"))
                {
                    if (controladoresTouch.ModalidadActual != ControladoresTouch.ModalidadTeclado.Teclado)
                    {
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Teclado);
                        controladoresTouch.VisibleTextBox = true;
                    }
                    else
                    {
                        controladoresTouch.Text = "";
                        controladoresTouch.VisibleTextBox = false;
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                    }
                }
                else if (indice.Equals("abajo"))
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                    {
                        if (!controladoresTouch.VisibleTextBox)
                        {
                            if (discoSeleccionado == null) return;
                            discoSeleccionado.BajarEnLista();
                        }
                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.PlayList)
                    {
                        indicePlayList++;
                        SeleccionarElementoMenu();

                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Categorias)
                    {
                        indicePlayList++;
                        SeleccionarElementoMenu();
                    }
                }
                else if (indice.Equals("arriba"))
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                    {
                        if (!controladoresTouch.VisibleTextBox)
                        {
                            if (discoSeleccionado == null) return;
                            discoSeleccionado.SubirEnLista();
                        }
                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.PlayList)
                    {
                        indicePlayList--;
                        SeleccionarElementoMenu();

                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Categorias)
                    {
                        indicePlayList--;
                        SeleccionarElementoMenu();
                    }
                }
                else if (indice.Equals("multimedia"))
                {
                    if (controladoresTouch.ModalidadActual != ControladoresTouch.ModalidadTeclado.Reproductor)
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Reproductor);
                    else
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                }
                else if (indice.Equals("izquierda"))
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                    {
                        //if (controlYoutube.Visibility == System.Windows.Visibility.Visible)
                        //{
                        //    controlYoutube.Anterior();
                        //}
                        //else
                        //{
                        --seleccionado;
                        SeleccionarElemento();
                        //}
                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Teclado)
                    {
                        controladoresTouch.LetraAnterior();
                    }
                }
                else if (indice.Equals("derecha"))
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                    {
                        //if (controlYoutube.Visibility == System.Windows.Visibility.Visible)
                        //{
                        //    controlYoutube.Siguiente();
                        //}
                        //else
                        //{
                        ++seleccionado;
                        SeleccionarElemento();
                        //}
                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Teclado)
                    {
                        controladoresTouch.SiguienteLetra();
                    }
                }
                else if (indice.Equals("seleccionar"))
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                    {
                        //if (controlYoutube.Visibility == System.Windows.Visibility.Visible)
                        //{
                        //    //trabajo con youtube
                        //    controlYoutube.SeleccionarVideo();
                        //}
                        //else
                        //{

                        List<ElementoMultimedia> elementos = discoSeleccionado.ObtenerElementoMultimediaSeleccionado();
                        if (listaReproduccion.ElementosLista == null) listaReproduccion.ElementosLista = new List<ElementoListaReproduccion>();
                        Boolean HayCredito = true;

                        if (usarCreditos && CreditosActuales == 0)
                            HayCredito = false;

                        if (noRep)
                        {
                            Herramientas.Forms.Mensajes.Exclamacion("Tiempo de prueba terminado, compra una licencia de KaraTube para continuar usandolo.");
                            return;
                        }

                        if (reproductor.EstaReproduciendo() || !HayCredito)
                        {
                            foreach (ElementoMultimedia elemento in elementos)
                            {
                                ElementoListaReproduccion el = new ElementoListaReproduccion();
                                el.elemento = elemento;
                                el.Ruta = elemento.URL;
                                Bitmap Imagen = null;
                                if (elemento.AgrupadorContiene.ImagenTexto.Trim().Equals(""))
                                    Imagen = disco;
                                else
                                    Imagen = new Bitmap(elemento.AgrupadorContiene.ImagenTexto);
                                el.Imagen = Herramientas.WPF.Utilidades.BitmapAImageSource(Imagen);
                                listaReproduccion.AgregarElementoReproduccion(el);

                            }
                            RecargarListaReproduccion();

                            if (CreditosActuales == 0)
                            {
                                txt_creditos.Text = mensajeMonedas;
                                monedasAnimacion.Begin();
                            }
                        }
                        else
                        {
                            //reproductor.Reproducir(elementos[0]);
                            //ActualizarCreditos(-1);
                            if (elementos.Count > 1)
                            {

                                for (int i = 1; i < elementos.Count; i++)
                                {
                                    ElementoListaReproduccion el = new ElementoListaReproduccion();
                                    el.elemento = elementos[i];
                                    el.Ruta = elementos[i].URL;
                                    Bitmap Imagen = null;
                                    if (elementos[i].AgrupadorContiene.ImagenTexto == null || elementos[i].AgrupadorContiene.ImagenTexto.Trim().Equals(""))
                                        Imagen = disco;
                                    else
                                        Imagen = new Bitmap(elementos[i].AgrupadorContiene.ImagenTexto);
                                    el.Imagen = Herramientas.WPF.Utilidades.BitmapAImageSource(Imagen); listaReproduccion.AgregarElementoReproduccion(el);

                                }
                                RecargarListaReproduccion();
                                ReproducirElementoSeleccionadoLista(0);
                            }
                        }
                        //}
                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.PlayList)
                    {
                        //ElementoMultimedia elementos = listaReproduccion.ReproducirPorIndice(indiceInferiorListaOpciones+indicePlayList);
                        //reproductor.Reproducir(Reproductor.Modo.WindowsMediaPlayer, elementos.URL);
                        //indicePlayList = 0;
                        //indiceInferiorListaOpciones = 0;
                        //RecargarListaReproduccion();
                        Boolean hay = false;
                        if (CreditosActuales > 0 || !usarCreditos)
                        {
                            hay = true;
                        }

                        ReproducirElementoSeleccionadoLista(indiceInferiorListaOpciones + indicePlayList);
                        if (hay)
                        {
                            controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                            SeleccionarPrimerDisco();
                        }
                    }
                    else if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Categorias)
                    {
                        OpcionMenu opcionActual = (OpcionMenu)grd_PlayList.Children[indicePlayList];
                        opcionActual.SeleccionarAgrupador();
                        indicePlayList = 0;
                    }
                }
                else if (indice.Equals("categorias"))
                {
                    if (controladoresTouch.ModalidadActual != ControladoresTouch.ModalidadTeclado.Categorias)
                    {
                        //agrupadorPrincipalActual.AgrupadoresHijos = agrupadoresPrincipales;
                        DeseleccionarDiscos();

                        if (agrupadorFinalTemp == null)
                        {
                            agrupadorPrincipalActual = new Agrupador();
                            agrupadorPrincipalActual.AgrupadoresHijos = agrupadoresPrincipales;
                        }
                        else
                        {
                            agrupadorFinalActual = agrupadorFinalTemp;
                        }

                        RecargarListaCategorias();

                        txt_Opcion.Content = "Categorías:";
                        indicePlayList = 0;
                        SeleccionarElementoMenu();
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Categorias);
                    }
                    else
                    {
                        SeleccionarPrimerDisco();
                        txt_Opcion.Content = "Lista de reproducción";
                        RecargarListaReproduccion();
                        indicePlayList = 0;

                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                    }
                }
                else if (indice.Equals("playList"))
                {
                    if (controladoresTouch.ModalidadActual != ControladoresTouch.ModalidadTeclado.PlayList)
                    {
                        DeseleccionarDiscos();
                        indicePlayList = 0;
                        SeleccionarElementoMenu();
                        txt_Opcion.Content = "Lista de reproducción:";
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.PlayList);
                    }
                    else
                    {
                        SeleccionarPrimerDisco();
                        RecargarListaReproduccion();
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                    }
                }
                else if (indice.Equals("borrar"))
                {
                    try
                    {
                        if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.PlayList)
                        {
                            listaReproduccion.EliminarPorIndice(indiceInferiorListaOpciones + indicePlayList);

                            if (indiceInferiorListaOpciones + indicePlayList >= listaReproduccion.ElementosLista.Count)
                            {
                                indiceInferiorListaOpciones--;
                                RecorrerArribaLista();
                            }

                            RecargarListaReproduccion();
                            SeleccionarElementoMenu();
                        }
                    }
                    catch { }
                }
                else if (indice.Equals("letra"))
                {
                    try
                    {
                        controladoresTouch.AgregarLetra(controladoresTouch.LetraActual);
                    }
                    catch { }
                }
                else if (indice.Equals("espacioBlanco"))
                {
                    try
                    {
                        controladoresTouch.AgregarLetra(' ');
                    }
                    catch { }
                }
                else if (indice.Equals("borrarLetra"))
                {
                    try
                    {
                        controladoresTouch.BorrarLetra();
                    }
                    catch { }
                }
                else if (indice.Equals("enter"))
                {
                    try
                    {
                        controladoresTouch.Enter();
                        controladoresTouch.VisibleTextBox = false;
                        controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                    }
                    catch { }
                }
                else if (indice.Equals("borrarTodo"))
                {
                    try
                    {
                        controladoresTouch.BorrarTodo();
                    }
                    catch { }
                }
                else if (indice.Equals("play"))
                {
                    try
                    {
                        reproductor.Continuar();
                    }
                    catch { }
                }
                else if (indice.Equals("pausa"))
                {
                    try
                    {
                        reproductor.Pausar();
                    }
                    catch { }
                }
                else if (indice.Equals("adelantar"))
                {
                    try
                    {
                        ReproducirElementoSeleccionadoLista(0);
                    }
                    catch { }
                }
            }
            catch
            {
            }
        }
        private void SeleccionarPrimerDisco()
        {
            seleccionado = 0;
            DeseleccionarDiscos();
            Disco d = (Disco)discos.Children[0];
            if (d.AgrupadorAsignado != null)
                d.MostrarPistas();
        }
        private void DeseleccionarDiscos()
        {
            for (int i = 0; i < totalDiscosMostrar; i++)
            {
                Disco d = (Disco)discos.Children[i];
                if (d.EstaEnModoPistas && d.AgrupadorAsignado != null)
                    d.MostrarCaratula();
            }
        }
        private void ReproducirElementoSeleccionadoLista(int indiceListaReproduccion)
        {
            if (noRep)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Tiempo de prueba terminado, compra una licencia de KaraTube para continuar usandolo.");
                return;
            }
            if (usarCreditos && CreditosActuales == 0 && listaReproduccion.ElementosLista != null && listaReproduccion.ElementosLista.Count > 0)
            {
                if (!reproductor.EstaReproduciendo())
                {
                    reproductor.Limpiar();
                    MinimizarReproductor();
                }
                if (reproductor.EstaReproduciendo())
                {
                    //reproductor.Stop();
                    //reproductor.Limpiar();
                    //MinimizarReproductor();
                }

                txt_creditos.Text = mensajeMonedas;
                monedasAnimacion.Begin();
                return;
            }

            ElementoMultimedia elementos = listaReproduccion.ReproducirPorIndice(indiceListaReproduccion);
            if (elementos == null)
            {
                reproductor.Stop();
                reproductor.BorrarReproduccionActual();
                reproductor.Limpiar();
                MinimizarReproductor();
                return;
            }
            if (elementos.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Musica)
                MinimizarReproductor();
            ActualizarCreditos(-1);
            
            reproductor.Reproducir(elementos);
            reproductor.GuardarReproduccionActual();
            
            //if (elementos.TipoElemento != ElementoMultimedia.TipoElementoMultimedia.Musica)
            //    MaximizarReproductor();
            indicePlayList = 0;
            indiceInferiorListaOpciones = 0;
            RecargarListaReproduccion();
        }
        private void RecargarListaCategorias()
        {

            opcion_seleccionoCategoria(agrupadorPrincipalActual);
        }
        Agrupador agrupadorFinalTemp = null;
        private void CargarAgrupadorSeleccionado(Agrupador agrupador)
        {
            agrupadorFinalTemp = agrupador;
            if (agrupador.NombreAgrupador != null && agrupador.NombreAgrupador.Equals("ALEATORIO"))
            {
                //aqui obtener aleatorios y agregarlos a la lista de reproduccion

                ObtenerAleatorios();

                RecargarListaReproduccion(); // se actualiza
                controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal); // se cambia el teclado a modo principal
                if (!reproductor.EstaReproduciendo())
                    ReproducirElementoSeleccionadoLista(0);
                return;
            }
            if (agrupador.AgrupadoresHijos.Count == 0) return;
            if (agrupador.AgrupadoresHijos[0].AgrupadoresHijos == null)
            {
                agrupadorFinalActual = agrupador;
                agrupadorFinalTemp = null;
                AgrupadorGuia = agrupadorFinalActual.AgrupadoresHijos[0];
                CargarDiscosCategoriaActualFinal();
                seleccionado = 0;
                SeleccionarElemento();
                EjecutarTouch("categorias");
                controladoresTouch.VisibleTextBox = false;
                discos.Visibility = System.Windows.Visibility.Visible;
                return;
            }
            CargarMasReproducidos(agrupador);
            //no es agurpador final
            if (agrupador.AgrupadoresHijos.Count == 1)
            {
                opcion_seleccionoCategoria(agrupador.AgrupadoresHijos[0]);


            }
            else if (agrupador.AgrupadoresHijos.Count <= 4)
            {
                int i = 0;
                foreach (Agrupador elemento in agrupador.AgrupadoresHijos)
                {
                    OpcionMenu opcion = new OpcionMenu();
                    opcion.seleccionoCategoria += opcion_seleccionoCategoria;
                    opcion.AgrupadorPrincipalCategorias = elemento;
                    opcion.Indice = i;
                    opcion.Width = grd_PlayList.Width;
                    opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                    opcion.entroMouse += opcion_entroMouse;
                    grd_PlayList.Children.Add(opcion);
                    opcion.click += opcion_click;
                    i++;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    Agrupador elemento = agrupador.AgrupadoresHijos[i];
                    OpcionMenu opcion = new OpcionMenu();
                    opcion.Indice = i;
                    opcion.Width = grd_PlayList.Width;
                    opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                    opcion.AgrupadorPrincipalCategorias = elemento;
                    opcion.seleccionoCategoria += opcion_seleccionoCategoria;
                    opcion.click += opcion_click;
                    opcion.entroMouse += opcion_entroMouse;
                    grd_PlayList.Children.Add(opcion);
                }
            }
            indicePlayList = 0;
            SeleccionarElementoMenu();
        }

        private void ObtenerAleatorios()
        {
            List<Agrupador> agrups = new List<Agrupador>();

            foreach (Agrupador ag in agrupadorFinalTemp.AgrupadorPadre.AgrupadoresHijos)
            {
                if (!ag.NombreAgrupador.Equals("ALEATORIO"))
                {
                    agrups.AddRange(ag.AgrupadoresHijos);
                }
            }
            for (int i = 0; i < pistasAleatorias; i++)
            {

                int rango = agrups.Count - 1;

                int random = Herramientas.Calculos.NumerosAleatorios.ObtenerInt(0, rango);

                Agrupador r = agrups[random];
                int random2 = Herramientas.Calculos.NumerosAleatorios.ObtenerInt(0, r.ElementosMultimedia.Count - 1);

                ElementoMultimedia elemento = r.ElementosMultimedia[random2];

                ElementoListaReproduccion el = new ElementoListaReproduccion();
                el.elemento = elemento;
                el.Ruta = elemento.URL;
                try
                {
                    Bitmap Imagen = null;
                    if (elemento.AgrupadorContiene.ImagenTexto.Trim().Equals(""))
                        Imagen = disco;
                    else
                        Imagen = new Bitmap(elemento.AgrupadorContiene.ImagenTexto);

                    el.Imagen = Herramientas.WPF.Utilidades.BitmapAImageSource(Imagen);
                }
                catch
                {
                }
                listaReproduccion.AgregarElementoReproduccion(el);
            }
        }
        void opcion_seleccionoCategoria(Agrupador agrupador)
        {
            grd_PlayList.Children.Clear();

            if (agrupador.NombreAgrupador != null && agrupador.NombreAgrupador.Trim().Contains(" YOUTUBE"))
            {
                controladoresTouch.VisibleTextBox = true;
                //controlYoutube.Categoria = agrupador.NombreAgrupador.Replace(" YOUTUBE", "");
                discos.Visibility = System.Windows.Visibility.Hidden;
                //controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
                CargarDiscosVacios();
                agrupadorFinalTemp = agrupador;
                //EjecutarTouch("categorias");
                controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Teclado);
                txt_Opcion.Content = "Lista de reproducción:";
                controladoresTouch.BorrarTodo();
                RecargarListaReproduccion();
                return;
            }
            else if (agrupador.NombreAgrupador != null && agrupador.NombreAgrupador.Trim().Equals("YOUTUBE"))
            {
                for (int i = 0; i < agrupador.AgrupadoresHijos.Count; i++)
                {
                    Agrupador elemento = agrupador.AgrupadoresHijos[i];
                    OpcionMenu opcion = new OpcionMenu();
                    opcion.Indice = i;
                    opcion.Width = grd_PlayList.Width;
                    opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                    opcion.AgrupadorPrincipalCategorias = elemento;
                    opcion.seleccionoCategoria += opcion_seleccionoCategoria;
                    opcion.click += opcion_click;
                    opcion.entroMouse += opcion_entroMouse;
                    grd_PlayList.Children.Add(opcion);
                }
                return;
            }
            else
            {
                CargarDiscosVacios();
                //controlYoutube.Visibility = System.Windows.Visibility.Hidden;
                //controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Categorias);
            }

            CargarAgrupadorSeleccionado(agrupador);
        }
        private void CargarMasReproducidos(Agrupador agrupador)
        {
            String masReproducidos = "MÁS POPULARES";
            ElementoMultimedia.TipoElementoMultimedia tipo = 0;
            Variable var = null;
            if (agrupador.NombreAgrupador != null && agrupador.NombreAgrupador.Equals("KARAOKE"))
            {
                var = Compartidos.ObtenerVariablesTopKaraoke();
                tipo = ElementoMultimedia.TipoElementoMultimedia.Karaoke;
            }
            else if (agrupador.NombreAgrupador != null && agrupador.NombreAgrupador.Equals("MUSICA"))
            {
                var = Compartidos.ObtenerVariablesTopMusica();
                tipo = ElementoMultimedia.TipoElementoMultimedia.Musica;
            }
            else if (agrupador.NombreAgrupador != null && agrupador.NombreAgrupador.Equals("VIDEOS"))
            {
                var = Compartidos.ObtenerVariablesTopVideos();
                tipo = ElementoMultimedia.TipoElementoMultimedia.Video;
            }

            if (var != null && var.VariablesGuardadas() > 0)
            {
                Agrupador agrMasReproducidos = new Agrupador();
                foreach (Agrupador agrTemp in agrupador.AgrupadoresHijos)
                {
                    if (agrTemp.NombreAgrupador.Equals(masReproducidos))
                    {
                        agrMasReproducidos = agrTemp;
                    }
                }
                if (agrMasReproducidos.NombreAgrupador == null)
                {
                    agrupador.AgrupadoresHijos.Add(agrMasReproducidos);
                    agrMasReproducidos.AgrupadorPadre = agrupador;
                }
                agrMasReproducidos.NombreAgrupador = masReproducidos;
                agrMasReproducidos.AgrupadoresHijos = new List<Agrupador>();


                DataTable dt = var.ObtenerDataTableConVariablesYValores();
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[1].DataType = typeof(Int32);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dtCloned.DefaultView.Sort = "Valor desc";
                dt = dtCloned.DefaultView.ToTable();
                Dictionary<String, List<String>> carpetasFavoritos = new Dictionary<string, List<string>>();
                foreach (DataRow dr in dt.Rows)
                {
                    String carpeta = Herramientas.Archivos.Archivo.ObtenerSoloNombreCarpetaDeArchivo(dr["Variable"].ToString().Split('|')[0]);

                    if (!carpetasFavoritos.ContainsKey(carpeta))
                        carpetasFavoritos.Add(carpeta, new List<string>());

                    carpetasFavoritos[carpeta].Add(dr["Variable"].ToString());

                }
                int k = 1;
                foreach (String key in carpetasFavoritos.Keys)
                {
                    Agrupador album = new Agrupador();
                    album.AgrupadorPadre = agrMasReproducidos;
                    album.ElementosMultimedia = new List<ElementoMultimedia>();
                    album.NombreAgrupador = key.ToUpper();
                    album.ImagenTexto = agrMasReproducidos.ImagenTexto;
                    album.Codigo = k;
                    int i = 1;
                    foreach (String pista in carpetasFavoritos[key])
                    {
                        ElementoMultimedia temp = new ElementoMultimedia();
                        temp.AgrupadorContiene = album;
                        temp.TipoElemento = tipo;
                        temp.Titulo = pista.ToString().Split('|')[1].ToUpper();
                        temp.URL = pista.ToString().Split('|')[0].ToUpper();
                        temp.Codigo = i;
                        i++;
                        album.ElementosMultimedia.Add(temp);

                        if (album.ImagenTexto == null)
                        {
                            try
                            {
                                String ruta = Herramientas.Archivos.Archivo.ObtenerNombreCarpetaDeArchivo(temp.URL);

                                List<String> imagenes = Directory.GetFiles(ruta, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".gif")).ToList();

                                if (imagenes.Count > 0)
                                {
                                    album.ImagenTexto = imagenes[0];
                                }
                            }
                            catch
                            {
                            }
                        }

                    }

                    if (agrMasReproducidos.AgrupadoresHijos.Count - 1 >= 0)
                    {
                        album.Anterior = agrMasReproducidos.AgrupadoresHijos[agrMasReproducidos.AgrupadoresHijos.Count - 1];
                        agrMasReproducidos.AgrupadoresHijos[agrMasReproducidos.AgrupadoresHijos.Count - 1].Siguiente = album;
                    }

                    agrMasReproducidos.AgrupadoresHijos.Add(album);
                    k++;
                }

                agrMasReproducidos.AgrupadoresHijos[0].Anterior = agrMasReproducidos.AgrupadoresHijos[agrMasReproducidos.AgrupadoresHijos.Count - 1];
                agrMasReproducidos.AgrupadoresHijos[agrMasReproducidos.AgrupadoresHijos.Count - 1].Siguiente = agrMasReproducidos.AgrupadoresHijos[0];

            }
            if (activarCategoriaAleatorios && agrupador.NombreAgrupador != null && !agrupador.NombreAgrupador.Equals(""))
            {
                Boolean estaAgregadoAleatorios = false;

                foreach (Agrupador agrup in agrupador.AgrupadoresHijos)
                {
                    if (agrup.NombreAgrupador.Equals("ALEATORIO"))
                    {
                        estaAgregadoAleatorios = true;
                        break;
                    }
                }
                if (!estaAgregadoAleatorios)
                {
                    Agrupador aleatorio = new Agrupador();
                    aleatorio.NombreAgrupador = "ALEATORIO";
                    aleatorio.AgrupadorPadre = agrupador;
                    agrupador.AgrupadoresHijos.Add(aleatorio);
                }
            }
        }
        void opcion_click(OpcionMenu opcionMenu)
        {
            indicePlayList = opcionMenu.Indice;
            if (indicePlayList < 0) return;
            opcionMenu.Seleccionar();
        }
        private void RecargarListaReproduccion()
        {
            grd_PlayList.Children.Clear();

            if (listaReproduccion.ElementosLista == null) return;
            if (listaReproduccion.ElementosLista.Count <= 4)
            {
                int i = 0;
                indiceInferiorListaOpciones = 0;
                foreach (ElementoListaReproduccion elemento in listaReproduccion.ElementosLista)
                {
                    OpcionMenu opcion = new OpcionMenu();
                    opcion.ElementoLista = elemento;
                    opcion.Indice = i;
                    opcion.seleccionoPista += opcion_seleccionoPista;
                    opcion.click += opcion_click;
                    opcion.Width = grd_PlayList.Width;
                    opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                    opcion.entroMouse += opcion_entroMouse;
                    grd_PlayList.Children.Add(opcion);
                    i++;
                }
            }
            else
            {


                for (int i = 0; i < 4; i++)
                {
                    ElementoListaReproduccion elemento = listaReproduccion.ElementosLista[indiceInferiorListaOpciones + i];
                    OpcionMenu opcion = new OpcionMenu();
                    opcion.ElementoLista = elemento;
                    opcion.Indice = i;
                    opcion.seleccionoPista += opcion_seleccionoPista;
                    opcion.click += opcion_click;
                    opcion.Width = grd_PlayList.Width;
                    opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                    opcion.entroMouse += opcion_entroMouse;
                    grd_PlayList.Children.Add(opcion);
                }
            }

            //EjecutarTouch("playList");

        }
        private void SeleccionarElementoMenu()
        {
            foreach (OpcionMenu opcion in grd_PlayList.Children)
            {
                opcion.Deseleccionar();
            }
            if (indicePlayList < 0)
            {
                indicePlayList = 0;
                RecorrerArribaLista();
            }
            if (indicePlayList > grd_PlayList.Children.Count - 1)
            {
                indicePlayList = grd_PlayList.Children.Count - 1;
                RecorrerAbajoLista();
            }
            if (indicePlayList < 0) return;
            OpcionMenu opcionMenu = (OpcionMenu)grd_PlayList.Children[indicePlayList];
            opcionMenu.Seleccionar();

        }
        int indiceInferiorListaOpciones = 0;
        private void RecorrerArribaLista()
        {
            if (indicePlayList == 0)
            {
                if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.PlayList && listaReproduccion.ElementosLista != null && listaReproduccion.ElementosLista.Count > 4)
                {
                    indiceInferiorListaOpciones--;

                    if (indiceInferiorListaOpciones >= 0)
                    {
                        grd_PlayList.Children.Clear();
                        for (int i = indiceInferiorListaOpciones; i < indiceInferiorListaOpciones + 4; i++)
                        {
                            ElementoListaReproduccion elemento = listaReproduccion.ElementosLista[i];
                            OpcionMenu opcion = new OpcionMenu();
                            opcion.Indice = i;
                            opcion.seleccionoPista += opcion_seleccionoPista;
                            opcion.Width = grd_PlayList.Width;
                            opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                            opcion.ElementoLista = elemento;
                            opcion.entroMouse += opcion_entroMouse;
                            grd_PlayList.Children.Add(opcion);
                        }
                    }
                    else
                    {
                        indiceInferiorListaOpciones = 0;
                    }
                }
                else
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Categorias && agrupadorFinalTemp.AgrupadoresHijos.Count > 4)
                    {
                        indiceInferiorListaOpciones--;

                        if (indiceInferiorListaOpciones >= 0)
                        {
                            grd_PlayList.Children.Clear();
                            for (int i = indiceInferiorListaOpciones; i < indiceInferiorListaOpciones + 4; i++)
                            {
                                Agrupador elemento = agrupadorFinalTemp.AgrupadoresHijos[i];
                                OpcionMenu opcion = new OpcionMenu();
                                opcion.Indice = i;
                                opcion.seleccionoCategoria += opcion_seleccionoCategoria;
                                opcion.AgrupadorPrincipalCategorias = elemento;
                                opcion.Width = grd_PlayList.Width;
                                opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                                opcion.entroMouse += opcion_entroMouse;
                                grd_PlayList.Children.Add(opcion);
                            }
                        }
                        else
                        {
                            indiceInferiorListaOpciones = 0;
                        }
                    }
                }
            }
        }

        void opcion_seleccionoPista(ElementoListaReproduccion elementoLista)
        {
            //if (elementoLista.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.YouTube && !elementoLista.elemento.Descargado)
            //    return;
            ReproducirElementoSeleccionadoLista(elementoLista.NumeroPista - 1);
        }
        void rtg_rectanguloArriba_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.PlayList);
            RecorrerArribaLista();
        }

        void rtg_rectanguloAbajo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Principal)
                controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.PlayList);
            RecorrerAbajoLista();
        }
        private void RecorrerAbajoLista()
        {
            if (indicePlayList == grd_PlayList.Children.Count - 1)
            {
                if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.PlayList && listaReproduccion.ElementosLista.Count > 4)
                {
                    indiceInferiorListaOpciones++;

                    if (indiceInferiorListaOpciones <= listaReproduccion.ElementosLista.Count - 4)
                    {
                        grd_PlayList.Children.Clear();
                        for (int i = indiceInferiorListaOpciones; i < indiceInferiorListaOpciones + 4; i++)
                        {
                            ElementoListaReproduccion elemento = listaReproduccion.ElementosLista[i];
                            OpcionMenu opcion = new OpcionMenu();
                            opcion.seleccionoPista += opcion_seleccionoPista;
                            opcion.Indice = i;
                            opcion.ElementoLista = elemento;
                            opcion.Width = grd_PlayList.Width;
                            opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                            opcion.click += opcion_click;
                            opcion.entroMouse += opcion_entroMouse;
                            grd_PlayList.Children.Add(opcion);
                        }
                    }
                    else
                    {
                        indiceInferiorListaOpciones = listaReproduccion.ElementosLista.Count - 4;
                    }
                }
                else
                {
                    if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Categorias && agrupadorFinalTemp.AgrupadoresHijos.Count > 4)
                    {
                        indiceInferiorListaOpciones++;

                        if (controladoresTouch.ModalidadActual == ControladoresTouch.ModalidadTeclado.Categorias && agrupadorFinalTemp.AgrupadoresHijos.Count > 4)
                        {

                            if (indiceInferiorListaOpciones <= agrupadorFinalTemp.AgrupadoresHijos.Count - 4)
                            {
                                grd_PlayList.Children.Clear();
                                for (int i = indiceInferiorListaOpciones; i < indiceInferiorListaOpciones + 4; i++)
                                {
                                    Agrupador elemento = agrupadorFinalTemp.AgrupadoresHijos[i];
                                    OpcionMenu opcion = new OpcionMenu();
                                    opcion.click += opcion_click;
                                    opcion.Indice = i;
                                    opcion.Width = grd_PlayList.Width;
                                    opcion.Height = grd_PlayList.Height / grd_PlayList.Rows;
                                    opcion.seleccionoCategoria += opcion_seleccionoCategoria;
                                    opcion.AgrupadorPrincipalCategorias = elemento;
                                    opcion.entroMouse += opcion_entroMouse;
                                    grd_PlayList.Children.Add(opcion);
                                }
                            }
                            else
                            {
                                indiceInferiorListaOpciones = agrupadorFinalTemp.AgrupadoresHijos.Count - 4;
                            }
                        }
                    }
                }
            }
        }

        void opcion_entroMouse(OpcionMenu opcionMenu)
        {
            //foreach (OpcionMenu opcion in grd_PlayList.Children)
            //{
            //    opcion.Deseleccionar();
            //}

            indicePlayList = grd_PlayList.Children.IndexOf(opcionMenu);
            SeleccionarElementoMenu();
            //opcionMenu.Seleccionar();
        }
        int indicePlayList;
        Boolean SeleccionandoPlayList;
        private Agrupador agrupadorPrincipalActual;
        private Agrupador agrupadorFinalActual;
        int rangoInferior = 0;
        int rangoSuperior = 0;
        private void CargarDiscosVacios()
        {
            if (discos.Children.Count > 0)
            {

                return;
            }
            //controlYoutube.SetDimensiones(discos.ActualWidth, discos.ActualHeight);
            for (int i = 0; i < totalDiscosMostrar; i++)
            {
                Disco d = new Disco();
                d.HeightManual = discos.ActualHeight / discos.Rows;
                d.mouseOver += d_mouseOver;
                d.mouseClickSeleccionoElemento += d_mouseClickSeleccionoElemento;
                d.IndiceAsignado = i;
                d.Visibility = System.Windows.Visibility.Hidden;
                discos.Children.Add(d);
            }
            //agrupadorPrincipalActual = agrupadoresPrincipales[0];
            //CargarDiscosCategoriaActualFinal();
        }

        void d_mouseClickSeleccionoElemento(Disco disco)
        {
            controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
            discoSeleccionado = disco;
            EjecutarTouch("seleccionar");
        }
        private void FiltrarEnAgrupador(String criterioBusqueda)
        {
            if (agrupadorFinalActual == null)
                return;
            Agrupador busqueda = new Agrupador();
            busqueda.AgrupadoresHijos = new List<Agrupador>();
            busqueda.AgrupadorPadre = agrupadorFinalActual.AgrupadorPadre;


            foreach (Agrupador ag in agrupadorFinalActual.AgrupadorPadre.AgrupadoresHijos)
            {
                if (!ag.NombreAgrupador.Equals("ALEATORIO") && !ag.NombreAgrupador.Equals("MAS POPULARES"))
                {
                    busqueda.AgrupadoresHijos.AddRange(ag.AgrupadoresHijos);
                }
            }
            Agrupador agrupadorFiltrado = new Agrupador();
            agrupadorFiltrado.NombreAgrupador = agrupadorFinalActual.NombreAgrupador;
            agrupadorFiltrado.AgrupadorPadre = agrupadorFinalActual.AgrupadorPadre;
            agrupadorFiltrado.AgrupadoresHijos = new List<Agrupador>();

            if (busqueda == null || busqueda.AgrupadoresHijos.Count == 0)
            {
                return;
            }
            foreach (Agrupador agrupadorHijo in busqueda.AgrupadoresHijos)
            {
                if (agrupadorHijo.NombreAgrupador.ToUpper().Contains(criterioBusqueda.ToUpper()))
                {
                    Agrupador anterior = null;
                    if (agrupadorFiltrado.AgrupadoresHijos.Count - 1 >= 0)
                        anterior = agrupadorFiltrado.AgrupadoresHijos[agrupadorFiltrado.AgrupadoresHijos.Count - 1];
                    Agrupador nuevo = new Agrupador();
                    nuevo.NombreAgrupador = agrupadorHijo.NombreAgrupador;
                    nuevo.Anterior = anterior;
                    if (anterior != null)
                    {
                        anterior.Siguiente = nuevo;
                    }
                    nuevo.ElementosMultimedia = agrupadorHijo.ElementosMultimedia;
                    nuevo.AgrupadorPadre = agrupadorFiltrado;
                    nuevo.Imagen = agrupadorHijo.Imagen;
                    nuevo.ImagenTexto = agrupadorHijo.ImagenTexto;
                    nuevo.Codigo = agrupadorHijo.Codigo;



                    agrupadorFiltrado.AgrupadoresHijos.Add(nuevo);
                }

            }
            if (agrupadorFiltrado.AgrupadoresHijos.Count > 0)
            {
                agrupadorFiltrado.AgrupadoresHijos[0].Anterior = agrupadorFiltrado.AgrupadoresHijos[agrupadorFiltrado.AgrupadoresHijos.Count - 1];
                agrupadorFiltrado.AgrupadoresHijos[agrupadorFiltrado.AgrupadoresHijos.Count - 1].Siguiente = agrupadorFiltrado.AgrupadoresHijos[0];

                agrupadorFinalActual = agrupadorFiltrado;
                CargarDiscosCategoriaActualFinal();
                controladoresTouch.VisibleTextBox = false;
                controladoresTouch.Text = "";

                //
                SeleccionarPrimerDisco();
                txt_Opcion.Content = "Lista de reproducción";
                RecargarListaReproduccion();
                indicePlayList = 0;

                controladoresTouch.SetModalidad(ControladoresTouch.ModalidadTeclado.Principal);
            }
        }
        private void CargarDiscosCategoriaActualFinal()
        {
            //agrupadorFinalActual = agrupadorPrincipalActual.AgrupadoresHijos[0];

            if (agrupadorFinalActual == null) return;
            for (int i = totalDiscosMostrar - 1; i >= 0; i--)
            {
                Disco d = (Disco)discos.Children[i];
                d.Visibility = System.Windows.Visibility.Visible;
            }


            AgrupadorGuia = agrupadorFinalActual.AgrupadoresHijos[0];
            CargarSiguienteSemento();
            AgrupadorGuia = agrupadorFinalActual.AgrupadoresHijos[0];
            Disco dTemp = (Disco)discos.Children[0];
            discoSeleccionado = dTemp;
            dTemp.MostrarPistas();
        }
        private void CargarSegmentoAnterior()
        {
            if (AgrupadorGuia.Anterior == null) return;

            AgrupadorGuia = AgrupadorGuia.Anterior;
            for (int i = totalDiscosMostrar - 1; i >= 0; i--)
            {
                Disco d = (Disco)discos.Children[i];
                d.HeightManual = discos.ActualHeight / discos.Rows;
                d.mouseOver += d_mouseOver;
                d.IndiceAsignado = i;
                if (AgrupadorGuia != null)
                {
                    d.AsignarAgrupador(AgrupadorGuia);
                    AgrupadorGuia = AgrupadorGuia.Anterior;
                }
                else
                    d.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private Agrupador AgrupadorGuia;
        private void CargarSiguienteSemento()
        {
            if (AgrupadorGuia == null) return;

            for (int i = 0; i < totalDiscosMostrar; i++)
            {
                Disco d = (Disco)discos.Children[i];
                d.HeightManual = discos.ActualHeight / discos.Rows;
                d.mouseOver += d_mouseOver;
                d.IndiceAsignado = i;
                if (AgrupadorGuia != null)
                {
                    d.AsignarAgrupador(AgrupadorGuia);
                    AgrupadorGuia = AgrupadorGuia.Siguiente;
                }
                else
                    d.Visibility = System.Windows.Visibility.Hidden;

            }

        }

        private Boolean soloAbrirUnaVez = true;

        void MainWindow_Activated(object sender, EventArgs e)
        {
            CargarDiscosVacios();
            //agrupadorFinalActual = agrupadorPrincipalActual.AgrupadoresHijos[0];
            //CargarDiscosCategoriaActualFinal();




        }

        void d_mouseOver(Disco disco)
        {
            foreach (Disco dist in discos.Children)
            {
                if (dist != disco && dist.EstaEnModoPistas)
                    dist.MostrarCaratula();
            }
            seleccionado = disco.IndiceAsignado;
        }
        int seleccionado = 0;
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            //cuando detecta la tecla de moneda suma un credito
            if (keyMoneda == e.Key)
            {
                ActualizarCreditos(1);
                return;
            }
            segundosParaMaximizar = 0;
            if (Maximizado)
            {
                MinimizarReproductor();
                return;
            }
            int indice = teclas.IndexOf(e.Key);
            

            if (indice != -1)
            {
                EjecutarTouch(controladoresTouch.ObtenerAccionActual((indice + 1).ToString()));
            }
        }

        private void SeleccionarElemento()
        {
            if (AgrupadorGuia == null) return;
            if (seleccionado < 0)
            {
                CargarSegmentoAnterior();
                seleccionado = totalDiscosMostrar - 1;
                AgrupadorGuia = AgrupadorGuia.Anterior; //aqui no estoy seguro
            }
            if (seleccionado > totalDiscosMostrar - 1)
            {
                AgrupadorGuia = AgrupadorGuia.Siguiente;
                CargarSiguienteSemento();
                seleccionado = 0;
            }



            foreach (Disco dist in discos.Children)
            {
                if (dist.EstaEnModoPistas)
                    dist.MostrarCaratula();
            }
            discoSeleccionado = (Disco)discos.Children[seleccionado];
            AgrupadorGuia = discoSeleccionado.AgrupadorAsignado;
            discoSeleccionado.MostrarPistas();

        }

        void listaReproduccion_seDescargoElemento(ListaReproduccion instancia, ElementoMultimedia elementoMultimediaDescargado)
        {
            listaReproduccion_actualizarControl(instancia);
            if (!reproductor.EstaReproduciendo())
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    ReproducirElementoSeleccionadoLista(0);
                }));
            }
        }
        void listaReproduccion_actualizarControl(ListaReproduccion instancia)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (listaReproduccion.ElementosLista.Count <= 4)
                {
                    int i = 0;
                    indiceInferiorListaOpciones = 0;
                    foreach (ElementoListaReproduccion elemento in listaReproduccion.ElementosLista)
                    {
                        OpcionMenu opcion = (OpcionMenu)grd_PlayList.Children[i];
                        opcion.ActualizarProgreso();
                        i++;
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        OpcionMenu opcion = (OpcionMenu)grd_PlayList.Children[i];
                        opcion.ActualizarProgreso();
                    }
                }
            }));
        }
    }
}
