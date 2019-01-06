using Dominio.Modulos.ProgramaSiembra;
using InterfazWPF.AdministracionSistema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Telerik.Windows.Controls.Map;

namespace InterfazWPF.Modulos.ProgramaSiembra.Controles
{
    /// <summary>
    /// Lógica de interacción para Croquis.xaml
    /// </summary>
    public partial class Croquis : UserControl
    {
        Boolean visible;
        List<DataTemplate> templates = new List<DataTemplate>();
        Location loc;
        Boolean control;
        private Boolean obtenerCoordenadas;
        public Boolean ObtenerCoordenadas { get { return obtenerCoordenadas; } set { obtenerCoordenadas = value; if (!value) { YaEligioPrimerCoordenada = false; } } }
        public int ZoomEtiquetas { get; set; }
        public Boolean MostrarSiempreEtiquetas { get { return mostrarSiempreEtiquetas; } set { mostrarSiempreEtiquetas = value; if (value) { MostrarEtiquetas(); } else { QuitarEtiquetas(); } } }
        private Boolean mostrarSiempreEtiquetas;
        public double GrosorLineaPerimetros { get; set; }
        private Boolean YaEligioPrimerCoordenada;

        List<String> coordenadasTemporal = new List<string>();


        public delegate void ObtenerEspacioSeleccionado(_ps_EspacioFisico espacioFisico);
        public event ObtenerEspacioSeleccionado obtenerEspacioSeleccionado;

        public delegate void ObtenerCoordenada(String coordenada);
        public event ObtenerCoordenada obtenerCoordenada;

        public delegate void ObtenerEspacioAgregado(String coordenadasEspacioAgregado);
        public event ObtenerEspacioAgregado obtenerEspacioAgregado;

        public delegate void ObtenerEspacioAModifiar(_ps_EspacioFisico espacioAModificar);
        public event ObtenerEspacioAModifiar obtenerEspacioAModifiar;

        public delegate void EspacioClick(_ps_EspacioFisico espacioFisico);
        public event EspacioClick espacioClick;

        public delegate void ReDibujarCroquis();
        public event ReDibujarCroquis reDibujarCroquis;


        public delegate String ConstruirDatosAMostrar(_ps_EspacioFisico espacio);
        public event ConstruirDatosAMostrar construirDatosAMostrar;


        //public void RegresarEspacioAgregado()
        //{
        //    MapPolygon poligono = (MapPolygon)map.Items[map.Items.Count - 1];
        //    List<String> coordenadasTemp = new List<string>();
        //    foreach (Location loc in poligono.Points)
        //    {
        //        coordenadasTemp.Add(loc.Latitude + ", " + loc.Longitude);
        //    }
        //    if (obtenerEspacioAgregado != null)
        //    {
        //        obtenerEspacioAgregado(coordenadasTemp);
        //    }
        //}
        public Croquis()
        {
            InitializeComponent();
            radMap.MapMouseDoubleClick += radMap_MapMouseDoubleClick;
            radMap.MouseRightButtonDown += radMap_MouseRightButtonDown;
            radMap.MapMouseClick += radMap_MapMouseClick;
            radMap.MouseDoubleClickMode = MouseBehavior.None;
            radMap.MouseClickMode = MouseBehavior.None;
            radMap.MaxZoomLevel = 19;
            radMap.DistanceUnit = DistanceUnit.Kilometer;
            radMap.NavigationVisibility = System.Windows.Visibility.Collapsed;
            radMap.ZoomBarVisibility = System.Windows.Visibility.Collapsed;
            radMap.ZoomBarPresetsVisibility = System.Windows.Visibility.Collapsed;
            radMap.CommandBarVisibility = System.Windows.Visibility.Collapsed;
            radMap.MouseLocationIndicatorVisibility = System.Windows.Visibility.Collapsed;
            radMap.ScaleVisibility = System.Windows.Visibility.Collapsed;

            ZoomEtiquetas = 18;
            GrosorLineaPerimetros = 3;

            BingMapProvider bingMap = new BingMapProvider(MapMode.Road, true, "AqaPuZWytKRUA8Nm5nqvXHWGL8BDCXvK8onCl2PkC581Zp3T_fYAQBiwIphJbRAK");

            radMap.Provider = bingMap;

            radMap.ZoomingFinished += radMap_ZoomingFinished;
            radMap.ZoomChanged += radMap_ZoomChanged;
        }

        void radMap_MapMouseClick(object sender, MapMouseRoutedEventArgs eventArgs)
        {

        }
        private void AgregarElipseAMapa(String Coordenadas, double TamKm, Color color)
        {
            double ellipseWidth = TamKm; // 3 kilomiters
            double ellipseHeight = TamKm; // 3 kilomiters

            double latitud = Convert.ToDouble(Coordenadas.Split(',')[0]);
            double longitud = Convert.ToDouble(Coordenadas.Split(',')[1]);

            // Calculate ellipse size in degrees (latitude-longitude).
            Size degreeSize = this.radMap.GetLatitudeLongitudeSize(new Location(latitud, longitud), ellipseWidth, ellipseHeight);

            // Calculate new ellipse location. 
            // Shift from click-point on half of the ellipse size in degrees.
            Location ellipseLocation = new Location(
                latitud + degreeSize.Height / 2,
                longitud - degreeSize.Width / 2);
            Random r = new Random();
            MapEllipse ellipse = new MapEllipse()
            {
                Location = ellipseLocation,
                Width = ellipseWidth,
                Height = ellipseHeight,
                Fill = new SolidColorBrush(color),
                Uid = "un dato ejemplo: " + r.Next(1, 1000) * r.NextDouble()
            };

            ellipse.MouseLeave += ellipse_MouseLeave;
            ellipse.MouseMove += ellipse_MouseMove;
            this.map.Items.Add(ellipse);
        }

        void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (!floatingTip.IsOpen) { floatingTip.IsOpen = true; }

            MapEllipse pol = (MapEllipse)sender;

            Point currentPos = e.GetPosition(radMap);
            txt_mensajePopup.Text = pol.Uid;//ObtenerTextoDeTemplate(pol.CaptionTemplate);
            floatingTip.HorizontalOffset = currentPos.X + 10;
            floatingTip.VerticalOffset = currentPos.Y;
        }
        void ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            floatingTip.IsOpen = false;
        }
        public void Simulacion(int indice)
        {
            if (indice == 1)
            {
                for (int i = 0; i < map.Items.Count; i++)
                {
                    if (map.Items[i].GetType() == typeof(MapPolygon))
                    {
                        MapPolygon poligono = (MapPolygon)map.Items[i];
                        _ps_EspacioFisico esp = (_ps_EspacioFisico)poligono.Tag;
                        if (esp.EsPadreTemporalCroquis)
                            continue;
                        if (i == 3 || i == 6)
                            poligono.Fill = Brushes.Red;
                        else if (i == 1 || i == 0)
                            poligono.Fill = Brushes.Green;
                        else if (i == 4)
                            poligono.Fill = Brushes.Yellow;
                        else
                            poligono.Fill = Brushes.Orange;
                    }
                }
                map.Items.Refresh();
            }
            else if (indice == 2)
            {
                Random r = new Random();
                for (int i = 0; i < 80; i++)
                {


                    AgregarElipseAMapa("24.75" + r.Next(11, 44) + ", -107.46" + r.Next(18, 99), Convert.ToDouble(r.Next(5, 15)) / 1000, Colors.Red);
                    AgregarElipseAMapa("24.75" + r.Next(11, 44) + ", -107.47" + Herramientas.Conversiones.Formatos.IntANDigitos(r.Next(0, 33), 2), Convert.ToDouble(r.Next(5, 15)) / 1000, Colors.Red);
                }
                //AgregarElipseAMapa("24.753554, -107.474865", 0.001, Colors.Red);
                //AgregarElipseAMapa("24.753510, -107.476640", 0.002, Colors.Red);
                //AgregarElipseAMapa("24.751942, -107.474738", 0.003, Colors.Red);
            }
            else if (indice == 3)
            {
            }
        }

        Boolean modoEdicion = false;
        public void ActivarDesactivarModoEdicion()
        {
            modoEdicion = !modoEdicion;
            YaEligioPrimerCoordenada = false;
            obtenerCoordenadas = false;
            coordenadasTemporal.Clear();

            if (modoEdicion)
                HerramientasWindow.MostrarNotificacion("Modo de edición activado.", "ACTIVADO");
            else
                HerramientasWindow.MostrarNotificacion("Modo de edición desactivado.", "DESACTIVADO");

        }

        public void DesactivarModoEdicion()
        {
            modoEdicion = false;
            obtenerCoordenadas = false;
            YaEligioPrimerCoordenada = false;
            coordenadasTemporal.Clear();
        }

        private void QuitarEtiquetas()
        {
            for (int i = 0; i < map.Items.Count; i++)
            {
                MapPolygon poligono = (MapPolygon)map.Items[i];
                poligono.CaptionTemplate = null;
            }
            map.Items.Refresh();
        }
        private void MostrarEtiquetas()
        {
            for (int i = 0; i < map.Items.Count; i++)
            {
                MapPolygon poligono = (MapPolygon)map.Items[i];

                _ps_EspacioFisico esp = (_ps_EspacioFisico)poligono.Tag;
                if (esp == null || esp.EsPadreTemporalCroquis)
                    continue;

                DataTemplate dTemplate = ObtenerDataTemplate(poligono.Uid);
                poligono.CaptionTemplate = dTemplate;

                List<double> latitudes = new List<double>();
                List<double> longitudes = new List<double>();

                foreach (Location loc in poligono.Points)
                {
                    latitudes.Add(loc.Latitude);
                    longitudes.Add(loc.Longitude);
                }
                latitudes.Sort();
                longitudes.Sort();

                double latitudCentro = latitudes[latitudes.Count - 1]; //(latitudes[0] + latitudes[latitudes.Count - 1]) / 2;
                double longitudCentro = longitudes[0]; // (longitudes[0] + longitudes[longitudes.Count - 1]) / 2;


                poligono.CaptionLocation = new Location(latitudCentro, longitudCentro);

            }
            map.Items.Refresh();
        }
        void radMap_MapMouseDoubleClick(object sender, MapMouseRoutedEventArgs eventArgs)
        {
            //obtener coordenada de mapa
            //se obtiene aqui eventArgs.Location

            if (ObtenerCoordenadas && obtenerCoordenada != null)
            {
                //obtenerCoordenada(eventArgs.Location.Latitude + ", " + eventArgs.Location.Longitude);
                coordenadasTemporal.Add(eventArgs.Location.Latitude + ", " + eventArgs.Location.Longitude);
                AgregarPoligonoTemporal(null, coordenadasTemporal);
            }
        }
        void radMap_ZoomChanged(object sender, EventArgs e)
        {
            if (radMap.ZoomLevel >= ZoomEtiquetas && !visible && mostrarSiempreEtiquetas)
            {
                visible = true;
                MostrarEtiquetas();
            }
            else if (radMap.ZoomLevel < ZoomEtiquetas && visible && mostrarSiempreEtiquetas)
            {
                visible = false;
                QuitarEtiquetas();
            }
        }
        void radMap_ZoomingFinished(object sender, RoutedEventArgs e)
        {
            if (control)
            {
                radMap.Center = loc;
                control = false;
            }

        }
        private void zoomin()
        {
            radMap.ZoomLevel = 19;
            control = false;
        }
        public void BorrarPoligonos()
        {
            map.Items.Clear();
            map.Items.Refresh();
        }
        public void IrACoordenada(String coordenadas, int zoomNivel)
        {
            double latitud = Convert.ToDouble(coordenadas.Split(',')[0]);
            double longitud = Convert.ToDouble(coordenadas.Split(',')[1]);
            loc = new Location(latitud, longitud);
            radMap.Center = loc;
            radMap.ZoomLevel = zoomNivel;
        }
        public void CentrarEspacioEnPantallaConZoom(_ps_EspacioFisico espacioFisico)
        {
            if (!autoCentrado) return;
            if (espacioFisico == null) return;
            if (espacioFisico.St_CoordenadasEspaciales == null) return;
            int zoom = 0;

            double hectareasTotales = CalcularArea(espacioFisico.St_CoordenadasEspaciales) / 10000;

            if (hectareasTotales >= 50) zoom = 15;
            if (hectareasTotales >= 30 && hectareasTotales < 50) zoom = 16;
            if (hectareasTotales >= 20 && hectareasTotales < 30) zoom = 17;
            if (hectareasTotales >= 1.5 && hectareasTotales < 20) zoom = 18;
            if (hectareasTotales < 1.5) zoom = 19;

            IrACoordenada(CalcularCoordenadaCentral(espacioFisico.St_CoordenadasEspaciales), zoom); //radMap.ZoomLevel);
        }
        void mp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!ObtenerCoordenadas)
            {
                MapPolygon poligono = (MapPolygon)sender;
                _ps_EspacioFisico espacioF = (_ps_EspacioFisico)poligono.Tag;

                if (autoCentrado)
                    CentrarEspacioEnPantallaConZoom(espacioF);

                if (espacioClick != null)
                    espacioClick(espacioF);
            }
        }
        private DataTemplate ObtenerDataTemplate(String Uid)
        {

            Grid grContent = new Grid();
            grContent.Opacity = 1.0;
            grContent.Background = new SolidColorBrush(Colors.Transparent);

            StackPanel stack = new StackPanel();
            stack.Opacity = 0.7;
            stack.Background = new SolidColorBrush(Colors.Black);
            grContent.Children.Add(stack);

            String nombre = Uid.Replace("\r\n", "|");
            String[] etiquetas = nombre.Split('|');

            foreach (String etiqueta in etiquetas)
            {
                TextBlock txt_etiqueta = new TextBlock() { Text = etiqueta, Foreground = Brushes.White, FontSize = 10 };
                stack.Children.Add(txt_etiqueta);
            }
            string controlesPersonalizados = XamlWriter.Save(grContent);

            DataTemplate template = XamlReader.Parse(""
                + "<DataTemplate "
                + " xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\""
                + " xmlns:telerik=\"http://schemas.telerik.com/2008/xaml/presentation\">"
                //+ " xmlns:InterfazWPF=\"clr-namespace:InterfazWPF\">"
                + controlesPersonalizados
                //+ " <Grid Background=\"White\" telerik:MapLayer.HotSpot=\"0.5, 0.5\">"
                //+ "  <StackPanel>"
                //+ "   <TextBlock Text=\"Nombre: " + nombre + "\" />"
                //+ "   <TextBlock Text=\"Area: " + area + "\" />"
                //+ "   <TextBlock Text=\"Perimetro: " + perimetro + "\" />"
                //+ "   <Button>test</Button>"
                //+     botonPersonalizado
                //+ "   </StackPanel>"
                //+ " </Grid>"
                + "</DataTemplate>") as DataTemplate;
            return template;
        }
        public void AgregarPoligono(_ps_EspacioFisico espacio, System.Drawing.Color Color, List<String> otrosDatos)
        {
            if (espacio.St_CoordenadasEspaciales != null && !espacio.St_CoordenadasEspaciales.Equals(""))
            {
                String[] coordenadas = espacio.St_CoordenadasEspaciales.Split('|');
                AgregarPoligono(espacio, coordenadas.ToList<String>(), espacio.st_Nombre_espacio, Color, otrosDatos);
            }
        }

        public String CalcularCoordenadaCentral(String puntosConSeparador)
        {
            String[] coordenadas = puntosConSeparador.Split('|');
            List<String> puntos = coordenadas.ToList<String>();

            List<double> latitudes = new List<double>();
            List<double> longitudes = new List<double>();

            foreach (String punto in puntos)
            {
                double latitud = Convert.ToDouble(punto.Split(',')[0]);
                double longitud = Convert.ToDouble(punto.Split(',')[1]);

                latitudes.Add(latitud);
                longitudes.Add(longitud);
            }

            latitudes.Sort();
            longitudes.Sort();

            double latitudCentro = (latitudes[0] + latitudes[latitudes.Count - 1]) / 2;
            double longitudCentro = (longitudes[0] + longitudes[longitudes.Count - 1]) / 2;

            return latitudCentro + ", " + longitudCentro;
        }

        private void AgregarPoligono(_ps_EspacioFisico espacio, List<String> puntos, String nombre, System.Drawing.Color Color, List<String> otrosDatos)
        {
            Color ColorPoligono = System.Windows.Media.Color.FromArgb(Color.A, Color.R, Color.G, Color.B);

            LocationCollection puntosLoc = new LocationCollection();

            foreach (String punto in puntos)
            {
                double latitud = Convert.ToDouble(punto.Split(',')[0]);
                double longitud = Convert.ToDouble(punto.Split(',')[1]);
                puntosLoc.Add(new Location(latitud, longitud));
            }


            MapPolygon mp = new MapPolygon();
            mp.Points = puntosLoc;
            mp.Opacity = 0.4;
            if (espacio != null && !espacio.EsPadreTemporalCroquis)
            {
                mp.MouseLeave += mp_MouseLeave;
                mp.MouseEnter += mp_MouseEnter;
            }
            mp.MouseLeave += mp_MouseLeave2;
            mp.MouseMove += mp_MouseMove;
            mp.MouseRightButtonUp += mp_MouseRightButtonUp;
            mp.MouseLeftButtonDown += mp_MouseLeftButtonDown;


            //mp.PreviewMouseDoubleClick += mp_MouseDoubleClick;

            mp.Fill = new SolidColorBrush(ColorPoligono);
            double area = CalcularArea(puntosLoc);
            Color colorOscurecido = HerramientasWindow.ObtenerTonalidadOscuraDeColor(ColorPoligono);

            mp.Stroke = new SolidColorBrush(colorOscurecido);
            mp.StrokeThickness = GrosorLineaPerimetros;
            mp.Cursor = Cursors.Hand;
            String uid2 = "";
            if (espacio != null)
            {
                uid2 += "Nombre: " + espacio.st_Nombre_espacio + "\r\n";
                if (espacio.do_Numero_hectareas > 0)
                    uid2 += "Hectareas(ha): " + espacio.do_Numero_hectareas + " Ha(s)\r\n";
                else
                    uid2 += "Hectareas(ha): " + Math.Abs(Herramientas.WPF.Utilidades.RedondearANDecimales(area / 10000, 2)) + " Ha(s)\r\n";
                if (espacio.ll_Configuraciones_de_Siembra != null && espacio.ll_Configuraciones_de_Siembra.Count > 0)
                {
                    foreach (_ps_ConfiguracionSiembra conf in espacio.ll_Configuraciones_de_Siembra)
                    {
                        String variedad = "";
                        if (conf.Bo_SeUsaInjerto)
                        {
                            variedad = conf.Oo_DatosInjerto.Oo_VariedadProductiva.st_Nombre + " - " + conf.Oo_DatosInjerto.Oo_VariedadRaiz;
                        }
                        else
                        {
                            variedad = conf.oo_Variedad_de_semilla.st_Nombre;
                        }
                        uid2 += "Etapa " + conf.Oo_EtapaConfiguracionSiembra.St_NombreEtapa + ":" + " \r\n";
                        String tab = "     ";
                        uid2 += tab + "Cult.: "+ conf.oo_Cultivo_plantado.st_Nombre_cultivo + " (" + variedad + ")" + " \r\n";
                        uid2 += tab + "F. plant.: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(conf.dt_Fecha_de_planteo) + " \r\n";
                        uid2 += tab + "F. siemb.: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(conf.dt_Fecha_de_planteo.AddDays(conf.oo_Cultivo_plantado.In_DiasAntesSiembra * -1)) + " \r\n";
                        uid2 += tab + "F. cosec.: " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(conf.dt_Fecha_de_planteo.AddDays(conf.oo_Cultivo_plantado.In_DiasDespuesCosecha)) + " \r\n";
                    }
                }
                if (espacio.Oo_Configuracion_tecnologica != null && espacio.Oo_Configuracion_tecnologica.Oo_TecnologiaDeCultivoUsada != null && espacio.Oo_Configuracion_tecnologica.Oo_CubiertaUsada != null)
                {
                    uid2 += "Tecnología: " + espacio.Oo_Configuracion_tecnologica.Oo_TecnologiaDeCultivoUsada.st_Descripcion + " (" + espacio.Oo_Configuracion_tecnologica.Oo_CubiertaUsada.St_NombreCubierta + ")" + " \r\n";
                }
            }
            //mp.Uid = "Nombre: " + nombre + "\r\n" + "Area: " + Math.Abs(Herramientas.WPF.Utilidades.RedondearANDecimales(area / 10000, 2)) + " Ha(s)   |   " + Math.Abs(Herramientas.WPF.Utilidades.RedondearANDecimales(area, 2)).ToString("N") + " m2" + "\r\nPerimetro: " +Math.Abs( Herramientas.WPF.Utilidades.RedondearANDecimales(CalcularPerimetro(puntosLoc), 2)).ToString("N") + " m";
            mp.Uid = uid2;
            mp.Tag = espacio;

            String TagTemp = mp.Uid;

            if (otrosDatos != null && otrosDatos.Count > 0)
            {
                TagTemp += "\r\n";
                foreach (String dato in otrosDatos)
                {
                    TagTemp += dato + "\r\n";
                }
                TagTemp = TagTemp.Substring(0, TagTemp.Length - 2);
                mp.Uid = TagTemp;
            }
            map.Items.Add(mp);
            if (radMap.ZoomLevel >= ZoomEtiquetas && mostrarSiempreEtiquetas)
            {
                MostrarEtiquetas();
            }

        }
        Brush brushTemp;
        void mp_MouseEnter(object sender, MouseEventArgs e)
        {
            MapPolygon poligonoTemp = (MapPolygon)sender;
            brushTemp = poligonoTemp.Fill;


            poligonoTemp.Fill = Brushes.LightBlue;
        }
        void mp_MouseLeave(object sender, MouseEventArgs e)
        {
            MapPolygon poligonoTemp = (MapPolygon)sender;
            poligonoTemp.Fill = brushTemp;

        }
        void mp_MouseLeave2(object sender, MouseEventArgs e)
        {
            floatingTip.IsOpen = false;
        }
        void mp_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            radMap.ContextMenu = null;
            poligonoSeleccionado = (MapPolygon)sender;
            MostrarContextMenuEspacio(poligonoSeleccionado);
        }
        void radMap_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            radMap.ContextMenu = null;
            poligonoSeleccionado = null;
            if (modoEdicion)
                MostrarContextMenuMapa(null);
        }
        MapPolygon poligonoSeleccionado;
        private void MostrarContextMenuEspacio(Control elemento)
        {
            radMap.ContextMenu = null;

            _ps_EspacioFisico temp = (_ps_EspacioFisico)poligonoSeleccionado.Tag;

            if (elemento.Tag != null)
            {
                if (!ObtenerCoordenadas)
                {
                    ContextMenu menuContextEspacio = new ContextMenu();
                    radMap.ContextMenu = menuContextEspacio;

                    MenuItem mi_verDentro = new MenuItem();
                    mi_verDentro.Header = "Ver espacios dentro (Entrar)";
                    mi_verDentro.Foreground = Brushes.Black;
                    mi_verDentro.Click += verDentro_Click;
                    menuContextEspacio.Items.Add(mi_verDentro);
                    if (modoEdicion)
                    {
                        MenuItem agregarEspacioAEspacio = new MenuItem();
                        agregarEspacioAEspacio.Header = "Agregar Espacio";
                        agregarEspacioAEspacio.Foreground = Brushes.Black;
                        //item1.Background = Brushes.Transparent;
                        menuContextEspacio.Items.Add(agregarEspacioAEspacio);
                        agregarEspacioAEspacio.Click += agregarEspacioAEspacio_Click;
                        menuContextEspacio.Visibility = System.Windows.Visibility.Visible;

                        MenuItem mi_modificarEspacio = new MenuItem();
                        mi_modificarEspacio.Header = "Modificar";
                        mi_modificarEspacio.Foreground = Brushes.Black;
                        mi_modificarEspacio.Click += mi_modificarEspacio_Click;
                        menuContextEspacio.Items.Add(mi_modificarEspacio);

                        MenuItem mi_EditarEspacioGrafico = new MenuItem();
                        mi_EditarEspacioGrafico.Header = "Editar gráfico";
                        mi_EditarEspacioGrafico.Foreground = Brushes.Black;
                        mi_EditarEspacioGrafico.Click += mi_EditarEspacioGrafico_Click;
                        menuContextEspacio.Items.Add(mi_EditarEspacioGrafico);
                    }

                    MenuItem mi_generarImagenPlano = new MenuItem();
                    mi_generarImagenPlano.Header = "Generar plano de " + temp.st_Nombre_espacio + " en imagen";
                    mi_generarImagenPlano.Foreground = Brushes.Black;
                    menuContextEspacio.Items.Add(mi_generarImagenPlano);
                    mi_generarImagenPlano.Click += mi_generarImagenPlano_Click;
                    menuContextEspacio.Visibility = System.Windows.Visibility.Visible;

                    MenuItem mi_verPropiedades = new MenuItem();
                    mi_verPropiedades.Header = "Ver propiedades";
                    mi_verPropiedades.Foreground = Brushes.Black;
                    menuContextEspacio.Items.Add(mi_verPropiedades);
                    menuContextEspacio.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                ContextMenu menuContextEspacio = new ContextMenu();
                radMap.ContextMenu = menuContextEspacio;

                MenuItem mi_BorrarElUltimo = new MenuItem();
                mi_BorrarElUltimo.Header = "Borrar último punto";
                mi_BorrarElUltimo.Foreground = Brushes.Black;
                mi_BorrarElUltimo.Click += mi_BorrarElUltimo_Click;
                menuContextEspacio.Items.Add(mi_BorrarElUltimo);

                MenuItem mi_terminarEdicion = new MenuItem();
                mi_terminarEdicion.Header = "Terminar edición";
                mi_terminarEdicion.Foreground = Brushes.Black;
                mi_terminarEdicion.Click += mi_terminarEdicion_Click;
                menuContextEspacio.Items.Add(mi_terminarEdicion);

                MenuItem mi_CancelarEdicion = new MenuItem();
                mi_CancelarEdicion.Header = "Cancelar edición";
                mi_CancelarEdicion.Foreground = Brushes.Black;
                mi_CancelarEdicion.Click += mi_CancelarEdicion_Click;
                menuContextEspacio.Items.Add(mi_CancelarEdicion);


                menuContextEspacio.Visibility = System.Windows.Visibility.Visible;
            }
            //create image at runtime and attach to menu at runtime
            //BitmapImage copyimage = new BitmapImage();
            //copyimage.BeginInit();
            //Uri myUri = new Uri("Copy.png", UriKind.RelativeOrAbsolute);
            //copyimage.UriSource = myUri;
            //copyimage.EndInit();

            //Image iconImage = new Image();
            //iconImage.Source = copyimage;

            //MenuItem item3 = new MenuItem();
            //item3.Header = "Copy";
            ////item3.Icon = iconImage;
            //mainMenu.Items.Add(item3);


        }

        void mi_BorrarElUltimo_Click(object sender, RoutedEventArgs e)
        {
            coordenadasTemporal.RemoveAt(coordenadasTemporal.Count - 1);
            AgregarPoligonoTemporal(null, coordenadasTemporal);
        }

        void mi_EditarEspacioGrafico_Click(object sender, RoutedEventArgs e)
        {
            espacioAModificarGrafico = (_ps_EspacioFisico)poligonoSeleccionado.Tag;

            map.Items.Remove(poligonoSeleccionado);

            modoEdicion = true;
            ObtenerCoordenadas = true;
            btn_desactivarAutoCentrado_Click(null, null);

        }
        _ps_EspacioFisico espacioAModificarGrafico;
        void agregarEspacioAEspacio_Click(object sender, RoutedEventArgs e)
        {
            if (obtenerEspacioSeleccionado != null)
                obtenerEspacioSeleccionado((_ps_EspacioFisico)poligonoSeleccionado.Tag);
            ObtenerCoordenadas = true;
            btn_desactivarAutoCentrado_Click(null, null);
        }

        void mi_generarImagenPlano_Click(object sender, RoutedEventArgs e)
        {
            //dibujar mapa
            bm_planoMapa = null;
            _ps_EspacioFisico espacioT = (_ps_EspacioFisico)poligonoSeleccionado.Tag;
            if (espacioT != null)
            {
                GenerarMapa(espacioT);
                if (espacioT.ll_Espacios_fisicos_dentro != null)
                {
                    foreach (_ps_EspacioFisico espacioDentro in espacioT.ll_Espacios_fisicos_dentro)
                    {
                        DibujarEspacioRecursivo(espacioDentro, System.Drawing.Color.GhostWhite);
                    }
                }
                if (espacioT.ll_Espacios_fisicos_dentro != null)
                {
                    foreach (_ps_EspacioFisico espacioDentro in espacioT.ll_Espacios_fisicos_dentro)
                    {
                        EscribirDatosEspacioRecursivo(espacioDentro, System.Drawing.Color.GhostWhite);
                    }
                }
            }

            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Imagen JPG" }, new List<string>() { "jpg" }, espacioT.st_Nombre_espacio + "_" + Herramientas.Conversiones.Formatos.DateTimeAFechaNumero(DateTime.Now) + ".jpg");
            if (ruta != null)
            {
                try
                {
                    bm_planoMapa.Save(ruta);
                    HerramientasWindow.MostrarNotificacion("Plano guardado correctamente", "Guardado exitoso");
                }
                catch (Exception ex)
                {
                    HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
                }
            }
        }

        void mi_modificarEspacio_Click(object sender, RoutedEventArgs e)
        {
            if (obtenerEspacioAModifiar != null)
                obtenerEspacioAModifiar((_ps_EspacioFisico)poligonoSeleccionado.Tag);
        }

        void mi_CancelarEdicion_Click(object sender, RoutedEventArgs e)
        {
            ObtenerCoordenadas = false;
            coordenadasTemporal.Clear();
            if (espacioAModificarGrafico != null)
            {
                espacioAModificarGrafico = null;
                if (reDibujarCroquis != null)
                    reDibujarCroquis();
            }
            else
                map.Items.RemoveAt(map.Items.Count - 1);
            map.Items.Refresh();
        }

        void mi_terminarEdicion_Click(object sender, RoutedEventArgs e)
        {
            //aqui agregar los datos del espacio
            ObtenerCoordenadas = false;
            String retorno = "";
            foreach (String coord in coordenadasTemporal)
                retorno += coord + "|";
            retorno = retorno.Substring(0, retorno.Length - 1);
            if (espacioAModificarGrafico != null)
            {
                espacioAModificarGrafico.St_CoordenadasEspaciales = retorno;
                espacioAModificarGrafico.EsModificado = true;
                espacioAModificarGrafico.Guardar();

                espacioAModificarGrafico = null;
                if (reDibujarCroquis != null)
                    reDibujarCroquis();
            }
            else if (obtenerEspacioAgregado != null)
            {
                obtenerEspacioAgregado(retorno);
            }
            coordenadasTemporal.Clear();
        }
        private void MostrarContextMenuMapa(Control elemento)
        {
            radMap.ContextMenu = null;
            if (!ObtenerCoordenadas)
            {
                ContextMenu menuContextMapa = new ContextMenu();
                radMap.ContextMenu = menuContextMapa;

                MenuItem agregarEspacio = new MenuItem();
                agregarEspacio.Header = "Agregar Espacio";
                agregarEspacio.Foreground = Brushes.Black;
                //item1.Background = Brushes.Transparent;
                menuContextMapa.Items.Add(agregarEspacio);
                agregarEspacio.Click += agregarEspacio_Click;
                menuContextMapa.Visibility = System.Windows.Visibility.Visible;
            }

            //create image at runtime and attach to menu at runtime
            //BitmapImage copyimage = new BitmapImage();
            //copyimage.BeginInit();
            //Uri myUri = new Uri("Copy.png", UriKind.RelativeOrAbsolute);
            //copyimage.UriSource = myUri;
            //copyimage.EndInit();

            //Image iconImage = new Image();
            //iconImage.Source = copyimage;

            //MenuItem item3 = new MenuItem();
            //item3.Header = "Copy";
            ////item3.Icon = iconImage;
            //mainMenu.Items.Add(item3);


        }

        void agregarEspacio_Click(object sender, RoutedEventArgs e)
        {
            ObtenerCoordenadas = true;
            btn_desactivarAutoCentrado_Click(null, null);
        }
        void verDentro_Click(object sender, RoutedEventArgs e)
        {
            //String nombre = poligonoSeleccionado.Uid.Replace("\r\n", "|");

            DesactivarModoEdicion();

            if (obtenerEspacioSeleccionado != null)
                obtenerEspacioSeleccionado((_ps_EspacioFisico)poligonoSeleccionado.Tag);
        }

        void mp_MouseMove(object sender, MouseEventArgs e)
        {
            if (!floatingTip.IsOpen) { floatingTip.IsOpen = true; }

            MapPolygon pol = (MapPolygon)sender;

            Point currentPos = e.GetPosition(radMap);
            txt_mensajePopup.Text = pol.Uid;//ObtenerTextoDeTemplate(pol.CaptionTemplate);
            floatingTip.HorizontalOffset = currentPos.X + 10;
            floatingTip.VerticalOffset = currentPos.Y;
        }


        //calculo de areas y perimetros
        long circunferencia = 40091147;

        public void AgregarPoligonoTemporal(_ps_EspacioFisico espacio, List<String> coordenadas)
        {
            if (YaEligioPrimerCoordenada)
                map.Items.RemoveAt(map.Items.Count - 1);
            else
                YaEligioPrimerCoordenada = true;
            AgregarPoligono(espacio, coordenadas, "Editando...", System.Drawing.Color.Orange, null);


        }
        public double CalcularArea(String puntosCoordenadas)
        {
            LocationCollection puntosLoc = new LocationCollection();

            foreach (String punto in puntosCoordenadas.Split('|'))
            {
                double latitud = Convert.ToDouble(punto.Split(',')[0]);
                double longitud = Convert.ToDouble(punto.Split(',')[1]);
                puntosLoc.Add(new Location(latitud, longitud));
            }

            return CalcularArea(puntosLoc);
        }
        public double CalcularArea(LocationCollection puntosCalculo)
        {
            //A = (1/2)(x1*y2 - x2*y1 + x2*y3 - x3*y2 + x3y4 - x4y3 + x4*y5 -x5*y4 + x5*y1 - x1*y5).
            double sum = 0.0;
            for (int i = 1; i < puntosCalculo.Count; i++)
            {
                double radianes = puntosCalculo[i].Latitude / 180.0 * (22.0 / 7.0);

                double YAnterior = (puntosCalculo[i - 1].Latitude - puntosCalculo[0].Latitude) / 360 * circunferencia;
                double XAnterior = (puntosCalculo[i - 1].Longitude - puntosCalculo[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                double YActual = (puntosCalculo[i].Latitude - puntosCalculo[0].Latitude) / 360 * circunferencia;
                double XActual = (puntosCalculo[i].Longitude - puntosCalculo[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                sum = sum + ((YAnterior * XActual) - (XAnterior * YActual)) * 0.5;
            }
            return sum;
        }
        public double CalcularPerimetro(LocationCollection puntosCalculo)
        {
            //A = (1/2)(x1*y2 - x2*y1 + x2*y3 - x3*y2 + x3y4 - x4y3 + x4*y5 -x5*y4 + x5*y1 - x1*y5).
            double sum = 0.0;
            for (int i = 1; i < puntosCalculo.Count; i++)
            {
                double radianes = puntosCalculo[i].Latitude / 180.0 * (22.0 / 7.0);

                double YAnterior = (puntosCalculo[i - 1].Latitude - puntosCalculo[0].Latitude) / 360 * circunferencia;
                double XAnterior = (puntosCalculo[i - 1].Longitude - puntosCalculo[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                double YActual = (puntosCalculo[i].Latitude - puntosCalculo[0].Latitude) / 360 * circunferencia;
                double XActual = (puntosCalculo[i].Longitude - puntosCalculo[0].Longitude) / 360 * circunferencia * Math.Cos(radianes);

                sum = sum + Math.Pow(Math.Pow((XActual - XAnterior), 2) + Math.Pow((YActual - YAnterior), 2), 0.5);
            }
            return sum;
        }
        Boolean b;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (b)
            {
                BingMapProvider bingMap = new BingMapProvider(MapMode.Road, true, "AqaPuZWytKRUA8Nm5nqvXHWGL8BDCXvK8onCl2PkC581Zp3T_fYAQBiwIphJbRAK");

                radMap.Provider = bingMap;
            }
            else
            {
                BingMapProvider bingMap = new BingMapProvider(MapMode.Aerial, true, "AqaPuZWytKRUA8Nm5nqvXHWGL8BDCXvK8onCl2PkC581Zp3T_fYAQBiwIphJbRAK");

                radMap.Provider = bingMap;
            }
            b = !b;

        }
        private void btn_nombresEspacios_Click(object sender, RoutedEventArgs e)
        {
            if (btn_nombresEspacios.Content.ToString().Equals("Mostrar nombres de espacios"))
            {
                MostrarSiempreEtiquetas = true;
                btn_nombresEspacios.Content = "Ocultar nombres de espacios";
            }
            else
            {
                MostrarSiempreEtiquetas = false;
                btn_nombresEspacios.Content = "Mostrar nombres de espacios";
            }

        }

        private void btn_copiarVista_Click(object sender, RoutedEventArgs e)
        {

        }
        Boolean autoCentrado = true;
        private void btn_desactivarAutoCentrado_Click(object sender, RoutedEventArgs e)
        {
            if (btn_desactivarAutoCentrado.Content.ToString().Equals("Desactivar auto-centrado"))
            {
                autoCentrado = false;
                btn_desactivarAutoCentrado.Content = "Activar auto-centrado";
            }
            else
            {
                autoCentrado = true;
                btn_desactivarAutoCentrado.Content = "Desactivar auto-centrado";
            }
        }

        #region imprimir mapa
        private void DibujarEspacioRecursivo(_ps_EspacioFisico espacio, System.Drawing.Color color)
        {
            if (espacio.ll_Espacios_fisicos_dentro == null)
                DibujarPoligonos(espacio, color);

            if (espacio.ll_Espacios_fisicos_dentro != null)
                foreach (_ps_EspacioFisico espacioDentro in espacio.ll_Espacios_fisicos_dentro)
                {
                    DibujarEspacioRecursivo(espacioDentro, HerramientasWindow.ObtenerTonalidadOscuraDeColor(color));
                }
        }
        private void EscribirDatosEspacioRecursivo(_ps_EspacioFisico espacio, System.Drawing.Color color)
        {
            if (espacio.ll_Espacios_fisicos_dentro == null)
            {
                String datos = construirDatosAMostrar(espacio);
                EscribirDatos(espacio, color, true, datos);
            }

            //else
            //    EscribirDatos(espacio, color, true, espacio.st_Nombre_espacio);

            if (espacio.ll_Espacios_fisicos_dentro != null)
                foreach (_ps_EspacioFisico espacioDentro in espacio.ll_Espacios_fisicos_dentro)
                {
                    EscribirDatosEspacioRecursivo(espacioDentro, HerramientasWindow.ObtenerTonalidadOscuraDeColor(color));
                }
        }
        double pixelesEnY;
        double pixelesEnX;
        double latitudMenor;
        double latitudMayor;
        double longitudMenor;
        double longitudMayor;
        System.Drawing.Bitmap bm_planoMapa;
        float factorEscala = 1.1f;
        float tamLetra = 14;
        String fuente = "Verdana";
        private void GenerarMapa(_ps_EspacioFisico espacio)
        {
            List<String> coordenadas = new List<string>();

            if (espacio.St_CoordenadasEspaciales == null) return;

            coordenadas = espacio.St_CoordenadasEspaciales.Split('|').ToList<String>();

            List<double> latitudes = new List<double>();
            List<double> longitudes = new List<double>();

            foreach (String coordenada in coordenadas)
            {
                latitudes.Add(Convert.ToDouble(coordenada.Split(',')[0]));
                longitudes.Add(Convert.ToDouble(coordenada.Split(',')[1]));
            }

            longitudes.Sort();
            latitudes.Sort();

            latitudMenor = latitudes[0];
            latitudMayor = latitudes[latitudes.Count - 1];
            longitudMenor = longitudes[0];
            longitudMayor = longitudes[longitudes.Count - 1];

            pixelesEnY = (latitudMayor - latitudMenor) * 500000;

            pixelesEnX = (longitudMayor - longitudMenor) * 500000;

            List<String> pixeles = new List<string>();

            foreach (String coordenada in coordenadas)
            {
                double latitud = Convert.ToDouble(coordenada.Split(',')[0]);
                double longitud = Convert.ToDouble(coordenada.Split(',')[1]);

                double pixelY = (latitud - latitudMenor) * 500000;
                double pixelX = (longitud - longitudMenor) * 500000;
                pixeles.Add((int)(pixelY / factorEscala) + ", " + (int)(pixelX / factorEscala));

            }
            pixelesEnX = pixelesEnX / factorEscala + 10;
            pixelesEnY = pixelesEnY / factorEscala + 10;
            bm_planoMapa = new System.Drawing.Bitmap((int)pixelesEnX, (int)pixelesEnY);
            for (int i = 0; i < (int)pixelesEnX; i++)
            {
                for (int j = 0; j < (int)pixelesEnY; j++)
                {
                    bm_planoMapa.SetPixel(i, j, System.Drawing.Color.White);
                }
            }
            DibujarPoligonos(espacio, System.Drawing.Color.Snow);
            EscribirTexto("Plano de " + espacio.st_Nombre_espacio, new System.Drawing.Point(10, 10));

        }
        private void EscribirDatos(_ps_EspacioFisico espacio, System.Drawing.Color color, Boolean IncluirDatos, String Datos)
        {
            List<String> coordenadas = new List<string>();
            if (espacio.St_CoordenadasEspaciales == null) return;
            coordenadas = espacio.St_CoordenadasEspaciales.Split('|').ToList<String>();
            List<String> pixeles = new List<string>();

            List<int> pixelesX = new List<int>();
            List<int> pixelesY = new List<int>();
            List<String> pixelesXY = new List<string>();
            foreach (String coordenada in coordenadas)
            {
                double latitud = Convert.ToDouble(coordenada.Split(',')[0]);
                double longitud = Convert.ToDouble(coordenada.Split(',')[1]);

                double pixelX = (latitud - latitudMenor) * 500000;
                double pixelY = (longitud - longitudMenor) * 500000;

                int pixelFinalX = (int)(pixelX / factorEscala);
                int pixelFinalY = (int)(pixelY / factorEscala);

                pixelesX.Add(pixelFinalY);
                pixelesY.Add(bm_planoMapa.Height - 1 - pixelFinalX);
                pixelesXY.Add(pixelFinalY + "," + (bm_planoMapa.Height - 1 - pixelFinalX));
            }
            pixelesX.Sort();
            pixelesY.Sort();

            int xCentro = ((pixelesX[pixelesX.Count - 1] - pixelesX[0]) / 2) + pixelesX[0];
            int yCentro = ((pixelesY[pixelesY.Count - 1] - pixelesY[0]) / 2) + pixelesY[0];

            //xCentro = Convert.ToInt32(xCentro * 0.94);
            //if (xCentro < pixelesX[0]) xCentro = pixelesX[0] + 5;

            //yCentro = Convert.ToInt32(yCentro * 0.93);
            //if (yCentro < pixelesY[0]) yCentro = pixelesY[0] + 5;
            //yCentro = pixelesY[0];


            int puntoY = -1;
            int puntoX = -1;
            foreach (String punto in pixelesXY)
            {
                int X = Convert.ToInt32(punto.Split(',')[0]);
                int Y = Convert.ToInt32(punto.Split(',')[1]);

                if (X < xCentro && Y < yCentro)
                {
                    puntoX = X;
                    puntoY = Y;
                    break;
                }

            }
            xCentro = puntoX + 10;
            yCentro = puntoY + 5;


            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm_planoMapa);

            System.Drawing.SolidBrush brushRelleno = new System.Drawing.SolidBrush(color);
            System.Drawing.Pen penLinea = new System.Drawing.Pen(HerramientasWindow.ObtenerTonalidadOscuraDeColor(color), 3);

            if (IncluirDatos)
            {
                String[] datos = Datos.Split('|');
                int xInicial = xCentro; //Convert.ToInt32(pixeles[0].Split(',')[1]);
                int yInicial = yCentro; //bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0]);
                int i = 0;
                foreach (String dato in datos)
                {
                    EscribirTexto(dato, new System.Drawing.Point(xInicial, yInicial + (i * (int)(tamLetra + tamLetra * 0.5))));
                    i++;
                }
            }
            g.Flush();

        }

        private void DibujarPoligonos(_ps_EspacioFisico espacio, System.Drawing.Color color)
        {
            List<String> coordenadas = new List<string>();
            if (espacio.St_CoordenadasEspaciales == null) return;
            coordenadas = espacio.St_CoordenadasEspaciales.Split('|').ToList<String>();
            List<String> pixeles = new List<string>();
            foreach (String coordenada in coordenadas)
            {
                double latitud = Convert.ToDouble(coordenada.Split(',')[0]);
                double longitud = Convert.ToDouble(coordenada.Split(',')[1]);

                double pixelX = (latitud - latitudMenor) * 500000;
                double pixelY = (longitud - longitudMenor) * 500000;

                int pixelFinalX = (int)(pixelX / factorEscala);
                int pixelFinalY = (int)(pixelY / factorEscala);

                pixeles.Add(pixelFinalX + ", " + pixelFinalY);

            }
            List<System.Drawing.Point> puntosPoligono = new List<System.Drawing.Point>();
            foreach (String pixel in pixeles)
            {
                int pixelX = Convert.ToInt32(pixel.Split(',')[0]);
                int pixelY = Convert.ToInt32(pixel.Split(',')[1]);
                puntosPoligono.Add(new System.Drawing.Point(pixelY, bm_planoMapa.Height - 1 - pixelX));

            }
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm_planoMapa);

            System.Drawing.SolidBrush brushRelleno = new System.Drawing.SolidBrush(color);
            System.Drawing.Pen penLinea = new System.Drawing.Pen(System.Drawing.Color.Black, 3);

            g.FillPolygon(brushRelleno, puntosPoligono.ToArray());
            g.DrawPolygon(penLinea, puntosPoligono.ToArray());

            g.Flush();

        }
        private void DibujarLineas(_ps_EspacioFisico espacio)
        {
            List<String> coordenadas = new List<string>();
            if (espacio.St_CoordenadasEspaciales == null) return;
            coordenadas = espacio.St_CoordenadasEspaciales.Split('|').ToList<String>();
            List<String> pixeles = new List<string>();
            foreach (String coordenada in coordenadas)
            {
                double latitud = Convert.ToDouble(coordenada.Split(',')[0]);
                double longitud = Convert.ToDouble(coordenada.Split(',')[1]);

                double pixelY = (latitud - latitudMenor) * 500000;
                double pixelX = (longitud - longitudMenor) * 500000;
                pixeles.Add((int)pixelY / factorEscala + ", " + (int)pixelX / factorEscala);

            }
            foreach (String pixel in pixeles)
            {
                int pixelX = Convert.ToInt32(pixel.Split(',')[0]);
                int pixelY = Convert.ToInt32(pixel.Split(',')[1]);
                bm_planoMapa.SetPixel(pixelY, bm_planoMapa.Height - 1 - pixelX, System.Drawing.Color.Black);
            }
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm_planoMapa);
            for (int i = 0; i < pixeles.Count - 1; i++)
                g.DrawLine(System.Drawing.Pens.Black, new System.Drawing.Point(Convert.ToInt32(pixeles[i].Split(',')[1]), bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[i].Split(',')[0])), new System.Drawing.Point(Convert.ToInt32(pixeles[i + 1].Split(',')[1]), bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[i + 1].Split(',')[0])));

            g.DrawLine(System.Drawing.Pens.Black, new System.Drawing.Point(Convert.ToInt32(pixeles[pixeles.Count - 1].Split(',')[1]), bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[pixeles.Count - 1].Split(',')[0])), new System.Drawing.Point(Convert.ToInt32(pixeles[0].Split(',')[1]), bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0])));
            String drawString = espacio.st_Nombre_espacio;
            EscribirTexto(espacio.st_Nombre_espacio, new System.Drawing.Point(Convert.ToInt32(pixeles[0].Split(',')[1]), bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0])));
            EscribirTexto("ha: " + espacio.do_Numero_hectareas, new System.Drawing.Point(Convert.ToInt32(pixeles[0].Split(',')[1]), 10 + bm_planoMapa.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0])));
            g.Flush();

        }

        private void EscribirTexto(String texto, System.Drawing.Point punto)
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm_planoMapa);
            System.Drawing.Font drawFont = new System.Drawing.Font(fuente, tamLetra);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            g.DrawString(texto, drawFont, drawBrush, punto);
        }

        #endregion
    }
}
